using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;
using Introductieproject.Airplanes;

namespace Introductieproject.Airport
{
    class Way
    {
        public const int DIRECTION_BOTH = 0;
        public const int DIRECTION_ENDTOSTART = -1;
        public const int DIRECTION_STARTTOEND = 1;

        public bool isReserved = false;

        public IList<Node> nodeConnections = new List<Node>();

        //Bepalen in welke richting moet rijden
        public int direction;
        public int angle;

        public bool hasAirplane = false;

        public bool runwayHasAirplane = false;

        public List<Navigator> navigatorList = new List<Navigator>();

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

        public void removeNavigator(Navigator navigator)
        {
            //Verwijdert een specifieke navigator uit de lijst en update de hasAirplane
            for (int t = 0; t < this.navigatorList.Count; t++)
            {
                if (this.navigatorList[t] == navigator)
                {
                    navigatorList.RemoveAt(t);
                    break;
                }
            }
            if (navigatorList.Count > 0)
                hasAirplane = true;
            else hasAirplane = false;
        }

        public void addNavigator(Navigator navigator)
        {
            this.navigatorList.Add(navigator);
            if (navigatorList.Count > 0)
                hasAirplane = true;
            else hasAirplane = false;
        }
    }
}
