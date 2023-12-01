#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## IRandomGenerator Interface

Provides an interface for random number generation with a variety of methods  
to produce random values of different numeric types and ranges.

```csharp
public interface IRandomGenerator
```

Derived  
&#8627; [RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')

| Methods | |
| :--- | :--- |
| [NextBool()](IRandomGenerator.NextBool().md 'BeeneticToolkit.Random.IRandomGenerator.NextBool()') | Returns a random boolean value. |
| [NextBool(float)](IRandomGenerator.NextBool(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextBool(float)') | Returns a random boolean value with the probability of returning true specified by the input parameter. |
| [NextBytes()](IRandomGenerator.NextBytes().md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes()') | Generates a random byte array with a default length. |
| [NextBytes(int)](IRandomGenerator.NextBytes(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int)') | Generates a random byte array of a specified length. |
| [NextBytes(int, byte, byte)](IRandomGenerator.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int, byte, byte)') | Generates a random byte array of a specified length, with each byte within a specified range. |
| [NextDouble()](IRandomGenerator.NextDouble().md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble()') | Returns a non-negative random double. |
| [NextDouble(double)](IRandomGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double)') | Returns a non-negative random double that is less than the specified maximum. |
| [NextDouble(double, double)](IRandomGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double, double)') | Returns a random double within a specified range. |
| [NextFloat()](IRandomGenerator.NextFloat().md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat()') | Returns a non-negative random float. |
| [NextFloat(float)](IRandomGenerator.NextFloat(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float)') | Returns a non-negative random float that is less than the specified maximum. |
| [NextFloat(float, float)](IRandomGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float, float)') | Returns a random float within a specified range. |
| [NextInt()](IRandomGenerator.NextInt().md 'BeeneticToolkit.Random.IRandomGenerator.NextInt()') | Generates a non-negative random integer. |
| [NextInt(int)](IRandomGenerator.NextInt(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int)') | Returns a non-negative random integer that is less than the specified maximum. |
| [NextInt(int, int)](IRandomGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int, int)') | Returns a random integer within a specified range. |
| [NextLong()](IRandomGenerator.NextLong().md 'BeeneticToolkit.Random.IRandomGenerator.NextLong()') | Generates a non-negative random long integer. |
| [NextLong(long)](IRandomGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long)') | Returns a non-negative random long integer that is less than the specified maximum. |
| [NextLong(long, long)](IRandomGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long)') | Returns a random long integer within a specified range. |
| [NextNormal()](IRandomGenerator.NextNormal().md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal()') | Returns a random double that follows a normal distribution with mean 0 and standard deviation 1. |
| [NextNormal(double, double)](IRandomGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal(double, double)') | Returns a random double that follows a normal distribution with the specified mean and standard deviation. |
