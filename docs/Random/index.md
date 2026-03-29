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
- **[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')** `Class` Represents an isolated collection of random number generators grouped under a single environment.  
    
  [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment') allows related RNG instances to be registered and retrieved  
              by either string key or [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') while keeping them scoped to a specific environment.  
    
  Each environment also exposes a convenience [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') generator,  
  which remains [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') until the first generator is registered  
  unless explicitly assigned later through [SetCurrent(string)](RngEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(string)') or  
  [SetCurrent(RngKey)](RngEnvironment.SetCurrent(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(BeeneticToolkit.Random.RngKey)').
  - **[RngEnvironment(string)](RngEnvironment.RngEnvironment(string).md 'BeeneticToolkit.Random.RngEnvironment.RngEnvironment(string)')** `Constructor` Initializes a new instance of the [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment') class.
  - **[Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current')** `Property` Gets the current random number generator for this environment.  
      
    This property is assigned to the first generator registered in the environment,  
    but may be reassigned through [SetCurrent(string)](RngEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(string)') or [SetCurrent(RngKey)](RngEnvironment.SetCurrent(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(BeeneticToolkit.Random.RngKey)').
  - **[Name](RngEnvironment.Name.md 'BeeneticToolkit.Random.RngEnvironment.Name')** `Property` Gets the name of the environment.
  - **[CreateAndRegister(RngKey, Nullable&lt;long&gt;, RngAlgorithm)](RngEnvironment.CreateAndRegister(RngKey,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(BeeneticToolkit.Random.RngKey, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)')** `Method` Creates a new random number generator, registers it under the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey'),  
    and returns the created instance.  
    If a generator was previously registered with the same key, it will be replaced.
  - **[CreateAndRegister(string, Nullable&lt;long&gt;, RngAlgorithm)](RngEnvironment.CreateAndRegister(string,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)')** `Method` Creates a new random number generator, registers it under the specified key,  
    and returns the created instance.  
    If a generator was previously registered with the same key, it will be replaced.
  - **[Get(RngKey)](RngEnvironment.Get(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.Get(BeeneticToolkit.Random.RngKey)')** `Method` Retrieves a random number generator previously registered under the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').
  - **[Get(string)](RngEnvironment.Get(string).md 'BeeneticToolkit.Random.RngEnvironment.Get(string)')** `Method` Retrieves a random number generator previously registered under the specified key.
  - **[Register(RngKey, RandomGenerator)](RngEnvironment.Register(RngKey,RandomGenerator).md 'BeeneticToolkit.Random.RngEnvironment.Register(BeeneticToolkit.Random.RngKey, BeeneticToolkit.Random.RandomGenerator)')** `Method` Registers a random number generator under a specific [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').  
    If a generator was previously registered with the same key, it will be replaced.
  - **[Register(string, RandomGenerator)](RngEnvironment.Register(string,RandomGenerator).md 'BeeneticToolkit.Random.RngEnvironment.Register(string, BeeneticToolkit.Random.RandomGenerator)')** `Method` Registers a random number generator under a specific string key.  
    If a generator was previously registered with the same key, it will be replaced.
  - **[SetCurrent(RngKey)](RngEnvironment.SetCurrent(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(BeeneticToolkit.Random.RngKey)')** `Method` Sets the [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') random number generator to the one  
    associated with the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').
  - **[SetCurrent(string)](RngEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(string)')** `Method` Sets the [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') random number generator to the one  
    associated with the specified key.
- **[RngFactory](RngFactory.md 'BeeneticToolkit.Random.RngFactory')** `Class` Provides factory methods for creating random number generators based on different algorithms.
  - **[GetGenerator()](RngFactory.GetGenerator().md 'BeeneticToolkit.Random.RngFactory.GetGenerator()')** `Method` Creates a random number generator using the default algorithm (Xorshift) without a specific seed.
  - **[GetGenerator(RngAlgorithm)](RngFactory.GetGenerator(RngAlgorithm).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm)')** `Method` Creates a random number generator using a specified algorithm without a specific seed.
  - **[GetGenerator(RngAlgorithm, Nullable&lt;long&gt;)](RngFactory.GetGenerator(RngAlgorithm,Nullable_long_).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm, System.Nullable<long>)')** `Method` Creates a random number generator using the specified algorithm and optional seed.
  - **[GetGenerator(Nullable&lt;long&gt;)](RngFactory.GetGenerator(Nullable_long_).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(System.Nullable<long>)')** `Method` Creates a random number generator using the default algorithm (Xorshift) with a specified seed.
- **[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')** `Class` Provides centralized access to a default global [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment').  
    
  [RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager') acts as a convenience facade for applications that want  
              a shared global RNG context identified by either a strongly typed [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole')  
              or a flexible string key.  
    
  For projects that require isolated RNG scopes, use [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment') directly.
  - **[Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current')** `Property` Gets the current global random number generator.  
      
    This property is initialized to [Default](RngRole.md#BeeneticToolkit.Random.RngRole.Default 'BeeneticToolkit.Random.RngRole.Default') during startup,  
    and is therefore guaranteed to be non-null.  
      
    It may be reassigned to any registered generator through  
    [SetCurrent(RngRole)](RngManager.SetCurrent(RngRole).md 'BeeneticToolkit.Random.RngManager.SetCurrent(BeeneticToolkit.Random.RngRole)') or [SetCurrent(string)](RngManager.SetCurrent(string).md 'BeeneticToolkit.Random.RngManager.SetCurrent(string)').
  - **[CreateAndRegister(RngRole, Nullable&lt;long&gt;, RngAlgorithm)](RngManager.CreateAndRegister(RngRole,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngManager.CreateAndRegister(BeeneticToolkit.Random.RngRole, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)')** `Method` Creates and registers a random number generator for the given role,  
    then returns it. Overwrites any existing generator for the role.
  - **[CreateAndRegister(string, Nullable&lt;long&gt;, RngAlgorithm)](RngManager.CreateAndRegister(string,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngManager.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)')** `Method` Creates and registers a random number generator for the given key,  
    then returns it. Overwrites existing entries.
  - **[Get(RngRole)](RngManager.Get(RngRole).md 'BeeneticToolkit.Random.RngManager.Get(BeeneticToolkit.Random.RngRole)')** `Method` Retrieves a random number generator previously registered under a specific [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole').
  - **[Get(string)](RngManager.Get(string).md 'BeeneticToolkit.Random.RngManager.Get(string)')** `Method` Retrieves a random number generator previously registered under a custom string key.
  - **[Register(RngRole, RandomGenerator)](RngManager.Register(RngRole,RandomGenerator).md 'BeeneticToolkit.Random.RngManager.Register(BeeneticToolkit.Random.RngRole, BeeneticToolkit.Random.RandomGenerator)')** `Method` Registers a random number generator under a specific [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole').  
    If a generator was previously registered for the same role, it will be replaced.
  - **[Register(string, RandomGenerator)](RngManager.Register(string,RandomGenerator).md 'BeeneticToolkit.Random.RngManager.Register(string, BeeneticToolkit.Random.RandomGenerator)')** `Method` Registers a random number generator under a custom string key.  
    This is useful for experimental, modding, or ad hoc scenarios  
    where predefined [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole') values are insufficient.  
    If a generator was previously registered with the same key, it will be replaced.
  - **[SetCurrent(RngRole)](RngManager.SetCurrent(RngRole).md 'BeeneticToolkit.Random.RngManager.SetCurrent(BeeneticToolkit.Random.RngRole)')** `Method` Sets the [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current') random number generator to the one  
    associated with the specified [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole').
  - **[SetCurrent(string)](RngManager.SetCurrent(string).md 'BeeneticToolkit.Random.RngManager.SetCurrent(string)')** `Method` Sets the [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current') random number generator to the one  
    associated with the specified custom string key.
- **[RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey')** `Struct` Represents a strongly typed key used to identify a random number generator  
  within an [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment').
  - **[RngKey(string)](RngKey.RngKey(string).md 'BeeneticToolkit.Random.RngKey.RngKey(string)')** `Constructor` Initializes a new instance of the [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') struct.
  - **[IsEmpty](RngKey.IsEmpty.md 'BeeneticToolkit.Random.RngKey.IsEmpty')** `Property` Gets a value indicating whether this key is uninitialized or empty.
  - **[Value](RngKey.Value.md 'BeeneticToolkit.Random.RngKey.Value')** `Property` Gets the underlying string value of the key.
  - **[Equals(RngKey)](RngKey.Equals(RngKey).md 'BeeneticToolkit.Random.RngKey.Equals(BeeneticToolkit.Random.RngKey)')** `Method` Determines whether the current key is equal to another [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').
  - **[Equals(object)](RngKey.Equals(object).md 'BeeneticToolkit.Random.RngKey.Equals(object)')** `Method` Determines whether the current key is equal to the specified object.
  - **[GetHashCode()](RngKey.GetHashCode().md 'BeeneticToolkit.Random.RngKey.GetHashCode()')** `Method` Returns the hash code for this key.
  - **[ToString()](RngKey.ToString().md 'BeeneticToolkit.Random.RngKey.ToString()')** `Method` Returns the string representation of the key.
  - **[operator ==(RngKey, RngKey)](RngKey.operator(RngKey,RngKey).md 'BeeneticToolkit.Random.RngKey.op_Equality(BeeneticToolkit.Random.RngKey, BeeneticToolkit.Random.RngKey)')** `Operator` Determines whether two [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') values are equal.
  - **[explicit operator RngKey(string)](RngKey.explicitoperatorRngKey(string).md 'BeeneticToolkit.Random.RngKey.op_Explicit BeeneticToolkit.Random.RngKey(string)')** `Operator` Converts a string value to an [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').
  - **[implicit operator string(RngKey)](RngKey.implicitoperatorstring(RngKey).md 'BeeneticToolkit.Random.RngKey.op_Implicit string(BeeneticToolkit.Random.RngKey)')** `Operator` Converts an [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') to its underlying string value.
  - **[operator !=(RngKey, RngKey)](RngKey.operator!(RngKey,RngKey).md 'BeeneticToolkit.Random.RngKey.op_Inequality(BeeneticToolkit.Random.RngKey, BeeneticToolkit.Random.RngKey)')** `Operator` Determines whether two [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') values are not equal.
- **[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')** `Interface` Defines the contract for random number generators that can produce values  
  across multiple primitive types and distributions.
  - **[NextBool()](IRandomGenerator.NextBool().md 'BeeneticToolkit.Random.IRandomGenerator.NextBool()')** `Method` Generates a random boolean value.
  - **[NextBool(float)](IRandomGenerator.NextBool(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextBool(float)')** `Method` Generates a random boolean value using the specified probability of returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').
  - **[NextBytes()](IRandomGenerator.NextBytes().md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes()')** `Method` Generates a random byte array with the default length.
  - **[NextBytes(int)](IRandomGenerator.NextBytes(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int)')** `Method` Generates a random byte array of the specified length.
  - **[NextBytes(int, byte, byte)](IRandomGenerator.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int, byte, byte)')** `Method` Generates a random byte array of the specified length, with each byte  
    falling within the specified range.
  - **[NextDouble()](IRandomGenerator.NextDouble().md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble()')** `Method` Generates a non-negative random double.
  - **[NextDouble(double)](IRandomGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double)')** `Method` Generates a non-negative random double that is less than or equal to the specified maximum.
  - **[NextDouble(double, double)](IRandomGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double, double)')** `Method` Generates a random double within the specified range.
  - **[NextFloat()](IRandomGenerator.NextFloat().md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat()')** `Method` Generates a non-negative random float.
  - **[NextFloat(float)](IRandomGenerator.NextFloat(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float)')** `Method` Generates a non-negative random float that is less than or equal to the specified maximum.
  - **[NextFloat(float, float)](IRandomGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float, float)')** `Method` Generates a random float within the specified range.
  - **[NextInt()](IRandomGenerator.NextInt().md 'BeeneticToolkit.Random.IRandomGenerator.NextInt()')** `Method` Generates a non-negative random integer.
  - **[NextInt(int)](IRandomGenerator.NextInt(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int)')** `Method` Generates a non-negative random integer that is less than the specified maximum.
  - **[NextInt(int, int)](IRandomGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int, int)')** `Method` Generates a random integer within the specified range.
  - **[NextLong()](IRandomGenerator.NextLong().md 'BeeneticToolkit.Random.IRandomGenerator.NextLong()')** `Method` Generates a non-negative random long integer.
  - **[NextLong(long)](IRandomGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long)')** `Method` Generates a non-negative random long integer that is less than the specified maximum.
  - **[NextLong(long, long)](IRandomGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long)')** `Method` Generates a random long integer within the specified range.
  - **[NextNormal()](IRandomGenerator.NextNormal().md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal()')** `Method` Generates a random double from the standard normal distribution.
  - **[NextNormal(double, double)](IRandomGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal(double, double)')** `Method` Generates a random double from a normal distribution with the specified mean and standard deviation.
- **[RngAlgorithm](RngAlgorithm.md 'BeeneticToolkit.Random.RngAlgorithm')** `Enum` Defines the algorithms available for random number generation.
  - **[CombinedLCG](RngAlgorithm.md#BeeneticToolkit.Random.RngAlgorithm.CombinedLCG 'BeeneticToolkit.Random.RngAlgorithm.CombinedLCG')** `Field` Represents the Combined Linear Congruential Generator algorithm.
  - **[MiddleSquare](RngAlgorithm.md#BeeneticToolkit.Random.RngAlgorithm.MiddleSquare 'BeeneticToolkit.Random.RngAlgorithm.MiddleSquare')** `Field` Represents the Middle Square Weyl algorithm.
  - **[Xorshift](RngAlgorithm.md#BeeneticToolkit.Random.RngAlgorithm.Xorshift 'BeeneticToolkit.Random.RngAlgorithm.Xorshift')** `Field` Represents the Xorshift algorithm.
- **[RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole')** `Enum` Represents the roles or contexts in which a random number generator can be used.  
  This provides type-safe identifiers for registering and retrieving  
  random number generators via the [RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager').
  - **[AI](RngRole.md#BeeneticToolkit.Random.RngRole.AI 'BeeneticToolkit.Random.RngRole.AI')** `Field` A generator dedicated to AI-related randomness,  
    such as decision-making, behavior trees, or procedural logic.
  - **[Default](RngRole.md#BeeneticToolkit.Random.RngRole.Default 'BeeneticToolkit.Random.RngRole.Default')** `Field` The default global random number generator role.
  - **[Gameplay](RngRole.md#BeeneticToolkit.Random.RngRole.Gameplay 'BeeneticToolkit.Random.RngRole.Gameplay')** `Field` A generator dedicated to core gameplay randomness,  
    such as combat rolls, item drops, or level generation.
  - **[Testing](RngRole.md#BeeneticToolkit.Random.RngRole.Testing 'BeeneticToolkit.Random.RngRole.Testing')** `Field` A generator reserved for testing or debugging scenarios,  
    where predictable or isolated random behavior is desired.

<a name='BeeneticToolkit.Random.Utilities'></a>

## BeeneticToolkit.Random.Utilities Namespace
- **[RandomExtensions](RandomExtensions.md 'BeeneticToolkit.Random.Utilities.RandomExtensions')** `Class` Provides extension methods for randomizing collections, enhancing the standard RandomGenerator class functionality.
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
  - **[TryRandomChoice&lt;T&gt;(IEnumerable&lt;T&gt;, T, RandomGenerator)](RandomSelectors.TryRandomChoice_T_(IEnumerable_T_,T,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice<T>(System.Collections.Generic.IEnumerable<T>, T, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random element from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence without throwing exceptions.
  - **[TryRandomChoice&lt;T&gt;(IList&lt;T&gt;, T, RandomGenerator)](RandomSelectors.TryRandomChoice_T_(IList_T_,T,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice<T>(System.Collections.Generic.IList<T>, T, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random element from a list without throwing exceptions.
  - **[TryRandomChoiceWithExclusion&lt;T&gt;(IEnumerable&lt;T&gt;, Func&lt;T,bool&gt;, T, RandomGenerator)](RandomSelectors.TryRandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,T,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, T, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random element from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence, excluding elements that match a specified predicate, without throwing exceptions.
  - **[TryRandomChoiceWithExclusion&lt;T&gt;(IList&lt;T&gt;, Func&lt;T,bool&gt;, T, RandomGenerator)](RandomSelectors.TryRandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,T,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, T, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random element from a list, excluding elements that match a specified predicate, without throwing exceptions.
  - **[TryRandomSubset&lt;T&gt;(IEnumerable&lt;T&gt;, int, List&lt;T&gt;, RandomGenerator)](RandomSelectors.TryRandomSubset_T_(IEnumerable_T_,int,List_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, System.Collections.Generic.List<T>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random subset of a specified size from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence without throwing exceptions.
  - **[TryRandomSubset&lt;T&gt;(IList&lt;T&gt;, int, List&lt;T&gt;, RandomGenerator)](RandomSelectors.TryRandomSubset_T_(IList_T_,int,List_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset<T>(System.Collections.Generic.IList<T>, int, System.Collections.Generic.List<T>, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random subset of a specified size from a list without throwing exceptions.
  - **[TryRandomWeightedChoice&lt;T&gt;(Dictionary&lt;T,double&gt;, T, RandomGenerator)](RandomSelectors.TryRandomWeightedChoice_T_(Dictionary_T,double_,T,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, T, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random element from a dictionary, with each element's likelihood determined by its associated weight, without throwing exceptions.
  - **[TryRandomWeightedChoice&lt;T&gt;(IEnumerable&lt;T&gt;, IList&lt;double&gt;, T, RandomGenerator)](RandomSelectors.TryRandomWeightedChoice_T_(IEnumerable_T_,IList_double_,T,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, T, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random element from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence, with each element's likelihood determined by a corresponding weight, without throwing exceptions.
  - **[TryRandomWeightedChoice&lt;T&gt;(IList&lt;T&gt;, IList&lt;double&gt;, T, RandomGenerator)](RandomSelectors.TryRandomWeightedChoice_T_(IList_T_,IList_double_,T,RandomGenerator).md 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, T, BeeneticToolkit.Random.RandomGenerator)')** `Method` Attempts to select a random element from a list, with each element's likelihood determined by a corresponding weight, without throwing exceptions.
- **[RandomUtils](RandomUtils.md 'BeeneticToolkit.Random.Utilities.RandomUtils')** `Class` Provides utility methods for the RandomGenerator class.
  - **[DeriveSeed(long, string)](RandomUtils.DeriveSeed(long,string).md 'BeeneticToolkit.Random.Utilities.RandomUtils.DeriveSeed(long, string)')** `Method` Derives a deterministic seed from a root seed and a system key.  
    Ensures same root+key combo always yields the same result.