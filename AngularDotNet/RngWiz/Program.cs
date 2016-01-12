using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RngWiz
{
    class Program
    {
        private const short RegularMax = 69;
        private const short PowerMax = 26;

        private static IDictionary<short, long> regularMap = new Dictionary<short, long>();

        private static IDictionary<short, long> powerMap = new Dictionary<short, long>();

        private static long iterationCount = 0;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: RngWiz <iteration-count>");
                return;
            }

            iterationCount = long.Parse(args[0]);

            var timer = Stopwatch.StartNew();
            Init();
            Vote();

            Console.WriteLine($"Finished in {timer.ElapsedMilliseconds} ms.");
        }

        private static void Init()
        {
            for (short i = 1; i <= RegularMax; i++)
            {
                regularMap.Add(i, 0L);
            }

            for (short i = 1; i <= PowerMax; i++)
            {
                powerMap.Add(i, 0L);
            }
        }

        private static void Vote()
        {
            var seed = (int)DateTime.UtcNow.Ticks % int.MaxValue;
            var rnd = new Random(seed);

            for (var i = 0; i < iterationCount; i++)
            {
                regularMap[(short)rnd.Next(1, RegularMax+1)]++;
                powerMap[(short)rnd.Next(1, PowerMax+1)]++;
            }

            const int takeCount = 5;
            Console.WriteLine("5 numbers:");
            foreach (var pair in regularMap.OrderByDescending(p => p.Value).Take(takeCount))
            {
                Console.WriteLine($"[{pair.Key}]: {pair.Value}");
            }

            var last = powerMap.OrderByDescending(p => p.Value).First();
            Console.WriteLine("Power:");
            Console.WriteLine($"[{last.Key}]: {last.Value}");
        }
    }
}
