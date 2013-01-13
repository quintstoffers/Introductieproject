using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Introductieproject.Simulation
{
    static class TimeKeeper                           // Een static class, er kan immers maar één tijd zijn!
    {
        public static DateTime currentRealTime;       // Tijd in echte wereld
        public static DateTime currentSimTime;        // Tijd in gesimuleerde wereld

        public static long totalElapsedRealTimeTicks;
        public static long totalElapsedSimTimeTicks;
        public static TimeSpan elapsedRealTime;       // Verstreken echte tijd sinds vorige kloktik
        public static TimeSpan elapsedSimTime;        // Idem voor de gesimuleerde wereld

        private static double scale;
        public static double Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;

                Simulation.updateInterval = (int)(1000 / scale);
                Simulation.uiUpdateInterval = 1000;
            }
        }                   // Verhouding tussen echte tijd en simulatietijd. >1 = sneller, <1 = langzamer

        public static void init()
        {
            currentRealTime = DateTime.Now;
            currentSimTime = DateTime.Now;
            totalElapsedRealTimeTicks = 0;
            totalElapsedSimTimeTicks = 0;

            Console.WriteLine("Timekeeper set: " + currentRealTime);
        }
        public static void init(DateTime simulationStartTime, bool resetElapsedTime)   // Constructor die de simulatie op een bepaald tijdstip laat starten
        {
            currentRealTime = DateTime.Now;
            currentSimTime = simulationStartTime;
            if (resetElapsedTime)
            {
                totalElapsedRealTimeTicks = 0;
                totalElapsedSimTimeTicks = 0;
            }
            Console.WriteLine("Timekeeper set        : " + currentRealTime);
            Console.WriteLine("Simulation starting on: " + currentRealTime);
        }

        public static void update()
        {
            DateTime updatedRealTime = DateTime.Now;                            // Huidige tijd pakken

            elapsedRealTime = updatedRealTime.Subtract(currentRealTime);        // Verschil tussen de geupdate tijd en de vorige tijd (de verstreken tijd dus)
            long elapsedRealTimeTicks = elapsedRealTime.Ticks;                  // De verstreken tijd omrekenen naar een bewerkbare eenheid
            long elapsedSimTimeTicks = (long) (elapsedRealTimeTicks * scale);   // De verstreken tijd vermenigvuldigen met de schaal 7
            elapsedSimTime = new TimeSpan(elapsedSimTimeTicks);                 // De bewerkbare eenheid naar een TimeSpan omrekenen voor DateTime

            currentSimTime = currentSimTime.Add(elapsedSimTime);                // De verstreken simulatietijd optellen bij de laatst bekende simtime
            currentRealTime = updatedRealTime;                                  // currentRealTime updaten met de nieuwe tijd

            totalElapsedRealTimeTicks += elapsedRealTimeTicks;
            totalElapsedSimTimeTicks += elapsedSimTimeTicks;

            //Console.WriteLine("Time updated. elapsedRT: " + elapsedRealTime + ", elapsedST: " + elapsedSimTime);
            Console.WriteLine("currentSimTime: " + currentSimTime + ", currentRealTime: " + currentRealTime);

        }

        private static DateTime savedSimTime;
        public static void save()
        {
            savedSimTime = currentSimTime;
        }

        public static void restore()
        {
            if (savedSimTime != null)
            {
                TimeKeeper.init(savedSimTime, false);
            }
            else
            {
                TimeKeeper.init();
            }
        }

        private static double oldScale;
        public static void setLeapMode(Boolean leap)
        {
            if (leap)
            {
                oldScale = scale;
                Scale = 100;
            }
            else
            {
                Scale = oldScale;
            }
        }
    }
}
