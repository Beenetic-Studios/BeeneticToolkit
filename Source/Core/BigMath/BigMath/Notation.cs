using System;
using System.Globalization;

namespace BeeneticToolkit.BigMath {

    /// <summary>
    /// Renders a <see cref="BigDouble"/> as a display string. Notations are pluggable, mirroring how the toolkit's
    /// random generators expose swappable algorithms: pick one per call, or set an app-wide default via
    /// <see cref="Notation.Default"/>.
    /// </summary>
    public interface INotation {

        /// <summary>Formats <paramref name="value"/> using <paramref name="decimals"/> fractional digits.</summary>
        string Format(BigDouble value, int decimals);
    }

    /// <summary>
    /// Shared base that handles the special cases (NaN, infinities, zero) and the sign, delegating the positive,
    /// finite, non-zero magnitude to <see cref="FormatMagnitude"/>.
    /// </summary>
    public abstract class NotationBase : INotation {

        /// <inheritdoc/>
        public string Format(BigDouble value, int decimals) {
            if (decimals < 0) decimals = 0;
            if (value.IsNaN) return "NaN";
            if (value.IsInfinity) return value.Sign < 0 ? "-Infinity" : "Infinity";
            if (value.IsZero) return FormatZero(decimals);
            string sign = value.Mantissa < 0.0 ? "-" : string.Empty;
            return sign + FormatMagnitude(value.Abs(), decimals);
        }

        /// <summary>Formats the string for zero. Defaults to a plain zero with the requested decimals.</summary>
        protected virtual string FormatZero(int decimals) =>
            (0.0).ToString("F" + decimals, CultureInfo.InvariantCulture);

        /// <summary>Formats a strictly positive, finite, non-zero magnitude.</summary>
        protected abstract string FormatMagnitude(BigDouble value, int decimals);

        /// <summary>10^n for the small non-negative shifts (0, 1, 2) used when re-basing a mantissa.</summary>
        private protected static double Pow10Int(int n) => n switch {
            0 => 1.0,
            1 => 10.0,
            2 => 100.0,
            _ => Math.Pow(10.0, n),
        };
    }

    /// <summary>Scientific notation, e.g. <c>1.50e12</c>.</summary>
    public sealed class ScientificNotation : NotationBase {

        /// <inheritdoc/>
        protected override string FormatMagnitude(BigDouble value, int decimals) {
            string mantissa = value.Mantissa.ToString("F" + decimals, CultureInfo.InvariantCulture);
            long exponent = (long)value.Exponent;
            return mantissa + "e" + exponent.ToString(CultureInfo.InvariantCulture);
        }
    }

    /// <summary>Engineering notation: mantissa in [1, 1000) with an exponent that is a multiple of three, e.g. <c>150e9</c>.</summary>
    public sealed class EngineeringNotation : NotationBase {

        /// <inheritdoc/>
        protected override string FormatMagnitude(BigDouble value, int decimals) {
            long exponent = (long)value.Exponent;
            long engExponent = (long)(Math.Floor(exponent / 3.0) * 3.0);
            int shift = (int)(exponent - engExponent); // 0, 1, or 2
            double mantissa = value.Mantissa * Pow10Int(shift);
            return mantissa.ToString("F" + decimals, CultureInfo.InvariantCulture)
                + "e" + engExponent.ToString(CultureInfo.InvariantCulture);
        }
    }

    /// <summary>
    /// Standard abbreviated notation: <c>K, M, B, T</c> for 10^3&#8230;10^12, then the idle-game convention of
    /// two-letter suffixes (<c>aa, ab, &#8230; az, ba, &#8230; zz</c>), then three letters, and so on. The suffix
    /// set is swappable via <see cref="ISuffixProvider"/> so games can supply their own flavor.
    /// </summary>
    public sealed class StandardNotation : NotationBase {

        private readonly ISuffixProvider _suffixes;

