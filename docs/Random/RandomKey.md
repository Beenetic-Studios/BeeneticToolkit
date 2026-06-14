#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RandomKey Struct

Represents a strongly typed key used to identify a random number generator  
within an [RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment').

```csharp
public readonly struct RandomKey :
System.IEquatable<BeeneticToolkit.Random.RandomKey>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

### Remarks
[RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey') provides a readable and reusable alternative to raw string keys  
            while still allowing interoperability with APIs that accept string values.

| Constructors | |
| :--- | :--- |
| [RandomKey(string)](RandomKey.RandomKey(string).md 'BeeneticToolkit.Random.RandomKey.RandomKey(string)') | Initializes a new instance of the [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey') struct. |

| Properties | |
| :--- | :--- |
| [IsEmpty](RandomKey.IsEmpty.md 'BeeneticToolkit.Random.RandomKey.IsEmpty') | Gets a value indicating whether this key is uninitialized or empty. |
| [Value](RandomKey.Value.md 'BeeneticToolkit.Random.RandomKey.Value') | Gets the underlying string value of the key. |

| Methods | |
| :--- | :--- |
| [Equals(RandomKey)](RandomKey.Equals(RandomKey).md 'BeeneticToolkit.Random.RandomKey.Equals(BeeneticToolkit.Random.RandomKey)') | Determines whether the current key is equal to another [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey'). |
| [Equals(object)](RandomKey.Equals(object).md 'BeeneticToolkit.Random.RandomKey.Equals(object)') | Determines whether the current key is equal to the specified object. |
| [GetHashCode()](RandomKey.GetHashCode().md 'BeeneticToolkit.Random.RandomKey.GetHashCode()') | Returns the hash code for this key. |
| [ToString()](RandomKey.ToString().md 'BeeneticToolkit.Random.RandomKey.ToString()') | Returns the string representation of the key. |

| Operators | |
| :--- | :--- |
| [operator ==(RandomKey, RandomKey)](RandomKey.operator(RandomKey,RandomKey).md 'BeeneticToolkit.Random.RandomKey.op_Equality(BeeneticToolkit.Random.RandomKey, BeeneticToolkit.Random.RandomKey)') | Determines whether two [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey') values are equal. |
| [explicit operator RandomKey(string)](RandomKey.explicitoperatorRandomKey(string).md 'BeeneticToolkit.Random.RandomKey.op_Explicit BeeneticToolkit.Random.RandomKey(string)') | Converts a string value to an [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey'). |
| [implicit operator string(RandomKey)](RandomKey.implicitoperatorstring(RandomKey).md 'BeeneticToolkit.Random.RandomKey.op_Implicit string(BeeneticToolkit.Random.RandomKey)') | Converts an [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey') to its underlying string value. |
| [operator !=(RandomKey, RandomKey)](RandomKey.operator!(RandomKey,RandomKey).md 'BeeneticToolkit.Random.RandomKey.op_Inequality(BeeneticToolkit.Random.RandomKey, BeeneticToolkit.Random.RandomKey)') | Determines whether two [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey') values are not equal. |
