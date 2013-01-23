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

        public static double targetLeapScale = 300;
        public static double targetScale;
        public static double currentScale
        {
            get
            {
                return scale;
            }
        }
        private static double scale;
        private static double Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;

                Simulation.updateInterval = (int)(1000 / scale);
            }
        }                   // Verhouding tussen echte tijd en simulatietijd. >1 = sneller, <1 = langzamer

        public static void init()
        {
            currentRealTime = DateTime.Now;
            currentSimTime = DateTime.Now;
            totalElapsedRealTimeTicks = 0;
            totalElapsedSimTimeTicks = 0;

            Scale = targetScale;

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

            Scale = targetScale;
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

        private static double oldTargetScale;
        public static void setLeapMode(Boolean leap)
        {
            if (leap)
            {
                oldTargetScale = targetScale;
                targetScale = targetLeapScale;
            }
            else
            {
                targetScale = oldTargetScale;
            }
        }

        public static void tuneScale(bool up)
        {
            if (up)
            {
                if (scale < targetScale)
                {
                    Scale += 0.5;
                }
                else
                {
                    Scale = targetScale;
                }
            }
            else
            {
                Scale -= 1;
            }
        }
    }
}
