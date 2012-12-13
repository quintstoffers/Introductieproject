using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;

namespace Introductieproject.Airport
{
    class Way
    {
        public const int DIRECTION_BOTH = 0;
        public const int DIRECTION_ENDTOSTART = -1;
        public const int DIRECTION_STARTTOEND = 1;

        public IList<Node> nodeConnections = new List<Node>();

        //Bepalen in welke richting moet rijden
        public int direction;

        public Airplane airplane;

        public Way()
        {

        }

        public Way(Node node1, Node node2, int dir)
        {
            this.nodeConnections.Add(node1);
            this.nodeConnections.Add(node2);
            node1.connections.Add(this); 
            node2.connections.Add(this);
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
