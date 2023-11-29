#### [Random](index.md 'index')

## Random Assembly
### Namespaces

<a name='BeeneticToolkit.Random'></a>

## BeeneticToolkit.Random Namespace

The [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random') namespace contains classes and methods to generate randomness.
- **[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')** `Class` Serves as the base class for random number generators, providing common functionality for seed management.  
  This abstract class defines the basic structure and seeding mechanism that derived random number generators will use.
  - **[RandomNumberGeneratorBase()](RandomNumberGeneratorBase.RandomNumberGeneratorBase().md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.RandomNumberGeneratorBase()')** `Constructor` Initializes a new instance of the random number generator with an automatically generated seed.
  - **[RandomNumberGeneratorBase(long)](RandomNumberGeneratorBase.RandomNumberGeneratorBase(long).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.RandomNumberGeneratorBase(long)')** `Constructor` Initializes a new instance of the random number generator with the specified seed.
  - **[CalculatedNextDouble](RandomNumberGeneratorBase.CalculatedNextDouble.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.CalculatedNextDouble')** `Property` Calculates the next double value in the random sequence.
  - **[CalculatedNextFloat](RandomNumberGeneratorBase.CalculatedNextFloat.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.CalculatedNextFloat')** `Property` Calculates the next float value in the random sequence.
  - **[CalculatedNextInt](RandomNumberGeneratorBase.CalculatedNextInt.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.CalculatedNextInt')** `Property` Calculates the next integer value in the random sequence.
  - **[Seed](RandomNumberGeneratorBase.Seed.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.Seed')** `Property` Gets the seed value used for random number generation.
  - **[InitializeRng()](RandomNumberGeneratorBase.InitializeRng().md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.InitializeRng()')** `Method` Initializes the random number generator with the given seed.  
    Override this method in derived classes to set up the random number generator.
  - **[Next()](RandomNumberGeneratorBase.Next().md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.Next()')** `Method` When overridden in a derived class, generates the next random number in the sequence.
  - **[NextBool()](RandomNumberGeneratorBase.NextBool().md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextBool()')** `Method` Returns a random boolean value by equally considering the true and false outcomes.
  - **[NextBool(float)](RandomNumberGeneratorBase.NextBool(float).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextBool(float)')** `Method` Returns a random boolean value with the probability of returning true specified by the input parameter.
  - **[NextDouble()](RandomNumberGeneratorBase.NextDouble().md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble()')** `Method` Calculates the next double value in the random sequence.
  - **[NextDouble(double)](RandomNumberGeneratorBase.NextDouble(double).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double)')** `Method` Generates a pseudo-random double between 0 (inclusive) and the specified maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxInclusive is less than or equal to 0.
  - **[NextDouble(double, double)](RandomNumberGeneratorBase.NextDouble(double,double).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double, double)')** `Method` Generates a pseudo-random double between the specified minimum (inclusive) and maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxInclusive.
  - **[NextFloat()](RandomNumberGeneratorBase.NextFloat().md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextFloat()')** `Method` Calculates the next float value in the random sequence.
  - **[NextFloat(float)](RandomNumberGeneratorBase.NextFloat(float).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextFloat(float)')** `Method` Generates a pseudo-random float between 0 (inclusive) and the specified maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxInclusive is less than or equal to 0.
  - **[NextFloat(float, float)](RandomNumberGeneratorBase.NextFloat(float,float).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextFloat(float, float)')** `Method` Generates a pseudo-random float between the specified minimum (inclusive) and maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxInclusive.
  - **[NextGaussian()](RandomNumberGeneratorBase.NextGaussian().md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextGaussian()')** `Method` Generates a normally distributed (Gaussian) random number with a default mean of 0.0 and standard deviation of 1.0.  
    This method is an overload of the NextGaussian method that uses default parameters to produce a standard Gaussian distribution.
  - **[NextGaussian(double, double)](RandomNumberGeneratorBase.NextGaussian(double,double).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextGaussian(double, double)')** `Method` Generates a normally distributed (Gaussian) random number with a specified mean and standard deviation.  
    This method uses the Box-Muller transform to produce a Gaussian distribution.  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if the standard deviation is negative.
  - **[NextInt(int)](RandomNumberGeneratorBase.NextInt(int).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int)')** `Method` Generates a pseudo-random integer between 0 (inclusive) and the specified maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxExclusive is less than or equal to 0.
  - **[NextInt(int, int)](RandomNumberGeneratorBase.NextInt(int,int).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int, int)')** `Method` Generates a pseudo-random integer between the specified minimum (inclusive) and maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxExclusive.
  - **[NextLong(long)](RandomNumberGeneratorBase.NextLong(long).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long)')** `Method` Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxExclusive is less than or equal to 0.
  - **[NextLong(long, long)](RandomNumberGeneratorBase.NextLong(long,long).md 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long, long)')** `Method` Generates a pseudo-random long integer between the specified minimum (inclusive) and maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxExclusive.
- **[IRandomNumberGenerator](IRandomNumberGenerator.md 'BeeneticToolkit.Random.IRandomNumberGenerator')** `Interface` Provides an interface for random number generation with a variety of methods  
  to produce random values of different numeric types and ranges.
  - **[NextBool()](IRandomNumberGenerator.NextBool().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextBool()')** `Method` Returns a random boolean value.
  - **[NextBool(float)](IRandomNumberGenerator.NextBool(float).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextBool(float)')** `Method` Returns a random boolean value with the probability of returning true specified by the input parameter.
  - **[NextDouble()](IRandomNumberGenerator.NextDouble().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble()')** `Method` Returns a non-negative random double.
  - **[NextDouble(double)](IRandomNumberGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble(double)')** `Method` Returns a non-negative random double that is less than the specified maximum.
  - **[NextDouble(double, double)](IRandomNumberGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble(double, double)')** `Method` Returns a random double within a specified range.
  - **[NextFloat()](IRandomNumberGenerator.NextFloat().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextFloat()')** `Method` Returns a non-negative random float.
  - **[NextFloat(float)](IRandomNumberGenerator.NextFloat(float).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextFloat(float)')** `Method` Returns a non-negative random float that is less than the specified maximum.
  - **[NextFloat(float, float)](IRandomNumberGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextFloat(float, float)')** `Method` Returns a random float within a specified range.
  - **[NextGaussian()](IRandomNumberGenerator.NextGaussian().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextGaussian()')** `Method` Returns a random double that follows a Gaussian (normal) distribution with mean 0 and standard deviation 1.
  - **[NextGaussian(double, double)](IRandomNumberGenerator.NextGaussian(double,double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextGaussian(double, double)')** `Method` Returns a random double that follows a Gaussian (normal) distribution with the specified mean and standard deviation.
  - **[NextInt(int)](IRandomNumberGenerator.NextInt(int).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextInt(int)')** `Method` Returns a non-negative random integer that is less than the specified maximum.
  - **[NextInt(int, int)](IRandomNumberGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextInt(int, int)')** `Method` Returns a random integer within a specified range.
  - **[NextLong(long)](IRandomNumberGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextLong(long)')** `Method` Returns a non-negative random long integer that is less than the specified maximum.
  - **[NextLong(long, long)](IRandomNumberGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextLong(long, long)')** `Method` Returns a random long integer within a specified range.