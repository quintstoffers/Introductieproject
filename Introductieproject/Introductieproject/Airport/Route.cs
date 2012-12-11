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

        public IList<Way> RouteList()
        {
            //Maak een lijst aan met ways voor een Airplane
            //Belangrijk: Zorg er voor dat een lijst met Ways daadwerkelijk wordt aangemaakt. Vindt manier om van Node naar bijbehorende en correcte Way te gaan
            IList<Way> routeList = new List<Way>();
            if (this.previous != null)
            {
                IList<Way> tempList = previous.RouteList();
                for (int t = 0; t < tempList.Count; t++)
                    routeList.Add(tempList[t]);
            }
            //routeList.Add();
            return routeList;
        }
    }
}
