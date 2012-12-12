using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Way
    {
        public const int DIRECTION_BOTH = 0;
        public const int DIRECTION_ENDTOSTART = -1;
        public const int DIRECTION_STARTTOEND = 1;

        public IList<Node> nodeConnections = new List<Node>();
        public IList<Way> wayConnections = new List<Way>();

        //Bepalen in welke richting moet rijden
        public int direction;

        public Way()
        {

        }

        public Way(Node node1, Node node2, int dir)
        {
            this.nodeConnections.Add(node1);
            this.nodeConnections.Add(node2);
            this.direction = dir;
        }

        public double length
        {
            get
            {
                int deltaX = Math.Max(this.nodeConnections[1].location[0], this.nodeConnections[0].location[0])
                    - Math.Min(this.nodeConnections[1].location[0], this.nodeConnections[0].location[0]);
                int deltaY = Math.Max(this.nodeConnections[1].location[1], this.nodeConnections[0].location[1]) 
                    - Math.Min(this.nodeConnections[1].location[1], this.nodeConnections[0].location[1]);
                return Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
            }
        }

        public void connectWays()
        {
            //richting 1 betekent van node 1 naar 2. Richting -1 andersom en Ricthing 0 beide kanten.

            if (this.direction == DIRECTION_BOTH || this.direction == DIRECTION_STARTTOEND)
            {
                foreach (Way w in nodeConnections[1].connections)
                {
                    this.wayConnections.Add(w);
                }
            }
            if (this.direction == DIRECTION_BOTH || this.direction == DIRECTION_ENDTOSTART)
            {
                foreach (Way w in nodeConnections[0].connections)
                {
                    this.wayConnections.Add(w);
                }
            }
        }

        public bool checkConnected(Way checkWay)
        {
            foreach (Way w in wayConnections)
            {
                if (checkWay == w)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            String returnStr = "--\nWay, direction: " + direction;
            foreach(Node node in nodeConnections)
            {
                returnStr += "\n" + node.ToString();
            }
            returnStr += "\n--";
            return returnStr;
        }
    }
}
