# BeeneticToolkit.Text

[![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Text.svg)](https://www.nuget.org/packages/BeeneticToolkit.Text) [![Downloads](https://img.shields.io/nuget/dt/BeeneticToolkit.Text.svg)](https://www.nuget.org/packages/BeeneticToolkit.Text) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/Beenetic-Studios/BeeneticToolkit/blob/master/LICENSE.txt)

Checks for player-entered text: display names, statuses, and chat lines. Pure .NET with no dependencies and no
engine types, so the same check runs in Unity, in a `dotnet test` harness, and on a C# server.

Targets `netstandard2.1` and `net8.0`.

## Install

```sh
dotnet add package BeeneticToolkit.Text
```

## Word filter

`WordFilter` matches text against a tiered `WordList` and sees through the usual disguises: case, accents,
Cyrillic and Greek lookalikes, styled and enclosed Unicode letters (bold, script, circled, fullwidth), leet
(`sh1t`, `a$$`), stretched letters (`baaad`), and separators (`b.a.d`). It also refuses control, zero-width, and
direction characters, and checks length per field.

```csharp
using BeeneticToolkit.Text;

var list = new WordList(
    anywhere: new[] { "badword" },        // matched anywhere, across word breaks
    word:     new[] { "bad" },            // matched as a whole word only, so "badge" is fine
    allow:    new[] { "badminton" },      // always fine, even though it contains an entry
    reserved: new[] { "admin", "mod" });  // names must not contain these

var filter = new WordFilter(list);

var nameRules   = new WordFilterRules(minLength: 3, maxLength: 20, checkReserved: true);
var statusRules = new WordFilterRules(minLength: 0, maxLength: 60, checkReserved: false);

filter.Check("B4D", nameRules);         // WordFilterVerdict.Word
filter.Check("TheAdmin", nameRules);    // WordFilterVerdict.Reserved
filter.Check("TheAdmin", statusRules);  // WordFilterVerdict.Ok
filter.Check("ab", nameRules);          // WordFilterVerdict.Length
```

Verdicts come back in rule order (`Characters` for a blank text, then `Length`, `Characters`, `Word`,
`Reserved`), so you can show the player which rule they hit. Every list entry is lowercase `a` to `z`; the
filter does the folding. A filter is immutable and thread-safe: build one per list and share it.

### The word list

**This package ships no list.** Bring your own and build a `WordList` from it however you load data. A common
starting point is the LDNOOBW English list, which is licensed **CC BY 4.0**: if you use it, keep its attribution
with your copy and credit it in your game. Expect to tune it: move short entries that occur inside innocent
words from `anywhere` to `word`, and add the false positives your players hit to `allow`.

A client-side check is advice to the player. Anything that matters should be checked again where the text is
stored.

## License

Licensed under the MIT License.
