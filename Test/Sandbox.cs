using BeeneticToolkit.Random;

namespace Sandbox {

    public class Sandbox {

        public Sandbox() {
            var random1 = RandomGeneratorFactory.GetGenerator();
            Console.WriteLine($"First:\t{random1.NextBool()}\t{random1.NextBool()}\t{random1.NextBool()}\t{random1.NextBool()}\t{random1.NextBool()}\t{random1.NextInt(100)} | {random1.NextInt(100)} | {random1.NextInt(100)}");

            var random2 = RandomGeneratorFactory.GetGenerator();
            Console.WriteLine($"Secon:\t{random2.NextBool()}\t{random2.NextBool()}\t{random2.NextBool()}\t{random2.NextBool()}\t{random2.NextBool()}\t{random2.NextInt(100)} | {random2.NextInt(100)} | {random2.NextInt(100)}");

            var random3 = RandomGeneratorFactory.GetGenerator();
            Console.WriteLine($"Third:\t{random3.NextBool()}\t{random3.NextBool()}\t{random3.NextBool()}\t{random3.NextBool()}\t{random3.NextBool()}\t{random3.NextInt(100)} | {random3.NextInt(100)} | {random3.NextInt(100)}");
            Console.WriteLine("\n\n");

            Dictionary<int, List<double>> normals = new();
            for (int j = 0; j < 20; j++) {
                normals.Add(j, new List<double>());
                for (int i = 0; i < 1000000; i++) {
                    normals[j].Add(random1.NextNormal());
                }
            }

            List<double> mins = new();
            List<double> maxs = new();
            List<double> avgs = new();

            for (int j = 0; j < 10; j++) {
                mins.Add(normals[j].Min());
                maxs.Add(normals[j].Max());
                avgs.Add(normals[j].Average());

                Console.WriteLine($"{j + 1} Min:\t{normals[j].Min()}");
                Console.WriteLine($"{j + 1} Max:\t{normals[j].Max()}");
                Console.WriteLine($"{j + 1} Avg:\t{normals[j].Average()}\n");
            }

            Console.WriteLine($"Min:\t{mins.Min()}");
            Console.WriteLine($"Max:\t{maxs.Max()}");
            Console.WriteLine($"Avg:\t{avgs.Average()}");
        }
    }
}