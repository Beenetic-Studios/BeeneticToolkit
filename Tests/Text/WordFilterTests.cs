using BeeneticToolkit.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Text {

    /// <summary>
    /// Vector tests for <see cref="WordFilter"/>: each row is a text, the field it is checked as, and the verdict
    /// expected. The fixture list is invented and harmless on purpose (the package ships no list, and a public test
    /// suite should not carry one); the disguises it exercises are the real ones.
    /// </summary>
    [TestClass]
    public class WordFilterTests {

        private const string Name = "name";
        private const string Status = "status";

        private static readonly WordFilterRules NameRules = new WordFilterRules(3, 20, checkReserved: true);
        private static readonly WordFilterRules StatusRules = new WordFilterRules(0, 60, checkReserved: false);

        private static readonly WordFilter Filter = new WordFilter(new WordList(
            anywhere: new[] { "frack", "smeg" },
            word: new[] { "belt", "boo", "darn", "spit" },
            allow: new[] { "smeggy", "smegly" },
            reserved: new[] { "admin", "moderator" }));

        private static WordFilterRules RulesFor(string field) => field == Name ? NameRules : StatusRules;

        #region Vectors

        [DataTestMethod]
        [DataRow("darn", Status, WordFilterVerdict.Word, DisplayName = "plain")]
        [DataRow("DaRN", Status, WordFilterVerdict.Word, DisplayName = "case")]
        [DataRow("daaarnnn", Status, WordFilterVerdict.Word, DisplayName = "stretched letters")]
        [DataRow("darning", Status, WordFilterVerdict.Ok, DisplayName = "word tier needs a whole token")]
        [DataRow("d a r n", Status, WordFilterVerdict.Ok, DisplayName = "word tier is per token")]
        [DataRow("bo", Status, WordFilterVerdict.Ok, DisplayName = "a doubled letter needs both")]
        [DataRow("booooo", Status, WordFilterVerdict.Word, DisplayName = "doubled letter stretched")]
        [DataRow("boot", Status, WordFilterVerdict.Ok, DisplayName = "longer word is fine")]
        [DataRow("xxfrackxx", Status, WordFilterVerdict.Word, DisplayName = "anywhere inside a token")]
        [DataRow("fr ack", Status, WordFilterVerdict.Word, DisplayName = "anywhere across a space")]
        [DataRow("f.r_a-c~k", Status, WordFilterVerdict.Word, DisplayName = "anywhere across punctuation")]
        public void Vectors_WordTiers(string text, string field, WordFilterVerdict expected) {
            Assert.AreEqual(expected, Filter.Check(text, RulesFor(field)));
        }

        [DataTestMethod]
        [DataRow("d4rn", Status, WordFilterVerdict.Word, DisplayName = "4 reads a")]
        [DataRow("b00", Status, WordFilterVerdict.Word, DisplayName = "0 reads o")]
        [DataRow("@$$frack", Status, WordFilterVerdict.Word, DisplayName = "@ and $ are letters, not breaks")]
        [DataRow("fr4ck", Status, WordFilterVerdict.Word, DisplayName = "leet inside anywhere")]
        [DataRow("5pit", Status, WordFilterVerdict.Word, DisplayName = "5 reads s")]
        [DataRow("spi+", Status, WordFilterVerdict.Word, DisplayName = "+ reads t")]
        [DataRow("sp1t", Status, WordFilterVerdict.Word, DisplayName = "pass 1: 1 reads i")]
        [DataRow("sp!t", Status, WordFilterVerdict.Word, DisplayName = "! reads i")]
        [DataRow("sp|t", Status, WordFilterVerdict.Word, DisplayName = "pass 1: | reads i")]
        [DataRow("be1t", Status, WordFilterVerdict.Word, DisplayName = "pass 2: 1 reads l")]
        [DataRow("be|t", Status, WordFilterVerdict.Word, DisplayName = "pass 2: | reads l")]
        [DataRow("splt", Status, WordFilterVerdict.Word, DisplayName = "pass 3: lowercase l reads i")]
        [DataRow("spLt", Status, WordFilterVerdict.Ok, DisplayName = "capital L is always l")]
        public void Vectors_Leet(string text, string field, WordFilterVerdict expected) {
            Assert.AreEqual(expected, Filter.Check(text, RulesFor(field)));
        }

        [DataTestMethod]
        [DataRow("dárn", Status, WordFilterVerdict.Word, DisplayName = "accent")]
        [DataRow("dаrn", Status, WordFilterVerdict.Word, DisplayName = "Cyrillic a")]
        [DataRow("βoo", Status, WordFilterVerdict.Ok, DisplayName = "Greek beta is not folded")]
        [DataRow("Βoo", Status, WordFilterVerdict.Ok, DisplayName = "Greek capital beta is not folded")]
        [DataRow("\U0001D41D\U0001D41A\U0001D42B\U0001D427", Status, WordFilterVerdict.Word, DisplayName = "math bold")]
        [DataRow("\U0001D5BD\U0001D5BA\U0001D5CB\U0001D5C7", Status, WordFilterVerdict.Word, DisplayName = "math sans")]
        [DataRow("ｄａｒｎ", Status, WordFilterVerdict.Word, DisplayName = "fullwidth")]
        [DataRow("ⓓⓐⓡⓝ", Status, WordFilterVerdict.Word, DisplayName = "circled small")]
        [DataRow("\U0001F133\U0001F130\U0001F141\U0001F13D", Status, WordFilterVerdict.Word, DisplayName = "squared capital")]
        [DataRow("ᴅᴀʀɴ", Status, WordFilterVerdict.Word, DisplayName = "small capitals")]
        [DataRow("b\U0001D7CE\U0001D7CE", Status, WordFilterVerdict.Word, DisplayName = "math digits then leet")]
        [DataRow("ᎠᎪrɴ", Status, WordFilterVerdict.Word, DisplayName = "Cherokee lookalikes")]
        [DataRow("darn\U0001F600", Status, WordFilterVerdict.Word, DisplayName = "emoji is a break")]
        public void Vectors_Unicode(string text, string field, WordFilterVerdict expected) {
            Assert.AreEqual(expected, Filter.Check(text, RulesFor(field)));
        }

        [DataTestMethod]
        [DataRow("smeg", Status, WordFilterVerdict.Word, DisplayName = "anywhere entry alone")]
        [DataRow("smeggy", Status, WordFilterVerdict.Ok, DisplayName = "allowed token")]
        [DataRow("SMEGGY", Status, WordFilterVerdict.Ok, DisplayName = "allowed token, any case")]
        [DataRow("smegly", Status, WordFilterVerdict.Ok, DisplayName = "allowed on one pass is allowed on all")]
        [DataRow("smeggy smeg", Status, WordFilterVerdict.Word, DisplayName = "allow drops only its own token")]
        [DataRow("smeggyfrack", Status, WordFilterVerdict.Word, DisplayName = "allow needs the whole token")]
        public void Vectors_Allow(string text, string field, WordFilterVerdict expected) {
            Assert.AreEqual(expected, Filter.Check(text, RulesFor(field)));
        }

        [DataTestMethod]
        [DataRow("Admin", Name, WordFilterVerdict.Reserved, DisplayName = "reserved name")]
        [DataRow("TheAdmin1", Name, WordFilterVerdict.Reserved, DisplayName = "reserved inside a name")]
        [DataRow("The Admin", Name, WordFilterVerdict.Reserved, DisplayName = "reserved across a space")]
        [DataRow("4dm1n", Name, WordFilterVerdict.Reserved, DisplayName = "reserved through leet")]
        [DataRow("m0derat0r", Name, WordFilterVerdict.Reserved, DisplayName = "reserved, longer")]
        [DataRow("Admin", Status, WordFilterVerdict.Ok, DisplayName = "status skips reserved")]
        [DataRow("darn admin", Name, WordFilterVerdict.Word, DisplayName = "word wins over reserved")]
        [DataRow("Adam", Name, WordFilterVerdict.Ok, DisplayName = "near miss")]
        public void Vectors_Reserved(string text, string field, WordFilterVerdict expected) {
            Assert.AreEqual(expected, Filter.Check(text, RulesFor(field)));
        }

        [DataTestMethod]
        [DataRow("ab", Name, WordFilterVerdict.Length, DisplayName = "too short")]
        [DataRow("abc", Name, WordFilterVerdict.Ok, DisplayName = "minimum")]
        [DataRow("abcdefghijabcdefghij", Name, WordFilterVerdict.Ok, DisplayName = "maximum")]
        [DataRow("abcdefghijabcdefghijk", Name, WordFilterVerdict.Length, DisplayName = "too long")]
        [DataRow("  ab  ", Name, WordFilterVerdict.Length, DisplayName = "spaces are trimmed first")]
        [DataRow("   abc   ", Name, WordFilterVerdict.Ok, DisplayName = "trimmed to the minimum")]
        [DataRow("", Name, WordFilterVerdict.Length, DisplayName = "empty name")]
        [DataRow("", Status, WordFilterVerdict.Ok, DisplayName = "empty status")]
        [DataRow("\U0001D41D\U0001D41A", Name, WordFilterVerdict.Ok, DisplayName = "length counts UTF-16 units")]
        public void Vectors_Length(string text, string field, WordFilterVerdict expected) {
            Assert.AreEqual(expected, Filter.Check(text, RulesFor(field)));
        }

        [DataTestMethod]
        [DataRow("　　　", Name, WordFilterVerdict.Characters, DisplayName = "ideographic spaces only")]
        [DataRow(" ", Status, WordFilterVerdict.Characters, DisplayName = "no-break space only")]
        [DataRow("　", Name, WordFilterVerdict.Characters, DisplayName = "blank is checked before length")]
        [DataRow("a\u0007", Name, WordFilterVerdict.Length, DisplayName = "length is checked before characters")]
        [DataRow("ab​cd", Name, WordFilterVerdict.Characters, DisplayName = "zero-width space")]
        [DataRow("abc\u0007", Name, WordFilterVerdict.Characters, DisplayName = "control")]
        [DataRow("\tabc", Name, WordFilterVerdict.Characters, DisplayName = "tab is not trimmed")]
        [DataRow("ab‮cd", Name, WordFilterVerdict.Characters, DisplayName = "direction override")]
        [DataRow("ab⠀cd", Name, WordFilterVerdict.Characters, DisplayName = "blank Braille")]
        [DataRow("abㅤcd", Name, WordFilterVerdict.Characters, DisplayName = "Hangul filler")]
        [DataRow("darn​", Status, WordFilterVerdict.Characters, DisplayName = "characters before words")]
        [DataRow("ok‍go", Name, WordFilterVerdict.Ok, DisplayName = "joiner is legal")]
        public void Vectors_Characters(string text, string field, WordFilterVerdict expected) {
            Assert.AreEqual(expected, Filter.Check(text, RulesFor(field)));
        }

        // Not DataRows: attribute strings are stored as UTF-8, which would turn a lone surrogate into U+FFFD.
        [TestMethod]
        public void Vectors_UnpairedSurrogateIsABreak() {
            string lone = "da\uD800rn";
            Assert.AreEqual(5, lone.Length);
            Assert.IsTrue(char.IsHighSurrogate(lone[2]));
            Assert.AreEqual(WordFilterVerdict.Ok, Filter.Check(lone, StatusRules));
            Assert.AreEqual(WordFilterVerdict.Word, Filter.Check("fr\uDC00ack", StatusRules));
        }

        #endregion Vectors

        #region API

        [TestMethod]
        public void Check_NullReadsAsEmpty() {
            Assert.AreEqual(WordFilterVerdict.Length, Filter.Check(null, NameRules));
            Assert.AreEqual(WordFilterVerdict.Ok, Filter.Check(null, StatusRules));
        }

        [TestMethod]
        public void IsAllowed_MatchesOkVerdict() {
            Assert.IsTrue(Filter.IsAllowed("Hello there", StatusRules));
            Assert.IsFalse(Filter.IsAllowed("sp1t", StatusRules));
        }

        [TestMethod]
        public void EmptyList_StillAppliesLengthAndCharacterRules() {
            WordFilter empty = new WordFilter(WordList.Empty);
            Assert.AreEqual(WordFilterVerdict.Ok, empty.Check("darn frack admin", WordFilterRules.WordsOnly));
            Assert.AreEqual(WordFilterVerdict.Length, empty.Check("ab", NameRules));
            Assert.AreEqual(WordFilterVerdict.Characters, empty.Check("ab​cd", NameRules));
        }

        [TestMethod]
        public void WordsOnly_HasNoLengthLimitOrReservedCheck() {
            Assert.AreEqual(WordFilterVerdict.Ok, Filter.Check(new string('x', 10_000), WordFilterRules.WordsOnly));
            Assert.AreEqual(WordFilterVerdict.Ok, Filter.Check("admin", WordFilterRules.WordsOnly));
        }

        [DataTestMethod]
        [DataRow("Darn", DisplayName = "capital")]
        [DataRow("", DisplayName = "empty")]
        [DataRow("da rn", DisplayName = "space")]
        [DataRow("dárn", DisplayName = "accent")]
        [DataRow("darn1", DisplayName = "digit")]
        public void WordList_RejectsEntriesThatAreNotLowercaseAscii(string entry) {
            Assert.ThrowsException<ArgumentException>(() => new WordList(new[] { entry }, new string[0], new string[0], new string[0]));
        }

        [TestMethod]
        public void WordList_RejectsNullEntryAndNamesTheTier() {
            ArgumentException e = Assert.ThrowsException<ArgumentException>(
                () => new WordList(new string[0], new string[0], new string[0], new string[] { null }));
            Assert.AreEqual("reserved", e.ParamName);
        }

        [TestMethod]
        public void WordList_CopiesItsTiers() {
            string[] word = { "darn" };
            WordList list = new WordList(new string[0], word, new string[0], new string[0]);
            word[0] = "boo";
            Assert.AreEqual("darn", list.Word[0]);
        }

        [TestMethod]
        public void Rules_RejectBadBounds() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WordFilterRules(-1, 10, false));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WordFilterRules(5, 4, false));
        }

        #endregion API
    }
}