        /// <summary>Creates a standard notation using the given suffix provider (or the built-in default).</summary>
        public StandardNotation(ISuffixProvider? suffixes = null) {
            _suffixes = suffixes ?? DefaultSuffixProvider.Instance;
        }

        /// <inheritdoc/>
        protected override string FormatMagnitude(BigDouble value, int decimals) {
            long exponent = (long)value.Exponent;
            long tier = (long)Math.Floor(exponent / 3.0);

            // Below 1000 (or fractional): no suffix, show the number directly.
            if (tier <= 0) {
                return value.ToDouble().ToString("F" + decimals, CultureInfo.InvariantCulture);
            }

            int shift = (int)(exponent - 3 * tier); // 0, 1, or 2
            double displayMantissa = value.Mantissa * Pow10Int(shift); // [1, 1000)
            return displayMantissa.ToString("F" + decimals, CultureInfo.InvariantCulture) + _suffixes.GetSuffix(tier);
        }
    }

    /// <summary>Standard-abbreviated below a switch exponent, then scientific for larger magnitudes.</summary>
    public sealed class MixedScientificNotation : INotation {

        private readonly StandardNotation _standard;
        private readonly ScientificNotation _scientific = new ScientificNotation();
        private readonly double _switchExponent;

        /// <summary>
        /// Creates a mixed notation. Values with an exponent below <paramref name="switchExponent"/> use standard
        /// abbreviations; larger values use scientific notation.
        /// </summary>
        public MixedScientificNotation(double switchExponent = 33.0, ISuffixProvider? suffixes = null) {
            _switchExponent = switchExponent;
            _standard = new StandardNotation(suffixes);
        }

        /// <inheritdoc/>
        public string Format(BigDouble value, int decimals) {
            if (value.IsFinite && !value.IsZero && value.Exponent >= _switchExponent) {
                return _scientific.Format(value, decimals);
            }
            return _standard.Format(value, decimals);
        }
    }

    /// <summary>Supplies the suffix for a given magnitude tier (<c>floor(exponent / 3)</c>).</summary>
    public interface ISuffixProvider {

        /// <summary>Returns the suffix for the given tier. Tier 0 (values below 1000) returns an empty string.</summary>
        string GetSuffix(long tier);
    }

    /// <summary>
    /// The built-in suffix set: <c>K, M, B, T</c> for tiers 1&#8211;4, then a growing letter sequence
    /// (<c>aa, ab, &#8230; zz, aaa, &#8230;</c>) for tier 5 and beyond.
    /// </summary>
    public sealed class DefaultSuffixProvider : ISuffixProvider {

        /// <summary>Shared instance.</summary>
        public static readonly DefaultSuffixProvider Instance = new DefaultSuffixProvider();

        private static readonly string[] ShortSuffixes = { "K", "M", "B", "T" };

        /// <inheritdoc/>
        public string GetSuffix(long tier) {
            if (tier <= 0) return string.Empty;
            if (tier <= 4) return ShortSuffixes[tier - 1];

            // Letter sequence, zero-indexed from the first two-letter suffix "aa".
            long index = tier - 5;
            int letters = 2;
            long block = 26L * 26L;
            while (index >= block) {
                index -= block;
                letters++;
                block *= 26L;
            }

            char[] chars = new char[letters];
            for (int i = letters - 1; i >= 0; i--) {
                chars[i] = (char)('a' + (int)(index % 26));
                index /= 26;
            }
            return new string(chars);
        }
    }

    /// <summary>
    /// Short-scale named suffixes following the idle-game convention: <c>K, M, B, T</c> then
    /// <c>Qa, Qi, Sx, Sp, Oc, No, Dc</c> (quadrillion&#8230;decillion) and onward algorithmically
    /// (<c>UDc, DDc, &#8230;, Vg, Tg, &#8230;, Ce</c>) up to&#8212;but excluding&#8212;millinillion. Tiers past the named
    /// range, or past an optional cap, defer to a fallback provider (the alphabetic
    /// <see cref="DefaultSuffixProvider"/> by default), so nothing ever renders suffix-less.
    /// </summary>
    public sealed class ShortScaleSuffixProvider : ISuffixProvider {

