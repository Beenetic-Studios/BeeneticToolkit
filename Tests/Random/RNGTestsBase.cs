using BeeneticToolkit.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Random {

    public abstract class RNGTestsBase {

        #region Initialization

        protected RandomGenerator Generator;

        [TestInitialize]
        public void Initialize() {
            Generator = InitRngBase();
        }

        protected abstract RandomGenerator InitRngBase();

        #endregion Initialization

        #region Integer Tests

        [TestMethod]
        public void NextInt_MaxExclusiveZero_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextInt(0));
        }

        [TestMethod]
        public void NextInt_MaxExclusiveNegative_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextInt(-1));
        }

        [TestMethod]
        public void NextInt_MaxExclusiveOne_ReturnsZero() {
            int result = Generator.NextInt(1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NextInt_MinEqualsMax_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextInt(5, 5));
        }

        [TestMethod]
        public void NextInt_MinGreaterThanMax_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextInt(10, 5));
        }

        [TestMethod]
        public void NextInt_MinMaxAtIntLimits_ReturnsMaxMinusOne() {
            int result = Generator.NextInt(int.MaxValue - 1, int.MaxValue);
            Assert.AreEqual(int.MaxValue - 1, result);
        }

        [TestMethod]
        public void NextInt_ReturnsValueWithinRange() {
            int minValue = -10;
            int maxValue = 10;
            int iterations = 100000;

            List<int> values = new();
            for (int i = 0; i < iterations; i++) {
                values.Add(Generator.NextInt(minValue, maxValue));
            }

            Assert.IsTrue(values.All(val => val >= minValue && val < maxValue), "All values should be within the specified range.");

            double expectedMean = (minValue + maxValue - 1) / 2.0;
            double actualMean = values.Average();
            Assert.AreEqual(expectedMean, actualMean, 0.1, "The mean of the generated values should be close to the expected mean.");
        }

        [TestMethod]
        public void NextInt_UniformDistribution() {
            int minValue = -10;
            int maxValue = 10;
            int iterations = 100000; // Increased iterations for a more granular distribution check

            Dictionary<int, int> counts = Enumerable.Range(minValue, maxValue - minValue).ToDictionary(v => v, v => 0);

            for (int i = 0; i < iterations; i++) {
                int value = Generator.NextInt(minValue, maxValue);
                if (counts.ContainsKey(value)) {
                    counts[value]++;
                } else {
                    Assert.Fail($"Value {value} is outside the expected range.");
                }
            }

            double expectedCount = iterations / (double)(maxValue - minValue);
            double tolerance = expectedCount * 0.05;

            foreach (var count in counts) {
                Assert.IsTrue(Math.Abs(count.Value - expectedCount) <= tolerance,
                    $"Value {count.Key} does not occur with expected uniform frequency.");
            }
        }

        [TestMethod]
        public void NextInt_InclusiveLowerBound() {
            int minValue = -10;
            int maxValue = 10;
            int iterations = 100000;
            bool minValueGenerated = false;

            for (int i = 0; i < iterations && !minValueGenerated; i++) {
                if (Generator.NextInt(minValue, maxValue) == minValue) {
                    minValueGenerated = true;
                }
            }

            Assert.IsTrue(minValueGenerated, "The minimum value should be generated at least once.");
        }

        [TestMethod]
        public void NextInt_ExclusiveUpperBound() {
            int minValue = -10;
            int maxValue = 10;
            int iterations = 100000;
            bool maxValueMinusOneGenerated = false;

            for (int i = 0; i < iterations && !maxValueMinusOneGenerated; i++) {
                if (Generator.NextInt(minValue, maxValue) == maxValue - 1) {
                    maxValueMinusOneGenerated = true;
                }
            }

            Assert.IsTrue(maxValueMinusOneGenerated, "The value of maxValue - 1 should be generated at least once.");
        }

        #endregion Integer Tests

        #region Long Tests

        [TestMethod]
        public void NextLong_MaxExclusiveZero_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextLong(0));
        }

        [TestMethod]
        public void NextLong_MaxExclusiveNegative_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextLong(-1));
        }

        [TestMethod]
        public void NextLong_MaxExclusiveOne_ReturnsZero() {
            long result = Generator.NextLong(1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NextLong_MinEqualsMax_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextLong(5, 5));
        }

        [TestMethod]
        public void NextLong_MinGreaterThanMax_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextLong(10, 5));
        }

        [TestMethod]
        public void NextLong_MinMaxAtLongLimits_ReturnsMaxMinusOne() {
            long result = Generator.NextLong(long.MaxValue - 1, long.MaxValue);
            Assert.AreEqual(long.MaxValue - 1, result);
        }

        [TestMethod]
        public void NextLong_ReturnsValueWithinRange() {
            long minValue = -10;
            long maxValue = 10;
            int iterations = 100000;

            List<long> values = new();
            for (int i = 0; i < iterations; i++) {
                values.Add(Generator.NextLong(minValue, maxValue));
            }

            Assert.IsTrue(values.All(val => val >= minValue && val < maxValue), "All values should be within the specified range.");

            double expectedMean = (minValue + maxValue - 1) / 2.0;
            double actualMean = values.Average();
            Assert.AreEqual(expectedMean, actualMean, 0.1, "The mean of the generated values should be close to the expected mean.");
        }

        [TestMethod]
        public void NextLong_UniformDistribution() {
            long minValue = -10;
            long maxValue = 10;
            int iterations = 100000; // Increased iterations for a more granular distribution check

            Dictionary<long, long> counts = new(); // Enumerable.Range(minValue, maxValue - minValue).ToDictionary(v => v, v => 0);
            for (int i = (int)minValue; i < (int)maxValue; i++) {
                counts[i] = 0;
            }

            for (int i = 0; i < iterations; i++) {
                long value = Generator.NextLong(minValue, maxValue);
                if (counts.ContainsKey(value)) {
                    counts[value]++;
                } else {
                    Assert.Fail($"Value {value} is outside the expected range.");
                }
            }

            double expectedCount = iterations / (double)(maxValue - minValue);
            double tolerance = expectedCount * 0.05;

            foreach (var count in counts) {
                Assert.IsTrue(Math.Abs(count.Value - expectedCount) <= tolerance,
                    $"Value {count.Key} does not occur with expected uniform frequency.");
            }
        }

        [TestMethod]
        public void NextLong_InclusiveLowerBound() {
            long minValue = -10;
            long maxValue = 10;
            int iterations = 100000;
            bool minValueGenerated = false;

            for (int i = 0; i < iterations && !minValueGenerated; i++) {
                if (Generator.NextLong(minValue, maxValue) == minValue) {
                    minValueGenerated = true;
                }
            }

            Assert.IsTrue(minValueGenerated, "The minimum value should be generated at least once.");
        }

        [TestMethod]
        public void NextLong_ExclusiveUpperBound() {
            long minValue = -10;
            long maxValue = 10;
            int iterations = 100000;
            bool maxValueMinusOneGenerated = false;

            for (int i = 0; i < iterations && !maxValueMinusOneGenerated; i++) {
                if (Generator.NextLong(minValue, maxValue) == maxValue - 1) {
                    maxValueMinusOneGenerated = true;
                }
            }

            Assert.IsTrue(maxValueMinusOneGenerated, "The value of maxValue - 1 should be generated at least once.");
        }

        #endregion Long Tests

        #region Float Tests

        [TestMethod]
        public void NextFloat_MaxExclusiveZero_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextFloat(0f));
        }

        [TestMethod]
        public void NextFloat_MaxExclusiveNegative_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextFloat(-1f));
        }

        [TestMethod]
        public void NextFloat_MinEqualsMax_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextFloat(5f, 5f));
        }

        [TestMethod]
        public void NextFloat_MinGreaterThanMax_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextFloat(10f, 5f));
        }

        [TestMethod]
        public void NextFloat_ReturnsValueWithinRange() {
            float minValue = -10.0f;
            float maxValue = 10f;
            int iterations = 100000;

            List<float> values = new();
            for (int i = 0; i < iterations; i++) {
                values.Add(Generator.NextFloat(minValue, maxValue));
            }

            Assert.IsTrue(values.All(val => val >= minValue && val < maxValue), "All values should be within the specified range.");

            double expectedMean = (minValue + maxValue) / 2.0;
            double actualMean = values.Average();
            Assert.AreEqual(expectedMean, actualMean, 0.1, "The mean of the generated values should be close to the expected mean.");
        }

        [TestMethod]
        public void NextFloat_UniformDistribution() {
            float minValue = -10.0f;
            float maxValue = 10.0f;
            int iterations = 100000;
            int bucketCount = 10; // Number of buckets
            var buckets = new int[bucketCount];

            for (int i = 0; i < iterations; i++) {
                float value = Generator.NextFloat(minValue, maxValue);

                // Ensure that values are correctly bucketed
                int bucketIndex = (int)((value - minValue) / (maxValue - minValue) * bucketCount);
                if (bucketIndex == bucketCount)
                    bucketIndex--; // Handle edge case

                if (bucketIndex >= 0 && bucketIndex < bucketCount) {
                    buckets[bucketIndex]++;
                } else {
                    Assert.Fail($"Value {value} is outside the expected range.");
                }
            }

            double expectedCount = iterations / (double)bucketCount; // Each bucket should have roughly this many entries
            double tolerance = expectedCount * 0.05; // 5% tolerance

            for (int i = 0; i < buckets.Length; i++) {
                Assert.IsTrue(Math.Abs(buckets[i] - expectedCount) <= tolerance,
                    $"Bucket {i + 1} does not occur with expected uniform frequency. Count: {buckets[i]}, Expected: {expectedCount}");
            }
        }

        [TestMethod]
        public void NextFloat_InclusiveLowerBound() {
            float minValue = -10.0f;
            float maxValue = 10.0f;
            float tolerance = 0.0001f;
            int iterations = 1000000;
            bool minValueGenerated = false;

            for (int i = 0; i < iterations && !minValueGenerated; i++) {
                if (Math.Abs(Generator.NextFloat(minValue, maxValue) - minValue) < tolerance) {
                    minValueGenerated = true;
                }
            }

            Assert.IsTrue(minValueGenerated, "A value close to the minimum value should be generated at least once.");
        }

        [TestMethod]
        public void NextFloat_ExclusiveUpperBound() {
            float minValue = -10.0f;
            float maxValue = 10.0f;
            float tolerance = 0.0001f;
            int iterations = 1000000;
            bool upperBoundApproached = false;

            for (int i = 0; i < iterations && !upperBoundApproached; i++) {
                if (Math.Abs(Generator.NextFloat(minValue, maxValue) - maxValue) < tolerance) {
                    upperBoundApproached = true;
                }
            }

            Assert.IsTrue(upperBoundApproached, "A value approaching the exclusive upper bound should be generated at least once.");
        }

        #endregion Float Tests

        #region Double Tests

        [TestMethod]
        public void NextDouble_MaxExclusiveZero_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextDouble(0.0));
        }

        [TestMethod]
        public void NextDouble_MaxExclusiveNegative_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextDouble(-1.0));
        }

        [TestMethod]
        public void NextDouble_MinEqualsMax_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextDouble(5.0, 5.0));
        }

        [TestMethod]
        public void NextDouble_MinGreaterThanMax_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Generator.NextDouble(10.0, 5.0));
        }

        [TestMethod]
        public void NextDouble_ReturnsValueWithinRange() {
            double minValue = -10.0;
            double maxValue = 10.0;
            int iterations = 100000;

            List<double> values = new();
            for (int i = 0; i < iterations; i++) {
                values.Add(Generator.NextDouble(minValue, maxValue));
            }

            Assert.IsTrue(values.All(val => val >= minValue && val < maxValue), "All values should be within the specified range.");

            double expectedMean = (minValue + maxValue) / 2.0;
            double actualMean = values.Average();
            Assert.AreEqual(expectedMean, actualMean, 0.1, "The mean of the generated values should be close to the expected mean.");
        }

        [TestMethod]
        public void NextDouble_UniformDistribution() {
            double minValue = -10.0;
            double maxValue = 10.0;
            int iterations = 1000000;
            int bucketCount = 10; // Number of buckets
            var buckets = new int[bucketCount];

            for (int i = 0; i < iterations; i++) {
                double value = Generator.NextDouble(minValue, maxValue);

                // Ensure that values are correctly bucketed
                int bucketIndex = (int)((value - minValue) / (maxValue - minValue) * bucketCount);
                if (bucketIndex == bucketCount)
                    bucketIndex--; // Handle edge case

                if (bucketIndex >= 0 && bucketIndex < bucketCount) {
                    buckets[bucketIndex]++;
                } else {
                    Assert.Fail($"Value {value} is outside the expected range.");
                }
            }

            double expectedCount = iterations / (double)bucketCount; // Each bucket should have roughly this many entries
            double tolerance = expectedCount * 0.05; // 5% tolerance

            for (int i = 0; i < buckets.Length; i++) {
                var min = i * (maxValue - minValue) / bucketCount;
                var max = (i + 1) * (maxValue - minValue) / bucketCount;
                Assert.IsTrue(Math.Abs(buckets[i] - expectedCount) <= tolerance,
                    $"Bucket {i + 1} does not occur with expected uniform frequency. Count: {buckets[i]}, Expected: {expectedCount}");
            }
        }

        [TestMethod]
        public void NextDouble_InclusiveLowerBound() {
            double minValue = -10.0;
            double maxValue = 10.0;
            double tolerance = 0.0001;
            int iterations = 1000000;
            bool minValueGenerated = false;

            for (int i = 0; i < iterations && !minValueGenerated; i++) {
                if (Math.Abs(Generator.NextDouble(minValue, maxValue) - minValue) < tolerance) {
                    minValueGenerated = true;
                }
            }

            Assert.IsTrue(minValueGenerated, "A value close to the minimum value should be generated at least once.");
        }

        [TestMethod]
        public void NextDouble_ExclusiveUpperBound() {
            double minValue = -10.0;
            double maxValue = 10.0;
            double tolerance = 0.0001;
            int iterations = 1000000;
            bool upperBoundApproached = false;

            for (int i = 0; i < iterations && !upperBoundApproached; i++) {
                if (Math.Abs(Generator.NextDouble(minValue, maxValue) - maxValue) < tolerance) {
                    upperBoundApproached = true;
                }
            }

            Assert.IsTrue(upperBoundApproached, "A value approaching the exclusive upper bound should be generated at least once.");
        }

        #endregion Double Tests
    }
}