using BeeneticToolkit.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BeeneticToolkit.Tests.Random {

    /// <summary>
    /// Tests for the global <see cref="RandomManager"/>. Marked <see cref="DoNotParallelizeAttribute"/> because
    /// they read and mutate process-wide state (the environment registry and scratch generator).
    /// </summary>
    [TestClass]
    [DoNotParallelize]
    public class RandomManagerTests {

        [TestMethod]
        public void Scratch_IsAvailableAndStable() {
            var scratch = RandomManager.Scratch;

            Assert.IsNotNull(scratch);
            Assert.AreSame(scratch, RandomManager.Scratch, "Scratch should be a stable, lazily-created singleton.");
        }

        [TestMethod]
        public void CreateEnvironment_IsRetrievableByName() {
            var env = RandomManager.CreateEnvironment("sim-create", rootSeed: 999);

            Assert.AreSame(env, RandomManager.GetEnvironment("sim-create"));
            Assert.AreEqual(999L, env.RootSeed);

            Assert.IsTrue(RandomManager.TryGetEnvironment("sim-create", out var found));
            Assert.AreSame(env, found);

            Assert.IsFalse(RandomManager.TryGetEnvironment("never-created", out var missing));
            Assert.IsNull(missing);
        }

        [TestMethod]
        public void CreateEnvironment_ReplacesExistingByName() {
            var first = RandomManager.CreateEnvironment("sim-replace");
            var second = RandomManager.CreateEnvironment("sim-replace");

            Assert.AreNotSame(first, second);
            Assert.AreSame(second, RandomManager.GetEnvironment("sim-replace"));
        }

        [TestMethod]
        public void GetEnvironment_Unknown_Throws() {
            Assert.ThrowsException<KeyNotFoundException>(() => RandomManager.GetEnvironment("does-not-exist"));
        }
    }
}
