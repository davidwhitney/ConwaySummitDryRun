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
            sim.Populate();
            while (true)
            {
                sim.Step();
                var state = sim.ToString();

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(state);

                Thread.Sleep(500);
            }
        }
    }
}
