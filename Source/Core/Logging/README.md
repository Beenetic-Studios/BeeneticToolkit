# BeeneticToolkit.Logging

A small, dependency-free logging toolkit for .NET and Unity: severity-based logging that fans out to
multiple sinks (console, debug output, file, or your own), with rich, configurable message formatting and
automatic caller context.

Targets `netstandard2.1`.

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

> Severity order is `Trace, Info, Debug, Warn, Error, Fatal`. **Note this differs from most frameworks**: here
> `Info` is *below* `Debug`, so a `Debug` threshold filters out `Info`. Set a logger's `Threshold` accordingly.

The raw `Log(severity, …)` overloads remain for explicit control, including an overload that takes a
`MethodBase` if you prefer to pass it yourself.

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

Built-in loggers: `ConsoleLogger`, `DebugLogger` (`System.Diagnostics.Debug`), and `FileLogger`
(thread-safe; concurrent appends to the same path are serialized).

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
