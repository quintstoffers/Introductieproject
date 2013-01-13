using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Introductieproject.Objects;


namespace Introductieproject.Simulation
{
    static class Simulation  
    {
        private static Airport.Airport airport;             // Het vliegveld dat bewerkt wordt door deze simulatie

        private static bool runSimulation;                  // of de simulatie draait of niet
        private static bool pauseSimulation;                // of de simulatie gepauzeert is
        private static bool leaping = false;

        public static int updateInterval;                   // update interval van simulatie in milliseconden
        public static int uiUpdateTicks;                    // aantal kloktiks voordat de UI geupdatet wordt
        public static int uiUpdateInterval                  // "leesbare" ui update interval in milliseconden
        {
            get
            {
                return uiUpdateTicks * updateInterval;
            }
            set
            {
                uiUpdateTicks = value / updateInterval;
                Console.WriteLine("UpdateTIcks set to:  " + uiUpdateTicks);
            }
        }
        private static int tickCounter = 0;

        private static Thread simulationThread;

        private static Parser parser = new Parser();
        private static DateTime targetDate;

        public static void initSimulation(Airport.Airport airport)
        {
            Simulation.airport = airport;

            Console.WriteLine("Simulation created");

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

        public static void leapTo(DateTime newDate)
        {
            leaping = true;
            targetDate = newDate;

            TimeKeeper.setLeapMode(true);
        }

        // De lokale (simulatie) tijd moet hier worden opgeslagen, en op deze tijd moet ook weer worden hervat.
        public static void pauseSimulationToggle()  // Pauzeert of hervat de simulatie
        {
            pauseSimulation = !pauseSimulation;
            if (pauseSimulation)
            {
                Console.WriteLine("Simulation paused");
                TimeKeeper.save();
            }
            else
            {
                Console.WriteLine("Simulation unpaused");
                TimeKeeper.restore();
            }
        }
    
        private static void simulation()
        {
            pauseSimulation = false;
            runSimulation = true;
            Stopwatch stopwatch = new Stopwatch();

            while (runSimulation == true)               // Simulatie draait terwijl runSimulation true is
            {
                while (pauseSimulation)                 // Slapen terwijl de simulatie gepauzeert is.
                {
                    Thread.Sleep(1000);
                }

                stopwatch.Reset();
                stopwatch.Start();
                
                TimeKeeper.update();

                Parser.refreshAirplanes(airport.airplanes);

                updateSimulation();

                updateUI();

                if (leaping)
                {
                    if (TimeKeeper.currentSimTime >= targetDate)
                    {
                        TimeKeeper.setLeapMode(false);
                    }
                }
                else
                {
                    
                }

                long elapsedMillis = stopwatch.ElapsedMilliseconds;
                if (elapsedMillis < updateInterval)
                {
                    Console.WriteLine("Sleep: " + (updateInterval - elapsedMillis));
                    Thread.Sleep(updateInterval - (int)elapsedMillis);
                }
            }

            Console.WriteLine("Simulation stopped");
        }

        private static void updateSimulation()
        {
            airport.simulate();

            foreach(Airplane currentAirplane in airport.airplanes)
            {
                currentAirplane.simulate(airport);
            }
        }

        private static void updateUI()
        {
            tickCounter++;

            if (tickCounter >= uiUpdateTicks)
            {
                try
                {

                    Program.mainForm.BeginInvoke((Action)(() => Program.mainForm.updateUI()));  // BeginInvoke == asynchroon
                }
                catch (Exception) // MainForm gesloten, geen UI thread beschikbaar. Simulatie sluiten
                {
                    runSimulation = false;
                }
                tickCounter = 0;
            }
        }
    }
}
