using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Taxiway
    {
        public int[] startLocation = new int[2];
        public int[] endLocation = new int[2];
        
        public List<Airplane> airplanes = new List<Airplane>();
        public List<Runway> connectedRunways = new List<Runway>();
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

