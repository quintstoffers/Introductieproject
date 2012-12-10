using Introductieproject.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject
{
    static class Utils
    {
        public static bool isPointInWay(int[] planeLoc, Way way)
        {
            //Kijk of een vliegtuig zich bevindt tussen twee punten (van een way)
            //http://stackoverflow.com/questions/7050186/find-if-point-lay-on-line-segment
            //(x-x1)/(x2-x1)==(y-y1)/(y2-y1) voor (x,y) op lijn (x1,y1),(x2,y2)
            double xRes = (double)((planeLoc[0] - way.startLocation[0]) / (way.endLocation[0] - way.startLocation[0]));
            double yRes = (double)((planeLoc[1] - way.startLocation[1]) / (way.endLocation[1] - way.startLocation[1]));
            return xRes == yRes;
        }

        public static double getDistanceBetweenPoints(int[] point1, int[] point2)
        {
            //berekent afstand tussen twee punten: wortel((x1-x2)^2+(y1-y2)^2)
            return Math.Sqrt((double)((point1[0] - point2[0]) * (point1[0] - point2[0]) + (point1[1] - point2[1]) * (point1[1] - point2[1])));
        }
    }
}
