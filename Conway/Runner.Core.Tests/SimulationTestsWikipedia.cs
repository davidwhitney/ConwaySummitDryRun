using NUnit.Framework;

namespace Runner.Core.Tests
{
    [TestFixture]
    public class SimulationTestsWikipedia
    {
        [Test]
        public void Blinker()
        {
            var sim = new Simulation();
            sim.Populate(".....\r\n" +
                         "..A..\r\n" +
                         "..A..\r\n" +
                         "..A..\r\n" +
                         ".....\r\n");

            sim.Step();
            var board = sim.ToString();


            Assert.That(board, Is.EqualTo(".....\r\n" +
                                          ".....\r\n" +
                                          ".AAA.\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n"));
        }

        [Test]
        public void Toad()
        {
            var sim = new Simulation();
            sim.Populate("......\r\n" +
                         "......\r\n" +
                         "..AAA.\r\n" +
                         ".AAA..\r\n" +
                         "......\r\n" +
                         "......\r\n");

            sim.Step();
            var board = sim.ToString();


            Assert.That(board, Is.EqualTo("......\r\n" +
                                          "...A..\r\n" +
                                          ".A..A.\r\n" +
                                          ".A..A.\r\n" +
                                          "..A...\r\n" +
                                          "......\r\n"));
        }
    }
}
