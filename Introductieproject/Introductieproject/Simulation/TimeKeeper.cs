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

        public static TimeSpan elapsedRealTime;       // Verstreken echte tijd sinds vorige kloktik
        public static TimeSpan elapsedSimTime;        // Idem voor de gesimuleerde wereld

        public static double scale;                   // Verhouding tussen echte tijd en simulatietijd. >1 = sneller, <1 = langzamer

        public static void initTime()
        {
            currentRealTime = DateTime.Now;
            currentSimTime = DateTime.Now;

            Console.WriteLine("Timekeeper set: " + currentRealTime);
        }

        public static void initTime(DateTime simulationStartTime)   // Constructor die de simulatie op een bepaald tijdstip laat starten
        {
            currentRealTime = DateTime.Now;
            currentSimTime = simulationStartTime;
            Console.WriteLine("Timekeeper set        : " + currentRealTime);
            Console.WriteLine("Simulation starting on: " + currentRealTime);
        }

        public static void updateTime()
        {
            DateTime updatedRealTime = DateTime.Now;                            // Huidige tijd pakken

            elapsedRealTime = updatedRealTime.Subtract(currentRealTime);        // Verschil tussen de geupdate tijd en de vorige tijd (de verstreken tijd dus)
            long elapsedRealTimeTicks = elapsedRealTime.Ticks;                  // De verstreken tijd omrekenen naar een bewerkbare eenheid
            long elapsedSimTimeTicks = (long) (elapsedRealTimeTicks * scale);   // De verstreken tijd vermenigvuldigen met de schaal 7
            elapsedSimTime = new TimeSpan(elapsedSimTimeTicks);                 // De bewerkbare eenheid naar een TimeSpan omrekenen voor DateTime

            currentSimTime = currentSimTime.Add(elapsedSimTime);                // De verstreken simulatietijd optellen bij de laatst bekende simtime
            currentRealTime = updatedRealTime;                                  // currentRealTime updaten met de nieuwe tijd

            //Console.WriteLine("Time updated. elapsedRT: " + elapsedRealTime + ", elapsedST: " + elapsedSimTime);
            Console.WriteLine("currentSimTime: " + currentSimTime + ", currentRealTime: " + currentRealTime);
        }
    }
}
