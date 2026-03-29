#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RngKey Struct

Represents a strongly typed key used to identify a random number generator  
within an [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment').

```csharp
public readonly struct RngKey :
System.IEquatable<BeeneticToolkit.Random.RngKey>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

### Remarks
[RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') provides a readable and reusable alternative to raw string keys  
            while still allowing interoperability with APIs that accept string values.

| Constructors | |
| :--- | :--- |
| [RngKey(string)](RngKey.RngKey(string).md 'BeeneticToolkit.Random.RngKey.RngKey(string)') | Initializes a new instance of the [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') struct. |

| Properties | |
| :--- | :--- |
| [IsEmpty](RngKey.IsEmpty.md 'BeeneticToolkit.Random.RngKey.IsEmpty') | Gets a value indicating whether this key is uninitialized or empty. |
| [Value](RngKey.Value.md 'BeeneticToolkit.Random.RngKey.Value') | Gets the underlying string value of the key. |

| Methods | |
| :--- | :--- |
| [Equals(RngKey)](RngKey.Equals(RngKey).md 'BeeneticToolkit.Random.RngKey.Equals(BeeneticToolkit.Random.RngKey)') | Determines whether the current key is equal to another [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey'). |
| [Equals(object)](RngKey.Equals(object).md 'BeeneticToolkit.Random.RngKey.Equals(object)') | Determines whether the current key is equal to the specified object. |
| [GetHashCode()](RngKey.GetHashCode().md 'BeeneticToolkit.Random.RngKey.GetHashCode()') | Returns the hash code for this key. |
| [ToString()](RngKey.ToString().md 'BeeneticToolkit.Random.RngKey.ToString()') | Returns the string representation of the key. |

| Operators | |
| :--- | :--- |
| [operator ==(RngKey, RngKey)](RngKey.operator(RngKey,RngKey).md 'BeeneticToolkit.Random.RngKey.op_Equality(BeeneticToolkit.Random.RngKey, BeeneticToolkit.Random.RngKey)') | Determines whether two [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') values are equal. |
| [explicit operator RngKey(string)](RngKey.explicitoperatorRngKey(string).md 'BeeneticToolkit.Random.RngKey.op_Explicit BeeneticToolkit.Random.RngKey(string)') | Converts a string value to an [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey'). |
| [implicit operator string(RngKey)](RngKey.implicitoperatorstring(RngKey).md 'BeeneticToolkit.Random.RngKey.op_Implicit string(BeeneticToolkit.Random.RngKey)') | Converts an [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') to its underlying string value. |
| [operator !=(RngKey, RngKey)](RngKey.operator!(RngKey,RngKey).md 'BeeneticToolkit.Random.RngKey.op_Inequality(BeeneticToolkit.Random.RngKey, BeeneticToolkit.Random.RngKey)') | Determines whether two [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') values are not equal. |
