using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Taxiway
    {
        public int[] startLocation;
        public int[] endLocation;
        
        public List<Airplane> airplanes = new List<Airplane>();
        public List<Runway> connectedRunways = new List<Runway>();
        public List<Taxiway> connectedTaxiway = new List<Taxiway>();

        public Taxiway(int[] startLocation, int[] endLocation)
        {
            this.startLocation = startLocation;
            this.endLocation = endLocation;
        }

        /*
        * berekent de lengte van de baan (vanuit de coords)
        */
        public double getLength()
        {
            int deltaX = Math.Max(endLocation[0], startLocation[0]) - Math.Min(endLocation[0], startLocation[0]);
            int deltaY = Math.Max(endLocation[1], startLocation[1]) - Math.Min(endLocation[1], startLocation[1]);
            return Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
        }

        public bool isConnectedWithRunway(int[] startLoc, int[] endLoc, Runway runway)
        {
            if (startLoc[0] == startLocation[0] && endLoc[0] == endLocation[0])
            {
                connectedRunways.Add(runway);   //Wat moet hier komen?
                return true;
            }
            return false;
        }

        public bool isConnectedWithTaxiway(int[] startLoc, int[] endLoc, Taxiway taxiway)
        {
            if (startLoc[0] == startLocation[0] && startLoc[1] == startLocation[1])
            {
                connectedTaxiway.Add(taxiway); 
                return true;
            }
            if (startLoc[0] == endLocation[0] && startLoc[1] == endLocation[1])
            {
                connectedTaxiway.Add(taxiway); 
                return true;
            }
            if (endLoc[0] == startLocation[0] && endLoc[1] == startLocation[1])
            {
                connectedTaxiway.Add(taxiway); 
                return true;
            }
            if (endLoc[0] == endLocation[0] && endLoc[1] == endLocation[1])
            {
                connectedTaxiway.Add(taxiway); 
                return true;
            }
            return false;
        }
    }
}

