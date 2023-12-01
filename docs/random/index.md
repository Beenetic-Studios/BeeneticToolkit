#### [Random](index.md 'index')

## Random Assembly
### Namespaces

<a name='BeeneticToolkit.Random'></a>

## BeeneticToolkit.Random Namespace

The [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random') namespace encompasses a suite of classes and utilities for random number generation.  
It includes various implementations of random number generators (RNGs), each suited for different  
requirements and scenarios. The namespace offers basic RNGs for general-purpose use, as well as more  
specialized RNGs optimized for specific statistical properties or performance characteristics.
- **[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')** `Class` Serves as the base class for random number generators, providing common functionality for seed management.  
  This abstract class defines the basic structure and seeding mechanism that derived random number generators will use.
  - **[RandomGeneratorBase(long)](RandomGeneratorBase.RandomGeneratorBase(long).md 'BeeneticToolkit.Random.RandomGeneratorBase.RandomGeneratorBase(long)')** `Constructor` Initializes a new instance of the random number generator with the specified seed.
  - **[CalculatedNextDouble](RandomGeneratorBase.CalculatedNextDouble.md 'BeeneticToolkit.Random.RandomGeneratorBase.CalculatedNextDouble')** `Property` Gets a calculated random double value based on the next number in the random sequence.
  - **[CalculatedNextFloat](RandomGeneratorBase.CalculatedNextFloat.md 'BeeneticToolkit.Random.RandomGeneratorBase.CalculatedNextFloat')** `Property` Gets a calculated random float value based on the next number in the random sequence.
  - **[CalculatedNextInt](RandomGeneratorBase.CalculatedNextInt.md 'BeeneticToolkit.Random.RandomGeneratorBase.CalculatedNextInt')** `Property` Gets a calculated random integer value based on the next number in the random sequence.
  - **[Seed](RandomGeneratorBase.Seed.md 'BeeneticToolkit.Random.RandomGeneratorBase.Seed')** `Property` Gets the seed value used for random number generation.
  - **[InitializeRng()](RandomGeneratorBase.InitializeRng().md 'BeeneticToolkit.Random.RandomGeneratorBase.InitializeRng()')** `Method` Initializes the random number generator with the given seed.  
    Override this method in derived classes to set up the random number generator.
  - **[Next()](RandomGeneratorBase.Next().md 'BeeneticToolkit.Random.RandomGeneratorBase.Next()')** `Method` When overridden in a derived class, generates the next random number in the sequence.
  - **[NextBool()](RandomGeneratorBase.NextBool().md 'BeeneticToolkit.Random.RandomGeneratorBase.NextBool()')** `Method` Returns a random boolean value by equally considering the true and false outcomes.
  - **[NextBool(float)](RandomGeneratorBase.NextBool(float).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextBool(float)')** `Method` Returns a random boolean value with the probability of returning true specified by the input parameter.
  - **[NextBytes()](RandomGeneratorBase.NextBytes().md 'BeeneticToolkit.Random.RandomGeneratorBase.NextBytes()')** `Method` Generates a random byte array with a default length.
  - **[NextBytes(int)](RandomGeneratorBase.NextBytes(int).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextBytes(int)')** `Method` Generates a random byte array of a specified length.
  - **[NextBytes(int, byte, byte)](RandomGeneratorBase.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextBytes(int, byte, byte)')** `Method` Generates a random byte array of a specified length, with each byte within a specified range.
  - **[NextDouble()](RandomGeneratorBase.NextDouble().md 'BeeneticToolkit.Random.RandomGeneratorBase.NextDouble()')** `Method` Calculates the next double value in the random sequence.
  - **[NextDouble(double)](RandomGeneratorBase.NextDouble(double).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double)')** `Method` Generates a pseudo-random double between 0 (inclusive) and the specified maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxInclusive is less than or equal to 0.
  - **[NextDouble(double, double)](RandomGeneratorBase.NextDouble(double,double).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double, double)')** `Method` Generates a pseudo-random double between the specified minimum (inclusive) and maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxInclusive.
  - **[NextFloat()](RandomGeneratorBase.NextFloat().md 'BeeneticToolkit.Random.RandomGeneratorBase.NextFloat()')** `Method` Calculates the next float value in the random sequence.
  - **[NextFloat(float)](RandomGeneratorBase.NextFloat(float).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float)')** `Method` Generates a pseudo-random float between 0 (inclusive) and the specified maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxInclusive is less than or equal to 0.
  - **[NextFloat(float, float)](RandomGeneratorBase.NextFloat(float,float).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float, float)')** `Method` Generates a pseudo-random float between the specified minimum (inclusive) and maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxInclusive.
  - **[NextInt()](RandomGeneratorBase.NextInt().md 'BeeneticToolkit.Random.RandomGeneratorBase.NextInt()')** `Method` Generates a non-negative random integer.
  - **[NextInt(int)](RandomGeneratorBase.NextInt(int).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int)')** `Method` Generates a pseudo-random integer between 0 (inclusive) and the specified maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxExclusive is less than or equal to 0.
  - **[NextInt(int, int)](RandomGeneratorBase.NextInt(int,int).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int, int)')** `Method` Generates a pseudo-random integer between the specified minimum (inclusive) and maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxExclusive.
  - **[NextLong()](RandomGeneratorBase.NextLong().md 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong()')** `Method` Generates a non-negative random long integer.
  - **[NextLong(long)](RandomGeneratorBase.NextLong(long).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long)')** `Method` Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxExclusive is less than or equal to 0.
  - **[NextLong(long, long)](RandomGeneratorBase.NextLong(long,long).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long, long)')** `Method` Generates a pseudo-random long integer between the specified minimum (inclusive) and maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxExclusive.
  - **[NextNormal()](RandomGeneratorBase.NextNormal().md 'BeeneticToolkit.Random.RandomGeneratorBase.NextNormal()')** `Method` Generates a normally distributed random number with a default mean of 0.0 and standard deviation of 1.0.  
    This method is an overload of the NextNormal method that uses default parameters to produce a standard normal distribution.
  - **[NextNormal(double, double)](RandomGeneratorBase.NextNormal(double,double).md 'BeeneticToolkit.Random.RandomGeneratorBase.NextNormal(double, double)')** `Method` Generates a normally distributed random number with a specified mean and standard deviation.  
    This method uses the Box-Muller transform to produce a normal distribution.  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if the standard deviation is negative.
- **[RandomGeneratorFactory](RandomGeneratorFactory.md 'BeeneticToolkit.Random.RandomGeneratorFactory')** `Class` Provides factory methods for creating random number generators based on different algorithms.
  - **[GetGenerator()](RandomGeneratorFactory.GetGenerator().md 'BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator()')** `Method` Creates a random number generator using the default algorithm (Xorshift) without a specific seed.
  - **[GetGenerator(RngAlgorithm)](RandomGeneratorFactory.GetGenerator(RngAlgorithm).md 'BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm)')** `Method` Creates a random number generator using a specified algorithm without a specific seed.
  - **[GetGenerator(long)](RandomGeneratorFactory.GetGenerator(long).md 'BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(long)')** `Method` Creates a random number generator using the default algorithm (Xorshift) with a specified seed.
  - **[GetGenerator(long, RngAlgorithm)](RandomGeneratorFactory.GetGenerator(long,RngAlgorithm).md 'BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(long, BeeneticToolkit.Random.RngAlgorithm)')** `Method` Creates a random number generator using a specified algorithm and seed.
- **[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')** `Interface` Provides an interface for random number generation with a variety of methods  
  to produce random values of different numeric types and ranges.
  - **[NextBool()](IRandomGenerator.NextBool().md 'BeeneticToolkit.Random.IRandomGenerator.NextBool()')** `Method` Returns a random boolean value.
  - **[NextBool(float)](IRandomGenerator.NextBool(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextBool(float)')** `Method` Returns a random boolean value with the probability of returning true specified by the input parameter.
  - **[NextBytes()](IRandomGenerator.NextBytes().md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes()')** `Method` Generates a random byte array with a default length.
  - **[NextBytes(int)](IRandomGenerator.NextBytes(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int)')** `Method` Generates a random byte array of a specified length.
  - **[NextBytes(int, byte, byte)](IRandomGenerator.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int, byte, byte)')** `Method` Generates a random byte array of a specified length, with each byte within a specified range.
  - **[NextDouble()](IRandomGenerator.NextDouble().md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble()')** `Method` Returns a non-negative random double.
  - **[NextDouble(double)](IRandomGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double)')** `Method` Returns a non-negative random double that is less than the specified maximum.
  - **[NextDouble(double, double)](IRandomGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double, double)')** `Method` Returns a random double within a specified range.
  - **[NextFloat()](IRandomGenerator.NextFloat().md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat()')** `Method` Returns a non-negative random float.
  - **[NextFloat(float)](IRandomGenerator.NextFloat(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float)')** `Method` Returns a non-negative random float that is less than the specified maximum.
  - **[NextFloat(float, float)](IRandomGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float, float)')** `Method` Returns a random float within a specified range.
  - **[NextInt()](IRandomGenerator.NextInt().md 'BeeneticToolkit.Random.IRandomGenerator.NextInt()')** `Method` Generates a non-negative random integer.
  - **[NextInt(int)](IRandomGenerator.NextInt(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int)')** `Method` Returns a non-negative random integer that is less than the specified maximum.
  - **[NextInt(int, int)](IRandomGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int, int)')** `Method` Returns a random integer within a specified range.
  - **[NextLong()](IRandomGenerator.NextLong().md 'BeeneticToolkit.Random.IRandomGenerator.NextLong()')** `Method` Generates a non-negative random long integer.
  - **[NextLong(long)](IRandomGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long)')** `Method` Returns a non-negative random long integer that is less than the specified maximum.
  - **[NextLong(long, long)](IRandomGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long)')** `Method` Returns a random long integer within a specified range.
  - **[NextNormal()](IRandomGenerator.NextNormal().md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal()')** `Method` Returns a random double that follows a normal distribution with mean 0 and standard deviation 1.
  - **[NextNormal(double, double)](IRandomGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal(double, double)')** `Method` Returns a random double that follows a normal distribution with the specified mean and standard deviation.
- **[RngAlgorithm](RngAlgorithm.md 'BeeneticToolkit.Random.RngAlgorithm')** `Enum` Defines the algorithms available for random number generation.
  - **[CombinedLCG](RngAlgorithm.md#BeeneticToolkit.Random.RngAlgorithm.CombinedLCG 'BeeneticToolkit.Random.RngAlgorithm.CombinedLCG')** `Field` Represents the Combined Linear Congruential Generator algorithm.
  - **[MiddleSquare](RngAlgorithm.md#BeeneticToolkit.Random.RngAlgorithm.MiddleSquare 'BeeneticToolkit.Random.RngAlgorithm.MiddleSquare')** `Field` Represents the Middle Square Weyl algorithm.
  - **[Xorshift](RngAlgorithm.md#BeeneticToolkit.Random.RngAlgorithm.Xorshift 'BeeneticToolkit.Random.RngAlgorithm.Xorshift')** `Field` Represents the Xorshift algorithm.