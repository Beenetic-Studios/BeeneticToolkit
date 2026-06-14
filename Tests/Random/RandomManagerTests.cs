using BeeneticToolkit.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BeeneticToolkit.Tests.Random {

    /// <summary>
    /// Tests for the global <see cref="RandomManager"/>. Marked <see cref="DoNotParallelizeAttribute"/> because
    /// they read and mutate process-wide state (the default environment / environment registry).
    /// </summary>
    [TestClass]
    [DoNotParallelize]
    public class RandomManagerTests {

        [TestMethod]
        public void Default_HasCurrentGeneratorOutOfTheBox() {
            Assert.IsNotNull(RandomManager.Default);
            Assert.AreEqual(RandomManager.DefaultEnvironmentName, RandomManager.Default.Name);
            Assert.IsNotNull(RandomManager.Current);
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
        public void GetEnvironment_Unknown_Throws() {
            Assert.ThrowsException<KeyNotFoundException>(() => RandomManager.GetEnvironment("does-not-exist"));
        }

        [TestMethod]
        public void SetDefault_SwitchesDefaultEnvironment() {
            var alt = RandomManager.CreateEnvironment("sim-default");
            alt.CreateAndRegister("x");

            try {
                RandomManager.SetDefault("sim-default");
                Assert.AreSame(alt, RandomManager.Default);
            } finally {
                RandomManager.SetDefault(RandomManager.DefaultEnvironmentName); // restore global state
            }

            Assert.AreEqual(RandomManager.DefaultEnvironmentName, RandomManager.Default.Name);
        }
    }
}
