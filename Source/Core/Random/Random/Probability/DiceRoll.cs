using System;

namespace BeeneticToolkit.Random.Probability {

    /// <summary>
    /// A parsed tabletop-style dice expression in <c>NdS±M</c> notation — <see cref="Count"/> dice of
    /// <see cref="Sides"/> sides each, plus a flat <see cref="Modifier"/> (for example <c>"2d6+1"</c>,
    /// <c>"d20"</c>, or <c>"4d8-2"</c>). Roll it against a seeded generator for reproducible results.
    /// </summary>
    public readonly struct DiceRoll : IEquatable<DiceRoll> {

        /// <summary>Gets the number of dice rolled.</summary>
        public int Count { get; }

        /// <summary>Gets the number of sides on each die.</summary>
        public int Sides { get; }

        /// <summary>Gets the flat modifier added to the sum of the dice (may be negative or zero).</summary>
        public int Modifier { get; }

        /// <summary>Creates a dice expression.</summary>
        /// <param name="count">The number of dice. Must be greater than zero.</param>
        /// <param name="sides">The number of sides on each die. Must be greater than zero.</param>
        /// <param name="modifier">A flat amount added to the total (defaults to zero).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> or <paramref name="sides"/> is not greater than zero.</exception>
        public DiceRoll(int count, int sides, int modifier = 0) {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "The number of dice must be greater than zero.");
            if (sides <= 0)
                throw new ArgumentOutOfRangeException(nameof(sides), "The number of sides must be greater than zero.");

            Count = count;
            Sides = sides;
            Modifier = modifier;
        }

        /// <summary>Gets the smallest total this expression can roll (all ones, plus the modifier).</summary>
        public int Min => Count + Modifier;

        /// <summary>Gets the largest total this expression can roll (all maximum faces, plus the modifier).</summary>
        public int Max => Count * Sides + Modifier;

        /// <summary>Rolls the dice and returns the summed total including the modifier.</summary>
        /// <param name="random">The generator to roll with.</param>
        /// <returns>The total of all dice plus the modifier.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public int Roll(RandomGenerator random) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            int total = Modifier;
            for (int i = 0; i < Count; i++)
                total += random.NextInt(1, Sides + 1);

            return total;
        }

        /// <summary>Rolls the dice and returns each individual die result (excluding the modifier).</summary>
        /// <param name="random">The generator to roll with.</param>
        /// <returns>An array of length <see cref="Count"/>, each value in <c>[1, Sides]</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public int[] RollEach(RandomGenerator random) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            int[] rolls = new int[Count];
            for (int i = 0; i < Count; i++)
                rolls[i] = random.NextInt(1, Sides + 1);

            return rolls;
        }

        /// <summary>Parses a dice expression in <c>NdS±M</c> notation. The count and modifier are optional.</summary>
        /// <param name="notation">The expression, for example <c>"2d6+1"</c>, <c>"d20"</c>, or <c>"4d8 - 2"</c>. Case-insensitive; whitespace is ignored.</param>
        /// <returns>The parsed <see cref="DiceRoll"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="notation"/> is null.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="notation"/> is not valid dice notation.</exception>
        public static DiceRoll Parse(string notation) {
            if (notation == null)
                throw new ArgumentNullException(nameof(notation));
            if (!TryParse(notation, out DiceRoll result))
                throw new FormatException($"'{notation}' is not valid dice notation (expected something like \"2d6+1\").");

            return result;
        }

        /// <summary>Attempts to parse a dice expression in <c>NdS±M</c> notation without throwing.</summary>
        /// <param name="notation">The expression to parse. Case-insensitive; whitespace is ignored.</param>
        /// <param name="result">When this method returns true, the parsed expression; otherwise the default value.</param>
        /// <returns><c>true</c> if the expression was parsed; otherwise <c>false</c>.</returns>
        public static bool TryParse(string notation, out DiceRoll result) {
            result = default;
            if (string.IsNullOrWhiteSpace(notation))
                return false;

            // Strip all whitespace so "4d8 - 2" parses the same as "4d8-2".
            Span<char> buffer = stackalloc char[notation.Length];
            int len = 0;
            foreach (char c in notation)
                if (!char.IsWhiteSpace(c))
                    buffer[len++] = c;
            ReadOnlySpan<char> s = buffer.Slice(0, len);

            int dIndex = -1;
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == 'd' || s[i] == 'D') {
                    dIndex = i;
                    break;
                }
            }
            if (dIndex < 0)
                return false;

            // Count: everything before 'd'. Empty means a single die.
            ReadOnlySpan<char> countText = s.Slice(0, dIndex);
            int count = 1;
            if (countText.Length > 0 && !TryParsePositive(countText, out count))
                return false;

            // Sides and an optional signed modifier follow the 'd'.
            ReadOnlySpan<char> rest = s.Slice(dIndex + 1);
            int signIndex = -1;
            for (int i = 0; i < rest.Length; i++) {
                if (rest[i] == '+' || rest[i] == '-') {
                    signIndex = i;
                    break;
                }
            }

            ReadOnlySpan<char> sidesText = signIndex < 0 ? rest : rest.Slice(0, signIndex);
            if (!TryParsePositive(sidesText, out int sides))
                return false;

            int modifier = 0;
            if (signIndex >= 0) {
                ReadOnlySpan<char> modText = rest.Slice(signIndex + 1);
                if (!TryParsePositive(modText, out int magnitude))
                    return false;
                modifier = rest[signIndex] == '-' ? -magnitude : magnitude;
            }

            result = new DiceRoll(count, sides, modifier);
            return true;
        }

        private static bool TryParsePositive(ReadOnlySpan<char> text, out int value) {
            value = 0;
            if (text.Length == 0)
                return false;

            long acc = 0;
            foreach (char c in text) {
                if (c < '0' || c > '9')
                    return false;
                acc = acc * 10 + (c - '0');
                if (acc > int.MaxValue)
                    return false;
            }

            if (acc <= 0)
                return false;

            value = (int)acc;
            return true;
        }

        /// <summary>Returns the canonical <c>NdS±M</c> string for this expression.</summary>
        public override string ToString() {
            if (Modifier == 0)
                return $"{Count}d{Sides}";
            return Modifier > 0 ? $"{Count}d{Sides}+{Modifier}" : $"{Count}d{Sides}{Modifier}";
        }

        /// <inheritdoc/>
        public bool Equals(DiceRoll other) => Count == other.Count && Sides == other.Sides && Modifier == other.Modifier;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DiceRoll other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() {
            unchecked {
                int hash = 17;
                hash = hash * 31 + Count;
                hash = hash * 31 + Sides;
                hash = hash * 31 + Modifier;
                return hash;
            }
        }

        /// <summary>Determines whether two dice expressions are equal.</summary>
        public static bool operator ==(DiceRoll left, DiceRoll right) => left.Equals(right);

        /// <summary>Determines whether two dice expressions are not equal.</summary>
        public static bool operator !=(DiceRoll left, DiceRoll right) => !left.Equals(right);
    }
}
