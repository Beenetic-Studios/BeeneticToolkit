using BeeneticToolkit.Random;

namespace Sandbox {

    public class Sandbox {

        public Sandbox() {
            List<double> normals = new();
            for (int i = 0; i < 10000000; i++) {
                normals.Add(RNGService.NextNormal(50.0, 15.0));
            }

            Console.WriteLine($"Min:\t{normals.Min()}");
            Console.WriteLine($"Min:\t{normals.Max()}");
            Console.WriteLine($"Min:\t{normals.Average()}");
        }
    }
}