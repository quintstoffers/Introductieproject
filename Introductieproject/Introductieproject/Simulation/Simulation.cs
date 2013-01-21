using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using Introductieproject.Objects;
using Introductieproject.Forms;


namespace Introductieproject.Simulation
{
    static class Simulation  
    {
        private static Airport.Airport airport;             // Het vliegveld dat bewerkt wordt door deze simulatie

        private static bool runSimulation;                  // of de simulatie draait of niet
        private static bool pauseSimulation;                // of de simulatie gepauzeert is
        private static bool leaping = false;
        private static bool popup = false;

        private static bool multiThreadingEnabled;

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
            }
        }

        private static Thread simulationThread;
        private static Thread uiUpdaterThread;

        private static Parser parser = new Parser();
        private static DateTime targetDate;

        public static void initSimulation(Airport.Airport airport, Boolean enableMultiThreading)
        {
            Simulation.airport = airport;
            Simulation.multiThreadingEnabled = enableMultiThreading;

            Console.WriteLine("Simulation created");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void startSimulation()        // Start de simulatie als deze nog niet gestart is
        {
            if (!runSimulation)
            {
                if (multiThreadingEnabled)
                {
                    ThreadPool.SetMaxThreads(Environment.ProcessorCount + 1, Environment.ProcessorCount + 1);
                }
                if (simulationThread == null)
                {
                    simulationThread = new Thread(simulation);
                }
                if (uiUpdaterThread == null)
                {
                    uiUpdaterThread = new Thread(uiUpdater);
                }
                runSimulation = true;
                simulationThread.Start();
                uiUpdaterThread.Start();
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

                updateSimulation();

                if (leaping)
                {
                    if (TimeKeeper.currentSimTime >= targetDate)
                    {
                        TimeKeeper.setLeapMode(false);
                    }
                }

                long elapsedMillis = stopwatch.ElapsedMilliseconds;
                Console.WriteLine("Sleep: " + (updateInterval - elapsedMillis));
                if (elapsedMillis <= updateInterval)
                {
                    Thread.Sleep((int) (updateInterval - elapsedMillis));
                    TimeKeeper.tuneScale(true);
                }
                else
                {
                    TimeKeeper.tuneScale(false);
                }
            }

            Console.WriteLine("Simulation stopped");
        }

        private static void uiUpdater()
        {
            while (runSimulation)
            {
                Thread.Sleep(1000);

                updateNonUrgent();
                foreach (Airplane airplane in airport.airplanes)
                {
                    if (airplane.isWaiting && (!popup && airplane.askAgain))
                    {
                        popup = true;
                        Thread newThread = new Thread(() => showAsyncPopup(airplane));
                        newThread.Start();
                    }
                }
            }
        }

        private static void showAsyncPopup(Airplane airplane)
        {
            //pauseSimulationToggle();
            DialogResult res = MessageBox.Show("Vliegtuig met registratie " + airplane.registration + " komt eerder aan bij een gate dan dat deze vrij is, wilt u de gate veranderen?", "Gate bezet", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                ScheduleForm scheduleForm = new ScheduleForm(airport);
                scheduleForm.selectedAirplane = airplane;
                scheduleForm.loadPLanes();
                Program.mainForm.Invoke((Action)(() => scheduleForm.ShowDialog()));
                scheduleForm.Focus();
            }
            if (res == DialogResult.No)
            {
                airplane.askAgain = false;
                //pauseSimulationToggle();
            }

            popup = false;
        }

        private static int tasksDone;
        private static int tasksStarted;
        private static void updateSimulation()
        {
            Parser.refreshAirplanes(airport.airplanes);

            if (multiThreadingEnabled)
            {
                tasksDone = 0;
                tasksStarted = 0;

                new Thread(() => airport.simulate()).Start();

                foreach (Airplane currentAirplane in airport.airplanes)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(simulateAirplane), currentAirplane);
                    tasksStarted++;
                }
                while (tasksDone < tasksStarted)
                {
                }
            }
            else
            {
                airport.simulate();

                foreach (Airplane currentAirplane in airport.airplanes)
                {
                    currentAirplane.simulate(airport);
                }
            }
        }
        private static void simulateAirplane(object airplane)
        {
            ((Airplane)airplane).simulate(airport);
            tasksDone++;
        }

        private static void updateNonUrgent()
        {
            try
            {
                Program.mainForm.Invoke((Action)(() => Program.mainForm.updateUI()));
            }
            catch (Exception)
            {
                runSimulation = false;
            }
     
        }
    }
}
