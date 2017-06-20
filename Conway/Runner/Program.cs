using System;
using System.Threading;
using Runner.Core;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sim = new Simulation();
            while (true)
            {
                sim.Step();
                var state = sim.ToString();

                Console.Clear();
                Console.WriteLine(state);

                Thread.Sleep(100);
            }
        }
    }
}
