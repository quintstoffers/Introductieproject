using Introductieproject.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;

namespace Introductieproject
{
    static class Utils
    {
        public static bool isPointInWay(int[] planeLoc, Way way)
        {
            //Kijk of een vliegtuig zich bevindt tussen twee punten (van een way)
            //http://stackoverflow.com/questions/7050186/find-if-point-lay-on-line-segment
            //(x-x1)/(x2-x1)==(y-y1)/(y2-y1) voor (x,y) op lijn (x1,y1),(x2,y2)
            //Equivalent aan (x-x1)*(y2-y1)==(y-y1)*(x2-x1)
            return (double)((planeLoc[0] - way.nodeConnections[0].location[0]) * (way.nodeConnections[1].location[1] - way.nodeConnections[0].location[1]))
                == (double)((planeLoc[1] - way.nodeConnections[0].location[1]) * (way.nodeConnections[1].location[0] - way.nodeConnections[0].location[0]));
        }

        public static double getDistanceBetweenPoints(int[] point1, int[] point2)
        {
            //berekent afstand tussen twee punten: wortel((x1-x2)^2+(y1-y2)^2)
            return Math.Sqrt((double)((point1[0] - point2[0]) * (point1[0] - point2[0]) + (point1[1] - point2[1]) * (point1[1] - point2[1])));
        }

        public static Way getClosestWay(int[] startLocation, IList<Way> ways)
        {
            double distance = 1000000;
            Way closestWay = null;
            foreach (Way w in ways)
            {
                double newDistance = getDistanceBetweenPoints(startLocation,w.nodeConnections[0].location);
                if (newDistance<distance)
                {
                    distance = newDistance;
                }
            }
            foreach (Way w in ways)
            {
                if (distance == getDistanceBetweenPoints(startLocation,w.nodeConnections[0].location))
                    closestWay = w;
            }
            return closestWay;
        }
    }
}
