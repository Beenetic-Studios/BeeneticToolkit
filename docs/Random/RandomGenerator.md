#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RandomGenerator Class

Serves as the base class for random number generators, providing common functionality for seed management.  
This abstract class defines the basic structure and seeding mechanism that derived random number generators will use.

```csharp
public abstract class RandomGenerator :
BeeneticToolkit.Random.IRandomGenerator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RandomGenerator

Implements [IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

### Remarks
Instances are <b>not</b> thread-safe: each call advances mutable internal state. Use a separate  
generator per thread, or a per-scope [RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment') registration, rather than sharing  
a single instance across threads. The registry types ([RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment'), [RandomManager](RandomManager.md 'BeeneticToolkit.Random.RandomManager'))  
are themselves safe for concurrent registration and lookup.

| Constructors | |
| :--- | :--- |
| [RandomGenerator(long)](RandomGenerator.RandomGenerator(long).md 'BeeneticToolkit.Random.RandomGenerator.RandomGenerator(long)') | Initializes a new instance of the random number generator with the specified seed. |

| Properties | |
| :--- | :--- |
| [CalculatedNextDouble](RandomGenerator.CalculatedNextDouble.md 'BeeneticToolkit.Random.RandomGenerator.CalculatedNextDouble') | Gets a calculated random double value, uniformly distributed in the half-open range `[0, 1)`. |
| [CalculatedNextFloat](RandomGenerator.CalculatedNextFloat.md 'BeeneticToolkit.Random.RandomGenerator.CalculatedNextFloat') | Gets a calculated random float value, uniformly distributed in the half-open range `[0, 1)`. |
| [NextMaxInclusive](RandomGenerator.NextMaxInclusive.md 'BeeneticToolkit.Random.RandomGenerator.NextMaxInclusive') | Gets the inclusive maximum value that [Next()](RandomGenerator.Next().md 'BeeneticToolkit.Random.RandomGenerator.Next()') can return. |
| [Seed](RandomGenerator.Seed.md 'BeeneticToolkit.Random.RandomGenerator.Seed') | Gets the seed value used for random number generation. |

| Methods | |
| :--- | :--- |
| [InitializeRng()](RandomGenerator.InitializeRng().md 'BeeneticToolkit.Random.RandomGenerator.InitializeRng()') | Initializes the random number generator with the given seed.<br/>Override this method in derived classes to set up the random number generator. |
| [Next()](RandomGenerator.Next().md 'BeeneticToolkit.Random.RandomGenerator.Next()') | When overridden in a derived class, generates the next random number in the sequence. |
| [NextBool()](RandomGenerator.NextBool().md 'BeeneticToolkit.Random.RandomGenerator.NextBool()') | Returns a random boolean value by equally considering the true and false outcomes. |
| [NextBool(float)](RandomGenerator.NextBool(float).md 'BeeneticToolkit.Random.RandomGenerator.NextBool(float)') | Returns a random boolean value with the probability of returning true specified by the input parameter. |
| [NextBytes()](RandomGenerator.NextBytes().md 'BeeneticToolkit.Random.RandomGenerator.NextBytes()') | Generates a random byte array with a default length. |
| [NextBytes(int, byte, byte)](RandomGenerator.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.RandomGenerator.NextBytes(int, byte, byte)') | Generates a random byte array of a specified length, with each byte within a specified range. |
| [NextBytes(int)](RandomGenerator.NextBytes(int).md 'BeeneticToolkit.Random.RandomGenerator.NextBytes(int)') | Generates a random byte array of a specified length. |
| [NextBytes(Span&lt;byte&gt;)](RandomGenerator.NextBytes(Span_byte_).md 'BeeneticToolkit.Random.RandomGenerator.NextBytes(System.Span<byte>)') | Fills the provided buffer with random bytes, without allocating. |
| [NextDouble()](RandomGenerator.NextDouble().md 'BeeneticToolkit.Random.RandomGenerator.NextDouble()') | Calculates the next double value in the random sequence. |
| [NextDouble(double, double)](RandomGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double)') | Generates a pseudo-random double between the specified minimum (inclusive) and maximum (inclusive).<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).minInclusive') is greater than or equal to [maxInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).maxInclusive'). |
| [NextDouble(double)](RandomGenerator.NextDouble(double).md 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double)') | Generates a pseudo-random double between 0 (inclusive) and the specified maximum (inclusive).<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxInclusive](RandomGenerator.NextDouble(double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive') is less than or equal to 0. |
| [NextEnum&lt;T&gt;()](RandomGenerator.NextEnum_T_().md 'BeeneticToolkit.Random.RandomGenerator.NextEnum<T>()') | Returns a uniformly random value of the enum type [T](RandomGenerator.NextEnum_T_().md#BeeneticToolkit.Random.RandomGenerator.NextEnum_T_().T 'BeeneticToolkit.Random.RandomGenerator.NextEnum<T>().T'). |
| [NextFloat()](RandomGenerator.NextFloat().md 'BeeneticToolkit.Random.RandomGenerator.NextFloat()') | Calculates the next float value in the random sequence. |
| [NextFloat(float, float)](RandomGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float)') | Generates a pseudo-random float between the specified minimum (inclusive) and maximum (inclusive).<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).minInclusive') is greater than or equal to [maxInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).maxInclusive'). |
| [NextFloat(float)](RandomGenerator.NextFloat(float).md 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float)') | Generates a pseudo-random float between 0 (inclusive) and the specified maximum (inclusive).<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxInclusive](RandomGenerator.NextFloat(float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float).maxInclusive') is less than or equal to 0. |
| [NextGuid()](RandomGenerator.NextGuid().md 'BeeneticToolkit.Random.RandomGenerator.NextGuid()') | Generates a [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid') populated with random bytes. |
| [NextInt()](RandomGenerator.NextInt().md 'BeeneticToolkit.Random.RandomGenerator.NextInt()') | Generates a non-negative random integer. |
| [NextInt(int, int)](RandomGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int)') | Generates a pseudo-random integer between the specified minimum (inclusive) and maximum (exclusive).<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).minInclusive') is greater than or equal to [maxExclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).maxExclusive'). |
| [NextInt(int)](RandomGenerator.NextInt(int).md 'BeeneticToolkit.Random.RandomGenerator.NextInt(int)') | Generates a pseudo-random integer between 0 (inclusive) and the specified maximum (exclusive).<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxExclusive](RandomGenerator.NextInt(int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int).maxExclusive') is less than or equal to 0. |
| [NextLong()](RandomGenerator.NextLong().md 'BeeneticToolkit.Random.RandomGenerator.NextLong()') | Generates a non-negative random long integer. |
| [NextLong(long, long)](RandomGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long)') | Generates a pseudo-random long integer between the specified minimum (inclusive) and maximum (exclusive).<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).minInclusive') is greater than or equal to [maxExclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).maxExclusive'). |
| [NextLong(long)](RandomGenerator.NextLong(long).md 'BeeneticToolkit.Random.RandomGenerator.NextLong(long)') | Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxExclusive](RandomGenerator.NextLong(long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive') is less than or equal to 0. |
| [NextNormal()](RandomGenerator.NextNormal().md 'BeeneticToolkit.Random.RandomGenerator.NextNormal()') | Generates a normally distributed random number with a default mean of 0.0 and standard deviation of 1.0.<br/>This method is an overload of the NextNormal method that uses default parameters to produce a standard normal distribution. |
| [NextNormal(double, double)](RandomGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.RandomGenerator.NextNormal(double, double)') | Generates a normally distributed random number with a specified mean and standard deviation.<br/>This method uses the Box-Muller transform to produce a normal distribution.<br/>It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if the standard deviation is negative. |
| [NextSign()](RandomGenerator.NextSign().md 'BeeneticToolkit.Random.RandomGenerator.NextSign()') | Returns either -1 or +1 with equal probability. |
