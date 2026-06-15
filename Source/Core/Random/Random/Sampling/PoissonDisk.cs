using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Random.Sampling {

    /// <summary>
    /// Generates blue-noise point distributions via Bridson's fast Poisson-disk sampling: random points
    /// that are never closer than a minimum distance, so they look evenly scattered with no clumps or gaps.
    /// Common for placing vegetation, props, spawns, and decoration.
    /// </summary>
    public static class PoissonDisk {

        // r / sqrt(2): the largest cell whose diagonal is at most r, so each grid cell holds at most one sample.
        private const float InvSqrt2 = 0.70710678f;

        /// <summary>
        /// Samples points within a <paramref name="width"/> x <paramref name="height"/> region (origin at 0,0)
        /// such that no two points are closer than <paramref name="minDistance"/>.
        /// </summary>
        /// <param name="random">The generator to draw from; the same seeded generator yields the same point set.</param>
        /// <param name="width">The width of the region. Must be greater than 0.</param>
        /// <param name="height">The height of the region. Must be greater than 0.</param>
        /// <param name="minDistance">The minimum distance between any two points. Must be greater than 0.</param>
        /// <param name="maxAttempts">
        /// Candidates tried around each active point before it is retired (Bridson's <c>k</c>, default 30).
        /// Higher values pack points more tightly at the cost of speed. Must be at least 1.
        /// </param>
        /// <returns>
        /// The generated points (each in <c>[0, width)</c> x <c>[0, height)</c>), in generation order.
        /// Always contains at least one point.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a numeric argument is out of range.</exception>
        public static IReadOnlyList<(float X, float Y)> Sample(IRandomGenerator random, float width, float height, float minDistance, int maxAttempts = 30) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (width <= 0f)
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0.");
            if (height <= 0f)
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0.");
            if (minDistance <= 0f)
                throw new ArgumentOutOfRangeException(nameof(minDistance), "Minimum distance must be greater than 0.");
            if (maxAttempts < 1)
                throw new ArgumentOutOfRangeException(nameof(maxAttempts), "Max attempts must be at least 1.");

            float cellSize = minDistance * InvSqrt2;
            int gridW = (int)Math.Ceiling(width / cellSize);
            int gridH = (int)Math.Ceiling(height / cellSize);
            float minDistSq = minDistance * minDistance;

            // Background grid of indices into 'samples' (-1 = empty); accelerates the neighbour check.
            int[] grid = new int[gridW * gridH];
            for (int i = 0; i < grid.Length; i++)
                grid[i] = -1;

            var samples = new List<(float X, float Y)>();
            var active = new List<int>();

            AddSample((float)random.NextDouble() * width, (float)random.NextDouble() * height);

            while (active.Count > 0) {
                int activeIndex = random.NextInt(active.Count);
                (float px, float py) = samples[active[activeIndex]];
                bool placed = false;

                for (int attempt = 0; attempt < maxAttempts; attempt++) {
                    float angle = (float)(random.NextDouble() * (2.0 * Math.PI));
                    float radius = minDistance * (1f + (float)random.NextDouble()); // [r, 2r)
                    float cx = px + radius * (float)Math.Cos(angle);
                    float cy = py + radius * (float)Math.Sin(angle);

                    if (cx < 0f || cx >= width || cy < 0f || cy >= height)
                        continue;
                    if (!IsFarEnough(cx, cy))
                        continue;

                    AddSample(cx, cy);
                    placed = true;
                    break;
                }

                if (!placed) {
                    // Retire this point: swap-remove from the active list.
                    active[activeIndex] = active[active.Count - 1];
                    active.RemoveAt(active.Count - 1);
                }
            }

            return samples;

            void AddSample(float x, float y) {
                int index = samples.Count;
                samples.Add((x, y));
                active.Add(index);
                grid[(int)(y / cellSize) * gridW + (int)(x / cellSize)] = index;
            }

            bool IsFarEnough(float x, float y) {
                int gx = (int)(x / cellSize);
                int gy = (int)(y / cellSize);
                int x0 = Math.Max(0, gx - 2);
                int x1 = Math.Min(gridW - 1, gx + 2);
                int y0 = Math.Max(0, gy - 2);
                int y1 = Math.Min(gridH - 1, gy + 2);

                for (int yy = y0; yy <= y1; yy++) {
                    for (int xx = x0; xx <= x1; xx++) {
                        int idx = grid[yy * gridW + xx];
                        if (idx < 0)
                            continue;

                        (float sx, float sy) = samples[idx];
                        float dx = sx - x;
                        float dy = sy - y;
                        if (dx * dx + dy * dy < minDistSq)
                            return false;
                    }
                }

                return true;
            }
        }
    }
}
