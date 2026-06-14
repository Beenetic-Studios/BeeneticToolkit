#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## IRandomGenerator Interface

Defines the contract for random number generators that can produce values  
across multiple primitive types and distributions.

```csharp
public interface IRandomGenerator
```

Derived  
&#8627; [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

| Methods | |
| :--- | :--- |
| [NextBool()](IRandomGenerator.NextBool().md 'BeeneticToolkit.Random.IRandomGenerator.NextBool()') | Generates a random boolean value. |
| [NextBool(float)](IRandomGenerator.NextBool(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextBool(float)') | Generates a random boolean value using the specified probability of returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool'). |
| [NextBytes()](IRandomGenerator.NextBytes().md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes()') | Generates a random byte array with the default length. |
| [NextBytes(int, byte, byte)](IRandomGenerator.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int, byte, byte)') | Generates a random byte array of the specified length, with each byte<br/>falling within the specified range. |
| [NextBytes(int)](IRandomGenerator.NextBytes(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int)') | Generates a random byte array of the specified length. |
| [NextDouble()](IRandomGenerator.NextDouble().md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble()') | Generates a non-negative random double. |
| [NextDouble(double, double)](IRandomGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double, double)') | Generates a random double within the specified range. |
| [NextDouble(double)](IRandomGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double)') | Generates a non-negative random double that is less than or equal to the specified maximum. |
| [NextFloat()](IRandomGenerator.NextFloat().md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat()') | Generates a non-negative random float. |
| [NextFloat(float, float)](IRandomGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float, float)') | Generates a random float within the specified range. |
| [NextFloat(float)](IRandomGenerator.NextFloat(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float)') | Generates a non-negative random float that is less than or equal to the specified maximum. |
| [NextInt()](IRandomGenerator.NextInt().md 'BeeneticToolkit.Random.IRandomGenerator.NextInt()') | Generates a non-negative random integer. |
| [NextInt(int, int)](IRandomGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int, int)') | Generates a random integer within the specified range. |
| [NextInt(int)](IRandomGenerator.NextInt(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int)') | Generates a non-negative random integer that is less than the specified maximum. |
| [NextLong()](IRandomGenerator.NextLong().md 'BeeneticToolkit.Random.IRandomGenerator.NextLong()') | Generates a non-negative random long integer. |
| [NextLong(long, long)](IRandomGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long)') | Generates a random long integer within the specified range. |
| [NextLong(long)](IRandomGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long)') | Generates a non-negative random long integer that is less than the specified maximum. |
| [NextNormal()](IRandomGenerator.NextNormal().md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal()') | Generates a random double from the standard normal distribution. |
| [NextNormal(double, double)](IRandomGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal(double, double)') | Generates a random double from a normal distribution with the specified mean and standard deviation. |