        /// <summary>Shared instance: the full algorithmic range, falling back to the alphabetic default beyond it.</summary>
        public static readonly ShortScaleSuffixProvider Instance = new ShortScaleSuffixProvider();

        // Tiers 1-10 get bespoke abbreviations (K, then million..nonillion). Decillion (tier 11) and beyond are
        // composed from the ones/tens/hundreds tables, indexed by the "illion number" n = tier - 1.
        private static readonly string[] FirstTiers =
            { "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No" };

        private static readonly string[] Ones =
            { "", "U", "D", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No" };
        private static readonly string[] Tens =
            { "", "Dc", "Vg", "Tg", "Qg", "Qq", "Sg", "St", "Og", "Nn" };
        private static readonly string[] Hundreds =
            { "", "Ce", "Dn", "Tc", "Qd", "Qn", "Se", "Su", "Ot", "Nv" };

        private readonly ISuffixProvider _fallback;
        private readonly long _maxNamedTier;

        /// <summary>
        /// Creates a short-scale provider. Tiers above <paramref name="maxNamedTier"/> (default: unbounded, i.e.
        /// the full algorithmic range up to millinillion) defer to <paramref name="fallback"/> (default: the
        /// alphabetic <see cref="DefaultSuffixProvider"/>). Pass <c>maxNamedTier: 11</c> to stop naming at
        /// decillion and hand everything larger to the fallback.
        /// </summary>
        public ShortScaleSuffixProvider(long maxNamedTier = long.MaxValue, ISuffixProvider? fallback = null) {
            _maxNamedTier = maxNamedTier;
            _fallback = fallback ?? DefaultSuffixProvider.Instance;
        }

        /// <inheritdoc/>
        public string GetSuffix(long tier) {
            if (tier <= 0) return string.Empty;
            if (tier > _maxNamedTier) return _fallback.GetSuffix(tier);
            if (tier <= 10) return FirstTiers[tier - 1];

            // Decillion (tier 11) is illion number 10 = Ones[0] + Tens[1] + Hundreds[0] = "Dc".
            long n = tier - 1;
            if (n >= 1000) return _fallback.GetSuffix(tier); // millinillion and beyond: hand off.

            int ones = (int)(n % 10);
            int tens = (int)((n / 10) % 10);
            int hundreds = (int)((n / 100) % 10);
            return Ones[ones] + Tens[tens] + Hundreds[hundreds];
        }
    }

    /// <summary>Notation presets and the app-wide default used by <see cref="BigDouble.ToString()"/>.</summary>
    public static class Notation {

        /// <summary>Scientific notation preset (e.g. <c>1.50e12</c>).</summary>
        public static readonly ScientificNotation Scientific = new ScientificNotation();

        /// <summary>Engineering notation preset (exponent a multiple of three).</summary>
        public static readonly EngineeringNotation Engineering = new EngineeringNotation();

        /// <summary>Standard abbreviated notation preset (<c>K/M/B/T/aa&#8230;</c>).</summary>
        public static readonly StandardNotation Standard = new StandardNotation();

        /// <summary>
        /// Standard abbreviated notation using short-scale named suffixes (<c>K/M/B/T/Qa/Qi/&#8230;/Dc/UDc/&#8230;</c>),
        /// the convention most idle games display. Backed by <see cref="ShortScaleSuffixProvider"/>.
        /// </summary>
        public static readonly StandardNotation ShortScale = new StandardNotation(ShortScaleSuffixProvider.Instance);

        /// <summary>
        /// The default notation used by <see cref="BigDouble.ToString()"/>. Intentionally a fixed
        /// <c>static readonly</c> value (standard abbreviated) rather than a settable global, to avoid
        /// process-wide mutable state; pass an explicit <see cref="INotation"/> when you need a different style.
        /// </summary>
        public static readonly INotation Default = Standard;
    }
}
