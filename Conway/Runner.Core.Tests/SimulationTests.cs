﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Runner.Core.Tests
{
    [TestFixture]
    public class SimulationTests
    {
        [Test]
        public void Ctor_GivenDimensions_DrawsGameboard()
        {
            var sim = new Simulation(5);

            var board = sim.ToString();

            Assert.That(board, Is.EqualTo(".....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n"));
        }

        [Test]
        public void Populate_HalfOrLessCellsSettoAlive()
        {
            var sim = new Simulation(5);
            sim.Populate();

            var board = sim.ToString();
            var numberOfLivingCells = board.Count(x => x == 'A');

            Assert.That(numberOfLivingCells, Is.GreaterThan(0));
            Assert.That(numberOfLivingCells, Is.LessThan(12));
        }

        [Test]
        public void Populate_GivenSomeState_ReflectsOnScreen()
        {
            var sim = new Simulation();
            sim.Populate("A....\r\n" +
                         ".....\r\n" +
                         ".....\r\n" +
                         ".....\r\n" +
                         ".....\r\n");

            var board = sim.ToString();

            Assert.That(board, Is.EqualTo("A....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n"));
        }

        [Test]
        public void Step_CellHasMoreThanTwoLivingNeighbours_Dies()
        {
            var sim = new Simulation();
            sim.Populate("AA...\r\n" +
                         "AA...\r\n" +
                         ".....\r\n" +
                         ".....\r\n" +
                         ".....\r\n");

            sim.Step();
            var board = sim.ToString();


            Assert.That(board, Is.EqualTo(".A...\r\n" +
                                          "A....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n"));
        }

        [Test]
        public void Step_CellHas2Neighbours_Lives()
        {
            var sim = new Simulation();
            sim.Populate("AA...\r\n" +
                         "A....\r\n" +
                         ".....\r\n" +
                         ".....\r\n" +
                         ".....\r\n");

            sim.Step();
            var board = sim.ToString();


            Assert.That(board, Is.EqualTo("A....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n"));
        }

        [Test]
        public void Step_Dead_HasThreeNeighbours_Lives()
        {
            var sim = new Simulation();
            sim.Populate(".A...\r\n" +
                         "AA...\r\n" +
                         ".....\r\n" +
                         ".....\r\n" +
                         ".....\r\n");

            sim.Step();
            var board = sim.ToString();


            Assert.That(board, Is.EqualTo(".....\r\n" +
                                          ".AA..\r\n" +
                                          ".A...\r\n" +
                                          ".....\r\n" +
                                          ".....\r\n"));
        }
    }
}