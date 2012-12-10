using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Route
    {
        //Class Route. Slaat Ways op, samen met lengte van ways. Helpt bij routering
        List<Way> waypoints;
        double length = 0;

        public Route()
        {
        }

        public bool HasWay(Way newWay)
        {
            //Kijk of een way al in de route zit, tegengaan van circulaire routes
            bool hasWay = false;
            foreach (Way w in this.waypoints) if (w == newWay) hasWay = true;
            return hasWay;
        }

        public void AddWay(Way newWay)
        {
            this.waypoints.Add(newWay);
            this.length += newWay.length;
        }
    }
}
