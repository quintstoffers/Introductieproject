using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;
using Introductieproject.Airplanes;
using Introductieproject.Simulation;

namespace Introductieproject.Airport
{
    public class Way
    {
        public const int DIRECTION_BOTH = 0;
        public const int DIRECTION_ENDTOSTART = -1;
        public const int DIRECTION_STARTTOEND = 1;
        public string name;

        public Node[] nodeConnections = new Node[2];

        //Bepalen in welke richting gereden moet worden
        public int direction;
        public int angle;

        public double weightedLength;

        //public List<Navigator> navigatorList = new List<Navigator>();

       // public Airplane airplane;

        public long timeOccupiedTicks = 0;
        public double Occupancy
        {
            get
            {
                if (TimeKeeper.totalElapsedSimTimeTicks > 0)
                {
                    double occ = (double)timeOccupiedTicks / ((double)TimeKeeper.totalElapsedSimTimeTicks / 2);
                    if (occ > 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return occ;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public void updateOccupancy(long occupiedTicks)
        {
            timeOccupiedTicks += occupiedTicks;
        }
        
        public Way()
        {
        }

        public Way(Node node1, Node node2, int dir, string name)
        {
            this.nodeConnections[0] = node1;
            this.nodeConnections[1] = node2;
            node1.connections.Add(this); 
            node2.connections.Add(this);
            this.direction = dir;
            this.name = name;
        }

        public void simulate()
        {
           //TODO update timeOccupied (probs in Airport) timeOccupiedTicks += TimeKeeper.elapsedSimTime.Ticks;
        }

        public double length
        {
            get
            {
                double deltaX = Math.Max(this.nodeConnections[1].location[0], this.nodeConnections[0].location[0])
                    - Math.Min(this.nodeConnections[1].location[0], this.nodeConnections[0].location[0]);
                double deltaY = Math.Max(this.nodeConnections[1].location[1], this.nodeConnections[0].location[1]) 
                    - Math.Min(this.nodeConnections[1].location[1], this.nodeConnections[0].location[1]);
                return Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
            }
        }

        public override string ToString()
        {
            String returnStr = "WAY: direction: " + direction;
            foreach(Node node in nodeConnections)
            {
                returnStr += " " + node.ToString();
            }
            return returnStr;
        }
    }
}
