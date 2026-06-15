using System;

namespace BeeneticToolkit.Random.Probability {

    /// <summary>
    /// Convenience extension methods on <see cref="RandomGenerator"/> for rolling dice, so the source of
    /// randomness stays explicit at the call site.
    /// </summary>
    public static class DiceExtensions {

        /// <summary>Parses dice notation and rolls it, returning the total including any modifier.</summary>
        /// <param name="random">The generator to roll with.</param>
        /// <param name="notation">A dice expression such as <c>"2d6+1"</c> or <c>"d20"</c>.</param>
        /// <returns>The total of the roll.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="notation"/> is null.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="notation"/> is not valid dice notation.</exception>
        public static int Roll(this RandomGenerator random, string notation) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            return DiceRoll.Parse(notation).Roll(random);
        }

        /// <summary>Rolls a pre-parsed dice expression, returning the total including any modifier.</summary>
        /// <param name="random">The generator to roll with.</param>
        /// <param name="dice">The dice expression to roll.</param>
        /// <returns>The total of the roll.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public static int Roll(this RandomGenerator random, DiceRoll dice) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            return dice.Roll(random);
        }
    }
}
