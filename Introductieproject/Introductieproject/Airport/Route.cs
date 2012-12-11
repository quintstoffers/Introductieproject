using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Route
    {
        //Class Route, gebaseerd op Pad in Imperatief Programmeren Listing 65
        public Node local;
        public Route previous; //De voorafgaande Route. Is null voor de eerste
        public double length;

        public Route(Node newlocal, Route newPrevious, double newLength)
        {
            this.local = newlocal;
            this.previous = newPrevious;
            this.length = newLength;
            if (previous != null)
                this.length += previous.length;
        }

        public bool hasNode(Node checkNode)
        {
            //Kijk of een node al in de route zit, tegengaan van circulaire routes
            if (this.local == checkNode) return true;
            if (this.previous == null) return false;
            return previous.hasNode(checkNode);
        }

        public IList<Node> RouteList()
        {
            //Maak een lijst aan met Nodes van eerste Node t/m laatste
            IList<Node> routeList = new List<Node>();
            if (this.previous != null)
            {
                IList<Node> tempList = previous.RouteList();
                for (int t = 0; t < tempList.Count; t++)
                    routeList.Add(tempList[t]);
            }
            routeList.Add(local);
            return routeList;
        }
    }
}
