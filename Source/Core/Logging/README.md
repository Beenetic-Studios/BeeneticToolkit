# BeeneticToolkit.Logging

[![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Logging.svg)](https://www.nuget.org/packages/BeeneticToolkit.Logging) [![Downloads](https://img.shields.io/nuget/dt/BeeneticToolkit.Logging.svg)](https://www.nuget.org/packages/BeeneticToolkit.Logging) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/bfranksen/BeeneticToolkit/blob/master/LICENSE.txt)

A small, dependency-free logging toolkit for .NET and Unity: severity-based logging that fans out to
multiple sinks (console, debug output, file, or your own), with rich, configurable message formatting and
automatic caller context.

Targets `netstandard2.1`.

### Is this for you?

It's deliberately a **lightweight, zero-dependency, code-first** logger — a great fit for **Unity** (no
dependency tree, IL2CPP-friendly, trivial custom sinks) and small/solo .NET projects where you want
readable console/file logging without a configuration ecosystem. Distinctive touches: per-component message
formatting, built-in object/method context, and recursive property dumps for debugging.

It is **string logging, not structured logging.** If you need message templates, queryable/aggregated sinks
(Seq, ELK), or `Microsoft.Extensions.Logging.ILogger` integration, reach for **Serilog** or
**Microsoft.Extensions.Logging** instead — that's not what this is.

## Core ideas

- **`LoggerBase`** — the base for a sink. Implement one method, `WriteEntry`, and you have a logger.
- **`LogManager`** — holds a set of loggers and fans each message out to all of them. The explicit,
  instantiable, injectable primitive. No global state.
- **`LoggerService`** — an optional, process-wide static convenience over a single `LogManager`.

> **Which do I use — `LogManager` or `LoggerService`?**
> They are two layers, not two competing options:
> - Reach for **`LogManager`** when you want explicit control or testability — hand it to the classes that
>   need it, create independent managers per scope, and substitute freely in tests. It carries **no global
>   state**, so it parallelizes cleanly.
> - Reach for **`LoggerService`** for the common "one logging setup, configured once at startup, called from
>   everywhere" app pattern, when threading a `LogManager` through every class would be noise.
>
> `LoggerService` is *thin sugar over a single `LogManager`* — it adds convenience, not capability. Because it
> is global mutable state it carries the usual costs (hidden dependency on `Initialize`, shared state across
> tests); if those matter to a given piece of code, use a `LogManager` directly. Library code should prefer
> an injected `LogManager`; application/game code is where the static shines.

## Install

```sh
dotnet add package BeeneticToolkit.Logging
```

## Quick start (application style — `LoggerService`)

```csharp
using BeeneticToolkit.Logging;
using BeeneticToolkit.Logging.Loggers;

// Once, at startup:
var manager = new LogManager()
    .AddLogger(new ConsoleLogger("console"))
    .AddLogger(new FileLogger("logs/session.log", "file"));

LoggerService.Initialize(manager);

// Anywhere, from any class — no logger to pass around:
LoggerService.Info("Session started");
LoggerService.Warn("Low memory", this);          // include the calling object as context
LoggerService.Error("Save failed");
```

`LoggerService` is **null-safe**: before `Initialize` (or after `Initialize(null)`), every call is a no-op,
so logging sprinkled through a codebase never needs guarding.

## Quick start (explicit style — `LogManager`)

```csharp
var log = new LogManager().AddLogger(new ConsoleLogger());

log.Info("Spawned", this);
log.Error("Pathfinding failed", this);

// Inject it where it's needed:
var enemy = new Enemy(log);
```

## Severity and caller context

The severity-named methods — `Trace`, `Info`, `Debug`, `Warn`, `Error`, `Fatal` — exist on `LogManager`,
`LoggerService`, and (as extension methods) any `LoggerBase`. Each takes `(string message, object context =
null, …)` and **captures the calling member automatically at compile time** via `[CallerMemberName]` — no
`MethodBase.GetCurrentMethod()`, no reflection, and free even when the message is filtered out:

