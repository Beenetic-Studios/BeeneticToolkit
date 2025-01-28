using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace BeeneticToolkit.Collections.ObjectPooling.Tests {

    [TestClass]
    public class PooledObjectPolicyTests {

        private class StringBuilderPolicy : PooledObjectPolicy<StringBuilder> {

            public override StringBuilder Create() {
                return new StringBuilder();
            }

            public override void Reset(StringBuilder obj) {
                obj.Clear();
            }

            public override bool Validate(StringBuilder obj) {
                return obj.Length == 0; // Valid if the StringBuilder is empty.
            }
        }

        [TestMethod]
        public void CreateTest() {
            var policy = new StringBuilderPolicy();
            var sb = policy.Create();

            Assert.IsNotNull(sb, "Create should return a new StringBuilder instance.");
            Assert.AreEqual(0, sb.Length, "Newly created StringBuilder should be empty.");
        }

        [TestMethod]
        public void ResetTest() {
            var policy = new StringBuilderPolicy();
            var sb = new StringBuilder("Hello, World!");

            policy.Reset(sb);
            Assert.AreEqual(0, sb.Length, "Reset should clear the StringBuilder.");
        }

        [TestMethod]
        public void ValidateValidObjectTest() {
            var policy = new StringBuilderPolicy();
            var sb = new StringBuilder(); // Empty StringBuilder.

            Assert.IsTrue(policy.Validate(sb), "Validate should return true for an empty StringBuilder.");
        }

        [TestMethod]
        public void ValidateInvalidObjectTest() {
            var policy = new StringBuilderPolicy();
            var sb = new StringBuilder("Not Empty");

            Assert.IsFalse(policy.Validate(sb), "Validate should return false for a non-empty StringBuilder.");
        }

        [TestMethod]
        public void IntegrationTest_CreateResetValidate() {
            var policy = new StringBuilderPolicy();

            var sb = policy.Create();
            Assert.IsTrue(policy.Validate(sb), "Newly created StringBuilder should be valid.");

            sb.Append("Testing");
            Assert.IsFalse(policy.Validate(sb), "Modified StringBuilder should be invalid.");

            policy.Reset(sb);
            Assert.IsTrue(policy.Validate(sb), "Reset StringBuilder should be valid again.");
        }
    }
}