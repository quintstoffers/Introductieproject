using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Route
    {
        //Class Route, gebaseerd op Pad in Imperatief Programmeren Listing 65
        public Way local;
        public Route previous; //De voorafgaande Route. Is null voor de eerste
        public double length;

        public Route(Way newlocal, Route newPrevious, double newLength)
        {
            this.local = newlocal;
            this.previous = newPrevious;
            this.length = newLength;
            if (previous != null)
                this.length += previous.length;
        }

        public bool HasWay(Way checkWay)
        {
            //Kijk of een way al in de route zit, tegengaan van circulaire routes
            if (this.local == checkWay) return true;
            if (this.previous == null) return false;
            return previous.HasWay(checkWay);
        }

        public IList<int[]> RouteList()
        {
            //Maak een lijst aan met coordinaten. Voeg eerst punten van voorafgaande Routes toe, voeg dan startlocatie toe van bijbehorende Way
            //Gaat dus alle voorafgaande routes af naar 1e. Vanaf dat punt bouwt het een lijst op van coordinaten, de waypoints voor een vliegtuig
            IList<int[]> routeList = new List<int[]>();
            if (this.previous != null)
            {
                IList<int[]> tempList = previous.RouteList();
                for (int t = 0; t < tempList.Count; t++)
                    routeList.Add(tempList[t]);
            }
            routeList.Add(local.startLocation);
            return routeList;
        }
    }
}