```csharp
log.Info("Reloading", this);
// → [2026-06-15 09:00:00] [Info] [WeaponSystem].[WeaponSystem].[Reload] Reloading
```

> Severity order is the conventional `Trace < Debug < Info < Warn < Error < Fatal`. A logger's `Threshold`
> emits messages at or above it — e.g. `LogThreshold.Info` shows Info/Warn/Error/Fatal and drops Trace/Debug.

The raw `Log(severity, …)` overloads remain for explicit control, including an overload that takes a
`MethodBase` if you prefer to pass it yourself.

### Avoiding the cost of logs you won't emit

Message arguments are built *before* the call runs, so a filtered-out log still pays to construct its
string. For expensive, verbose, usually-disabled sites, guard with `IsEnabled` (cheapest — no allocation),
or pass a `Func<string>` overload that only runs when the message will actually be emitted:

```csharp
if (log.IsEnabled(LogSeverity.Debug))
    log.Debug($"State: {ComputeExpensiveSnapshot()}");   // built only when needed

log.Debug(() => $"State: {ComputeExpensiveSnapshot()}"); // same, via a deferred factory
```

`IsEnabled` and the `Func<string>` overloads exist on `LogManager`, `LoggerService`, and any `LoggerBase`.

## Configuring a logger

```csharp
var file = new FileLogger("logs/run.log", "file", LogThreshold.Warn) {  // only Warn and above
    TimestampFormat = "HH:mm:ss.fff",
    Includes = new BaseMessageIncludes(                                  // pick which parts appear
        timestamp: true, logSeverity: true,
        typeName: true, objectName: false, methodName: true),
};
```

`Threshold` filters by severity (`LogThreshold.Off` disables a logger entirely); `Enabled` toggles it at
runtime; `Includes` chooses which components (timestamp, severity, type, object, method) appear in each line.

## Writing your own logger

Subclass `LoggerBase` and implement the single sink method. The base handles threshold filtering and all
message formatting; you only decide *where the text goes* (and can route by severity):

```csharp
public sealed class UnityDebugLogger : LoggerBase {
    public UnityDebugLogger(string? name = null, LogThreshold threshold = LogThreshold.All)
        : base(name, threshold) { }

    protected override void WriteEntry(LogSeverity severity, string entry) {
        switch (severity) {
            case LogSeverity.Warn:                       UnityEngine.Debug.LogWarning(entry); break;
            case LogSeverity.Error:
            case LogSeverity.Fatal:                      UnityEngine.Debug.LogError(entry);   break;
            default:                                     UnityEngine.Debug.Log(entry);        break;
        }
    }
}
```

Built-in loggers: `ConsoleLogger`, `DebugLogger` (`System.Diagnostics.Debug`), and `FileLogger`.

### File logging

`FileLogger` keeps a single writer open per file path, shared across all loggers (and threads) targeting it —
no per-message open/close, writes serialized. Entries flush to disk immediately by default (`AutoFlush`);
set `AutoFlush = false` for throughput and call `Flush()` periodically. Call `FileLogger.CloseAll()` once on
shutdown (e.g. Unity's `OnApplicationQuit`) to flush and release the handles:

```csharp
var file = new FileLogger("logs/run.log");
// ...
FileLogger.CloseAll();   // on shutdown
```

## Property dumps

`LogUtils` and the `ObjectPropertyExtensions` helpers turn objects and collections into readable strings for
logging — recursively dumping public properties, with `[LogIgnore]` to exclude sensitive or noisy members:

```csharp
using BeeneticToolkit.Logging.Utilities;

log.Info(player.ToPropertiesString(), this);     // dumps public properties (nested, collections, dictionaries)
log.Info(LogUtils.PrintElements(items));         // inline or multi-line collection rendering

public class Player {
    public string Name { get; set; }
    [LogIgnore] public string SessionToken { get; set; }   // never appears in dumps
}
```

## License

Licensed under the MIT License.
