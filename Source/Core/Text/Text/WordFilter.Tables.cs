using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Text {

    // The character tables behind WordFilter's spelling step. Data only; the logic lives in WordFilter.cs.
    public sealed partial class WordFilter {

        // Each letter's ASCII spelling, as pairs: the spelling, then every character that folds to it. Latin-1
        // Supplement and Latin Extended-A letters, the Cyrillic and Greek lookalikes, both cases, then the blocks named
        // below. A character listed twice is a broken table: building the lookup throws (see BuildFold).
        private static readonly string[] FoldPairs = {
            "a", "\u00AA\u00C0\u00C1\u00C2\u00C3\u00C4\u00C5\u00E0\u00E1\u00E2\u00E3\u00E4\u00E5\u0100",
            "a", "\u0101\u0102\u0103\u0104\u0105\u0391\u03B1\u0410\u0430\u212B",
            "ae", "\u00C6\u00E6",
            "c", "\u00C7\u00E7\u0106\u0107\u0108\u0109\u010A\u010B\u010C\u010D\u0421\u0441",
            "d", "\u00D0\u00F0\u010E\u010F\u0110\u0111",
            "e", "\u00C8\u00C9\u00CA\u00CB\u00E8\u00E9\u00EA\u00EB\u0112\u0113\u0114\u0115\u0116\u0117",
            "e", "\u0118\u0119\u011A\u011B\u0395\u03B5\u0415\u0435",
            "g", "\u011C\u011D\u011E\u011F\u0120\u0121\u0122\u0123",
            "h", "\u0124\u0125\u0126\u0127",
            "i", "\u00CC\u00CD\u00CE\u00CF\u00EC\u00ED\u00EE\u00EF\u0128\u0129\u012A\u012B\u012C\u012D",
            "i", "\u012E\u012F\u0130\u0131\u0399\u03B9\u0406\u0456",
            "ij", "\u0132\u0133",
            "j", "\u0134\u0135",
            "k", "\u0136\u0137\u0138\u039A\u03BA\u212A",
            "l", "\u0139\u013A\u013B\u013C\u013D\u013E\u013F\u0140\u0141\u0142",
            "n", "\u00D1\u00F1\u0143\u0144\u0145\u0146\u0147\u0148\u0149\u014A\u014B",
            "o", "\u00BA\u00D2\u00D3\u00D4\u00D5\u00D6\u00D8\u00F2\u00F3\u00F4\u00F5\u00F6\u00F8\u014C",
            "o", "\u014D\u014E\u014F\u0150\u0151\u039F\u03BF\u041E\u043E",
            "oe", "\u0152\u0153",
            "p", "\u03A1\u03C1\u0420\u0440",
            "r", "\u0154\u0155\u0156\u0157\u0158\u0159",
            "s", "\u015A\u015B\u015C\u015D\u015E\u015F\u0160\u0161\u017F\u0405\u0455",
            "ss", "\u00DF\u1E9E",
            "t", "\u0162\u0163\u0164\u0165\u0166\u0167\u03A4\u03C4",
            "th", "\u00DE\u00FE",
            "u", "\u00D9\u00DA\u00DB\u00DC\u00F9\u00FA\u00FB\u00FC\u0168\u0169\u016A\u016B\u016C\u016D",
            "u", "\u016E\u016F\u0170\u0171\u0172\u0173\u03A5\u03C5",
            "v", "\u039D\u03BD",
            "w", "\u0174\u0175",
            "x", "\u03A7\u03C7\u0425\u0445",
            "y", "\u00DD\u00FD\u00FF\u0176\u0177\u0178\u0423\u0443",
            "z", "\u0179\u017A\u017B\u017C\u017D\u017E",
            // Letterlike Symbols: the letters the Mathematical Alphanumeric block leaves out (its holes), and a few more.
            "b", "\u212C",
            "c", "\u2102\u212D",
            "d", "\u2145\u2146",
            "e", "\u212F\u2130\u2147",
            "f", "\u2131",
            "g", "\u210A",
            "h", "\u210B\u210C\u210D\u210E\u210F",
            "i", "\u2110\u2111\u2139\u2148",
            "j", "\u2149",
            "l", "\u2112\u2113",
            "m", "\u2133",
            "n", "\u2115",
            "o", "\u2134",
            "p", "\u2119",
            "q", "\u211A",
            "r", "\u211B\u211C\u211D",
            "z", "\u2124\u2128",
            // Small capitals, modifier (superscript) and subscript letters.
            "a", "\u1D00\u1D2C\u1D43\u1D45\u2090",
            "ae", "\u1D01\u1D2D",
            "b", "\u0299\u1D03\u1D2E\u1D47",
            "c", "\u1D04\u1D9C",
            "d", "\u1D05\u1D06\u1D30\u1D48",
            "e", "\u1D07\u1D31\u1D49\u1D4B\u2091",
            "f", "\u1DA0\uA730",
            "g", "\u0262\u1D33\u1D4D",
            "h", "\u029C\u02B0\u1D34\u2095",
            "i", "\u026A\u1D35\u1D62\u2071",
            "j", "\u02B2\u1D0A\u1D36\u2C7C",
            "k", "\u1D0B\u1D37\u1D4F\u2096",
            "l", "\u029F\u02E1\u1D0C\u1D38\u2097",
            "m", "\u1D0D\u1D39\u1D50\u2098",
            "n", "\u0274\u1D3A\u207F\u2099",
            "o", "\u1D0F\u1D11\u1D3C\u1D52\u2092",
            "oe", "\u0276",
            "p", "\u1D18\u1D29\u1D3E\u1D56\u209A",
            "q", "\uA7AF",
            "r", "\u0280\u02B3\u1D3F\u1D63",
            "s", "\u02E2\u209B\uA731",
            "t", "\u1D1B\u1D40\u1D57\u209C",
            "u", "\u1D1C\u1D41\u1D58\u1D64",
            "v", "\u1D20\u1D5B\u1D65",
            "w", "\u02B7\u1D21\u1D42",
            "x", "\u02E3\u2093",
            "y", "\u028F\u02B8",
            "z", "\u1D22\u1DBB",
            // Cherokee letters that read as Latin ones (Unicode confusables.txt), capital and small.
            "a", "\u13AA\uAB7A",
            "b", "\u13CF\u13F4\u13FC\uAB9F",
            "c", "\u13DF\uABAF",
            "d", "\u13A0\u13E7\uAB70\uABB7",
            "e", "\u13AC\u13CB\uAB7C\uAB9B",
            "g", "\u13C0\u13F3\u13FB\uAB90",
            "h", "\u13BB\u13C2\u13F2\u13FA\uAB8B\uAB92",
            "i", "\u13A5\uAB75",
            "j", "\u13AB\uAB7B",
            "k", "\u13E6\uABB6",
            "l", "\u13DE\uABAE",
            "m", "\u13B7\uAB87",
            "o", "\u13A4\u13BE\u13EB\uAB74\uAB8E\uABBB",
            "p", "\u13E2\uABB2",
            "r", "\u13A1\u13D2\uAB71\uAB81\uABA2",
            "s", "\u13D5\u13DA\uABA5\uABAA",
            "t", "\u13A2\u13BF\uAB72\uAB8F",
            "u", "\u13CC\uAB9C",
            "v", "\u13D9\uABA9",
            "w", "\u13B3\u13D4\uAB83\uABA4",
            "y", "\u13A9\u13BD\uAB79\uAB8D",
            "z", "\u13C3\uAB93"
        };

        // Styled and enclosed letters and digits, by arithmetic: "FIRST LAST ALPHABET" (hex code points), and a code
        // point in FIRST..LAST reads as ALPHABET[(cp - FIRST) % ALPHABET.Length], an ASCII character that then goes
        // through the ASCII rules (case, leet). The Mathematical Alphanumeric letters are 13 styles of 52 (bold, italic,
        // bold italic, script, bold script, fraktur, double-struck, bold fraktur, sans, sans bold, sans italic, sans
        // bold italic, monospace); their reserved holes read as the letter they would be (the real ones are Letterlike
        // Symbols, in the fold table).
        private static readonly string[] RangeRows = {
            "1D400 1D6A3 ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz",
            "1D6A4 1D6A5 ij",
            "1D7CE 1D7FF 0123456789",
            "1F110 1F129 ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "1F130 1F149 ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "1F150 1F169 ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "1F170 1F189 ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "2460 2468 123456789",
            "249C 24B5 abcdefghijklmnopqrstuvwxyz",
            "24B6 24CF ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "24D0 24E9 abcdefghijklmnopqrstuvwxyz",
            "24EA 24EA 0",
            "00B2 00B3 23",
            "00B9 00B9 1",
            "2070 2070 0",
            "2074 2079 456789",
            "2080 2089 0123456789"
        };

        // Leet, the same on every pass: each character in LeetFrom reads as the letter at the same place in LeetTo.
        // `1` and `|` read as OneReads[pass], a lowercase ASCII `l` as LReads[pass].
        private const string LeetFrom = "0345789@$+!";
        private const string LeetTo = "oeastbgasti";
        private const string OneReads = "ili";
        private const string LReads = "lli";

        // Derived lookups. They must stay below the tables in this file: static initializers run in textual order
        // within a file, but their order across the files of a partial class is undefined.
        private static readonly Dictionary<char, string> s_fold = BuildFold();
        private static readonly int[] s_rangeFirst = RangeColumn(0).Select(v => Convert.ToInt32(v, 16)).ToArray();
        private static readonly int[] s_rangeLast = RangeColumn(1).Select(v => Convert.ToInt32(v, 16)).ToArray();
        private static readonly string[] s_rangeAlphabet = RangeColumn(2).ToArray();
    }
}
