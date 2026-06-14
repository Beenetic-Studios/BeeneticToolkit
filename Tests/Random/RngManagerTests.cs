using BeeneticToolkit.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BeeneticToolkit.Tests.Random {

    /// <summary>
    /// Tests for the global <see cref="RngManager"/>. Marked <see cref="DoNotParallelizeAttribute"/> because
    /// they read and mutate process-wide state (the default environment / environment registry).
    /// </summary>
    [TestClass]
    [DoNotParallelize]
    public class RngManagerTests {

        [TestMethod]
        public void Default_HasCurrentGeneratorOutOfTheBox() {
            Assert.IsNotNull(RngManager.Default);
            Assert.AreEqual(RngManager.DefaultEnvironmentName, RngManager.Default.Name);
            Assert.IsNotNull(RngManager.Current);
        }

        [TestMethod]
        public void CreateEnvironment_IsRetrievableByName() {
            var env = RngManager.CreateEnvironment("sim-create", rootSeed: 999);

            Assert.AreSame(env, RngManager.GetEnvironment("sim-create"));
            Assert.AreEqual(999L, env.RootSeed);

            Assert.IsTrue(RngManager.TryGetEnvironment("sim-create", out var found));
            Assert.AreSame(env, found);

            Assert.IsFalse(RngManager.TryGetEnvironment("never-created", out var missing));
            Assert.IsNull(missing);
        }

        [TestMethod]
        public void GetEnvironment_Unknown_Throws() {
            Assert.ThrowsException<KeyNotFoundException>(() => RngManager.GetEnvironment("does-not-exist"));
        }

        [TestMethod]
        public void SetDefault_SwitchesDefaultEnvironment() {
            var alt = RngManager.CreateEnvironment("sim-default");
            alt.CreateAndRegister("x");

            try {
                RngManager.SetDefault("sim-default");
                Assert.AreSame(alt, RngManager.Default);
            } finally {
                RngManager.SetDefault(RngManager.DefaultEnvironmentName); // restore global state
            }

            Assert.AreEqual(RngManager.DefaultEnvironmentName, RngManager.Default.Name);
        }
    }
}
