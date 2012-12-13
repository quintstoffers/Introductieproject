using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;


namespace Introductieproject.Simulation
{
    static class Simulation  
    {
        private static Airport.Airport airport;            // Het vliegveld dat bewerkt wordt door deze simulatie

        private static bool runSimulation;   // of de simulatie draait of niet
        private static bool pauseSimulation; // of de simulatie gepauzeert is

        public static int updateInterval = 1000;          // update interval van simulatie in milliseconden

        private static Thread simulationThread;

        private static Parser parser = new Parser();

        public static void initSimulation(Airport.Airport airport)
        {
            Simulation.airport = airport;

            Console.WriteLine("Simulation created");

            Console.ForegroundColor = ConsoleColor.Blue;
            parser.update();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void startSimulation()        // Start de simulatie als deze nog niet gestart is
        {
            if (!runSimulation)
            {
                if (simulationThread == null)
                {
                    simulationThread = new Thread(simulation);
                }
                runSimulation = true;
                simulationThread.Start();
            }
            else
            {
                Console.WriteLine("Attempted to start already running simulationThread");
            }
        }
        
        public static void stopSimulation()         // Stop de simulatie, no matter what
        {
            runSimulation = false;
        }

        public static void pauseSimulationToggle()  // Pauzeert of hervat de simulatie
        {
            pauseSimulation = !pauseSimulation;
            if (pauseSimulation)
            {
                Console.WriteLine("Simulation paused");
            }
            else
            {
                Console.WriteLine("Simulation unpaused");
            }
        }
    
        private static void simulation()
        {
            pauseSimulation = false;
            runSimulation = true;

            while (runSimulation == true)       // Simulatie draait terwijl runSimulation true is
            {
                while (pauseSimulation)         // Slapen terwijl de simulatie gepauzeert is.
                {
                    Thread.Sleep(1000);
                }

                TimeKeeper.updateTime();

                updateSimulation();

                Thread.Sleep(updateInterval);
            }


            Console.WriteLine("Simulation stopped");
        }

        private static void updateSimulation()
        {
            airport.simulate();
        }
    }
}
