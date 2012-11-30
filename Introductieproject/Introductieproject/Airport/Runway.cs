using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Runway
    {
        public int[] startLocation = int[2];
        public int[] endLocation = int[2];

        public Airplane airplane;

        public List<Taxiway> connectedTaxiway = new List<Taxiway>();

        /*
        * berekent de lengte van de baan (vanuit de coords)
        */
        public double getLength()
        {
            throw new NotImplementedException();
        }
    }
}
