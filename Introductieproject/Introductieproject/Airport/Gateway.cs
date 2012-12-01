using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Gateway
    {                                                    
        public int[] startLocation = new int[2];             
        public int[] endLocation = new int[2];               
                                                         
        public List<Airplane> airplanes = new List<Airplane>();
        public List<Taxiway> connectedTaxiways = new List<Taxiway>();
        public List<Gate> connectedGates = new List<Gate>();

        /*
         * berekent de lengte van de baan (vanuit de coords)
        */
        public double getLength()
        {
            throw new NotImplementedException();
        }
    }
}
