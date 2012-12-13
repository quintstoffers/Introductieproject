using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;


namespace Introductieproject.Simulation
{
    class Simulation  
    {
        Airport.Airport airport;    // Het vliegveld dat bewerkt wordt door deze simulatie

        public static bool runSimulation;    // of de simulatie draait of niet
        public static bool pauseSimulation;  // of de simulatie gepauzeert is

        int updateinterval = 1; // update interval van simulatie in sec.

        Stopwatch rekentijd = new Stopwatch();

        Stopwatch simulatieklok = new Stopwatch();

        Thread simulationThread;

        int aantalstappen = -60; //snelheid waarmee de simulatie draait, realtime = 1 stap per keer. Dit is anders dan de update snelheid!

        TimeKeeper timekeeper = new TimeKeeper();
        DateTime huidigetijd;
        Parser parser = new Parser();

        public Simulation(Airport.Airport airport)
        {
            Console.WriteLine("Simulation created");
            this.airport = airport;

            simulationThread = new Thread(simulation);

            startSimulation();
            Console.ForegroundColor = ConsoleColor.Blue;
            parser.update();
            Console.ForegroundColor = ConsoleColor.White;
        }

        void startSimulation()
        {
            Console.WriteLine("Simulation started");

            simulatieklok.Start();
            simulationThread.Start();

            huidigetijd = DateTime.Now;
        }

        void stopsimulatie()
        {
            Console.WriteLine("Simulation stopped");

            simulatieklok.Stop();
            runSimulation = false;
        }

        void pauseSimulationToggle()
        {
            pauseSimulation = !pauseSimulation;
            if (pauseSimulation)
            {
                Console.WriteLine("Simulation paused");
                simulatieklok.Stop();
            }
            else
            {
                Console.WriteLine("Simulation unpaused");
                simulatieklok.Start();
            }
        }
    
        void simulation()
        {
            pauseSimulation = false;
            runSimulation = true;

            while (runSimulation == true)       // Simulatie draait terwijl runSimulation true is
            {
                while (pauseSimulation)         // Slapen terwijl de simulatie gepauzeert is.
                {
                    Thread.Sleep(1000);
                }

                rekentijd.Restart();
                huidigetijd = huidigetijd.AddSeconds(aantalstappen);

                updateSimulation(aantalstappen);

                Thread.Sleep(updateinterval * 1000);
            } 
        }

        void updateSimulation(int aantalstappen)
        {
            Console.WriteLine("Simulation clocktick");


            double ellapsedSimTime = aantalstappen * updateinterval * 1000; // Verlopen echte tijd omrekenen naar verlopen sim tijd

            airport.simulate(ellapsedSimTime);
        }
    }
}
