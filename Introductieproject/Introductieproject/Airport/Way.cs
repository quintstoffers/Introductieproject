using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Way
    {
        public IList<Node> nodeConnections;
        public IList<Way> wayConnections;

        //Bepalen in welke richting moet rijden
        public int direction;

        public Way(Node node1,Node node2,int dir)
        {
            this.nodeConnections.Add(node1);
            this.nodeConnections.Add(node2);
            this.direction = dir;
            connectWays();
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
            if (this.direction >= 0)
            {
                foreach (Way w in nodeConnections[1].connections)
                    this.wayConnections.Add(w);
            }
            if (this.direction <= 0)
            {
                foreach (Way w in nodeConnections[0].connections)
                    this.wayConnections.Add(w);
            }
        }

        public bool checkConnected(Way checkWay)
        {
            foreach (Way w in wayConnections) if (checkWay == w) return true;
            return false;
        }
    }
}
