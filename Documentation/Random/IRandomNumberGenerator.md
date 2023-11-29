#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## IRandomNumberGenerator Interface

Provides an interface for random number generation with a variety of methods  
to produce random values of different numeric types and ranges.

```csharp
public interface IRandomNumberGenerator
```

Derived  
&#8627; [RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

| Methods | |
| :--- | :--- |
| [NextBool()](IRandomNumberGenerator.NextBool().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextBool()') | Returns a random boolean value. |
| [NextBool(float)](IRandomNumberGenerator.NextBool(float).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextBool(float)') | Returns a random boolean value with the probability of returning true specified by the input parameter. |
| [NextBytes()](IRandomNumberGenerator.NextBytes().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextBytes()') | Generates a random byte array with a default length. |
| [NextBytes(int)](IRandomNumberGenerator.NextBytes(int).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextBytes(int)') | Generates a random byte array of a specified length. |
| [NextBytes(int, byte, byte)](IRandomNumberGenerator.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextBytes(int, byte, byte)') | Generates a random byte array of a specified length, with each byte within a specified range. |
| [NextDouble()](IRandomNumberGenerator.NextDouble().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble()') | Returns a non-negative random double. |
| [NextDouble(double)](IRandomNumberGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble(double)') | Returns a non-negative random double that is less than the specified maximum. |
| [NextDouble(double, double)](IRandomNumberGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble(double, double)') | Returns a random double within a specified range. |
| [NextFloat()](IRandomNumberGenerator.NextFloat().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextFloat()') | Returns a non-negative random float. |
| [NextFloat(float)](IRandomNumberGenerator.NextFloat(float).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextFloat(float)') | Returns a non-negative random float that is less than the specified maximum. |
| [NextFloat(float, float)](IRandomNumberGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextFloat(float, float)') | Returns a random float within a specified range. |
| [NextInt()](IRandomNumberGenerator.NextInt().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextInt()') | Generates a non-negative random integer. |
| [NextInt(int)](IRandomNumberGenerator.NextInt(int).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextInt(int)') | Returns a non-negative random integer that is less than the specified maximum. |
| [NextInt(int, int)](IRandomNumberGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextInt(int, int)') | Returns a random integer within a specified range. |
| [NextLong()](IRandomNumberGenerator.NextLong().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextLong()') | Generates a non-negative random long integer. |
| [NextLong(long)](IRandomNumberGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextLong(long)') | Returns a non-negative random long integer that is less than the specified maximum. |
| [NextLong(long, long)](IRandomNumberGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextLong(long, long)') | Returns a random long integer within a specified range. |
| [NextNormal()](IRandomNumberGenerator.NextNormal().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextNormal()') | Returns a random double that follows a Normal (normal) distribution with mean 0 and standard deviation 1. |
| [NextNormal(double, double)](IRandomNumberGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextNormal(double, double)') | Returns a random double that follows a Normal (normal) distribution with the specified mean and standard deviation. |
