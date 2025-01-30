#### [Random](index.md 'index')

## Random Assembly
### Namespaces

<a name='BeeneticToolkit.Random'></a>

## BeeneticToolkit.Random Namespace

The [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random') namespace provides utilities for generating random numbers,  
selecting random elements from collections, and working with various pseudorandom number generation algorithms.
- **[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')** `Class` Serves as the base class for random number generators, providing common functionality for seed management.  
  This abstract class defines the basic structure and seeding mechanism that derived random number generators will use.
  - **[RandomGenerator(long)](RandomGenerator.RandomGenerator(long).md 'BeeneticToolkit.Random.RandomGenerator.RandomGenerator(long)')** `Constructor` Initializes a new instance of the random number generator with the specified seed.
  - **[CalculatedNextDouble](RandomGenerator.CalculatedNextDouble.md 'BeeneticToolkit.Random.RandomGenerator.CalculatedNextDouble')** `Property` Gets a calculated random double value based on the next number in the random sequence.
  - **[CalculatedNextFloat](RandomGenerator.CalculatedNextFloat.md 'BeeneticToolkit.Random.RandomGenerator.CalculatedNextFloat')** `Property` Gets a calculated random float value based on the next number in the random sequence.
  - **[CalculatedNextInt](RandomGenerator.CalculatedNextInt.md 'BeeneticToolkit.Random.RandomGenerator.CalculatedNextInt')** `Property` Gets a calculated random integer value based on the next number in the random sequence.
  - **[Seed](RandomGenerator.Seed.md 'BeeneticToolkit.Random.RandomGenerator.Seed')** `Property` Gets the seed value used for random number generation.
  - **[InitializeRng()](RandomGenerator.InitializeRng().md 'BeeneticToolkit.Random.RandomGenerator.InitializeRng()')** `Method` Initializes the random number generator with the given seed.  
    Override this method in derived classes to set up the random number generator.
  - **[Next()](RandomGenerator.Next().md 'BeeneticToolkit.Random.RandomGenerator.Next()')** `Method` When overridden in a derived class, generates the next random number in the sequence.
  - **[NextBool()](RandomGenerator.NextBool().md 'BeeneticToolkit.Random.RandomGenerator.NextBool()')** `Method` Returns a random boolean value by equally considering the true and false outcomes.
  - **[NextBool(float)](RandomGenerator.NextBool(float).md 'BeeneticToolkit.Random.RandomGenerator.NextBool(float)')** `Method` Returns a random boolean value with the probability of returning true specified by the input parameter.
  - **[NextBytes()](RandomGenerator.NextBytes().md 'BeeneticToolkit.Random.RandomGenerator.NextBytes()')** `Method` Generates a random byte array with a default length.
  - **[NextBytes(int)](RandomGenerator.NextBytes(int).md 'BeeneticToolkit.Random.RandomGenerator.NextBytes(int)')** `Method` Generates a random byte array of a specified length.
  - **[NextBytes(int, byte, byte)](RandomGenerator.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.RandomGenerator.NextBytes(int, byte, byte)')** `Method` Generates a random byte array of a specified length, with each byte within a specified range.
  - **[NextDouble()](RandomGenerator.NextDouble().md 'BeeneticToolkit.Random.RandomGenerator.NextDouble()')** `Method` Calculates the next double value in the random sequence.
  - **[NextDouble(double)](RandomGenerator.NextDouble(double).md 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double)')** `Method` Generates a pseudo-random double between 0 (inclusive) and the specified maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxInclusive is less than or equal to 0.
  - **[NextDouble(double, double)](RandomGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double)')** `Method` Generates a pseudo-random double between the specified minimum (inclusive) and maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxInclusive.
  - **[NextFloat()](RandomGenerator.NextFloat().md 'BeeneticToolkit.Random.RandomGenerator.NextFloat()')** `Method` Calculates the next float value in the random sequence.
  - **[NextFloat(float)](RandomGenerator.NextFloat(float).md 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float)')** `Method` Generates a pseudo-random float between 0 (inclusive) and the specified maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxInclusive is less than or equal to 0.
  - **[NextFloat(float, float)](RandomGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float)')** `Method` Generates a pseudo-random float between the specified minimum (inclusive) and maximum (inclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxInclusive.
  - **[NextInt()](RandomGenerator.NextInt().md 'BeeneticToolkit.Random.RandomGenerator.NextInt()')** `Method` Generates a non-negative random integer.
  - **[NextInt(int)](RandomGenerator.NextInt(int).md 'BeeneticToolkit.Random.RandomGenerator.NextInt(int)')** `Method` Generates a pseudo-random integer between 0 (inclusive) and the specified maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxExclusive is less than or equal to 0.
  - **[NextInt(int, int)](RandomGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int)')** `Method` Generates a pseudo-random integer between the specified minimum (inclusive) and maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxExclusive.
  - **[NextLong()](RandomGenerator.NextLong().md 'BeeneticToolkit.Random.RandomGenerator.NextLong()')** `Method` Generates a non-negative random long integer.
  - **[NextLong(long)](RandomGenerator.NextLong(long).md 'BeeneticToolkit.Random.RandomGenerator.NextLong(long)')** `Method` Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if maxExclusive is less than or equal to 0.
  - **[NextLong(long, long)](RandomGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long)')** `Method` Generates a pseudo-random long integer between the specified minimum (inclusive) and maximum (exclusive).  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if minInclusive is greater than or equal to maxExclusive.
  - **[NextNormal()](RandomGenerator.NextNormal().md 'BeeneticToolkit.Random.RandomGenerator.NextNormal()')** `Method` Generates a normally distributed random number with a default mean of 0.0 and standard deviation of 1.0.  
    This method is an overload of the NextNormal method that uses default parameters to produce a standard normal distribution.
  - **[NextNormal(double, double)](RandomGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.RandomGenerator.NextNormal(double, double)')** `Method` Generates a normally distributed random number with a specified mean and standard deviation.  
    This method uses the Box-Muller transform to produce a normal distribution.  
    It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if the standard deviation is negative.
- **[RngFactory](RngFactory.md 'BeeneticToolkit.Random.RngFactory')** `Class` Provides factory methods for creating random number generators based on different algorithms.
  - **[GetGenerator()](RngFactory.GetGenerator().md 'BeeneticToolkit.Random.RngFactory.GetGenerator()')** `Method` Creates a random number generator using the default algorithm (Xorshift) without a specific seed.
  - **[GetGenerator(RngAlgorithm)](RngFactory.GetGenerator(RngAlgorithm).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm)')** `Method` Creates a random number generator using a specified algorithm without a specific seed.
  - **[GetGenerator(RngAlgorithm, Nullable&lt;long&gt;)](RngFactory.GetGenerator(RngAlgorithm,Nullable_long_).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm, System.Nullable<long>)')** `Method` Creates a random number generator using a specified algorithm and seed.
  - **[GetGenerator(Nullable&lt;long&gt;)](RngFactory.GetGenerator(Nullable_long_).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(System.Nullable<long>)')** `Method` Creates a random number generator using the default algorithm (Xorshift) with a specified seed.
- **[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')** `Class` Manages a global instance of a random number generator, providing centralized access  
  and control across the application.
  - **[Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current')** `Property` Gets or sets the global random number generator instance.
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

<a name='BeeneticToolkit.Random.Utilities'></a>

## BeeneticToolkit.Random.Utilities Namespace
- **[RandomExtensions](RandomExtensions.md 'BeeneticToolkit.Random.Utilities.RandomExtensions')** `Class` Provides extension methods for randomizing collections, enhancing the standard Random class functionality.
  - **[Shuffle&lt;T&gt;(this IEnumerable&lt;T&gt;, RandomGenerator)](RandomExtensions.Shuffle_T_(thisIEnumerable_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle<T>(this System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Shuffles elements in a collection using a specified or default random number generator.
- **[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')** `Class` Provides utility methods for random operations, such as selecting random elements from collections.
  - **[RandomChoice&lt;T&gt;(IEnumerable&lt;T&gt;, RandomGenerator)](RandomSelectors.RandomChoice_T_(IEnumerable_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice<T>(System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random element from an IEnumerable sequence.
  - **[RandomChoice&lt;T&gt;(IList&lt;T&gt;, RandomGenerator)](RandomSelectors.RandomChoice_T_(IList_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice<T>(System.Collections.Generic.IList<T>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random element from a list.
  - **[RandomChoiceWithExclusion&lt;T&gt;(IEnumerable&lt;T&gt;, Func&lt;T,bool&gt;, RandomGenerator)](RandomSelectors.RandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random element from an IEnumerable sequence, excluding elements that match a specified predicate.
  - **[RandomChoiceWithExclusion&lt;T&gt;(IList&lt;T&gt;, Func&lt;T,bool&gt;, RandomGenerator)](RandomSelectors.RandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random element from a list, excluding elements that match a specified predicate.
  - **[RandomSubset&lt;T&gt;(IEnumerable&lt;T&gt;, int, RandomGenerator)](RandomSelectors.RandomSubset_T_(IEnumerable_T_,int,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random subset of a specified size from an IEnumerable sequence.
  - **[RandomSubset&lt;T&gt;(IList&lt;T&gt;, int, RandomGenerator)](RandomSelectors.RandomSubset_T_(IList_T_,int,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IList<T>, int, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random subset of a specified size from a list.
  - **[RandomWeightedChoice&lt;T&gt;(Dictionary&lt;T,double&gt;, RandomGenerator)](RandomSelectors.RandomWeightedChoice_T_(Dictionary_T,double_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random element from a dictionary, with each element's likelihood of being chosen  
    determined by its associated weight.
  - **[RandomWeightedChoice&lt;T&gt;(IEnumerable&lt;T&gt;, IList&lt;double&gt;, RandomGenerator)](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random element from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence, with each element's likelihood of being chosen  
    determined by its corresponding weight in a separate weight list.
  - **[RandomWeightedChoice&lt;T&gt;(IList&lt;T&gt;, IList&lt;double&gt;, RandomGenerator)](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Selects a random element from a list, with each element's likelihood of being chosen  
    determined by its corresponding weight in a separate weight list.