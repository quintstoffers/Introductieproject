using Introductieproject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Taxiway:Way
    {
        //public int[] startLocation;
        //public int[] endLocation;

        public double length
        {
            get
            {
                int deltaX = Math.Max(endLocation[0], startLocation[0]) - Math.Min(endLocation[0], startLocation[0]);
                int deltaY = Math.Max(endLocation[1], startLocation[1]) - Math.Min(endLocation[1], startLocation[1]);
                return Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
            }
        }
        
        public List<Airplane> airplanes = new List<Airplane>();
        public List<Runway> connectedRunways = new List<Runway>();
        public List<Taxiway> connectedTaxiway = new List<Taxiway>();

        public Taxiway(int[] startLocation, int[] endLocation)
        {
            this.startLocation = startLocation;
            this.endLocation = endLocation;
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

        public bool isConnectedWithTaxiway(Taxiway taxiway)
        {
            if(this.Equals(taxiway))
            {
                return false;
            }
            if (taxiway.startLocation[0] == this.startLocation[0] && taxiway.startLocation[1] == this.startLocation[1])
            {
                connectedTaxiway.Add(taxiway); 
                return true;
            }
            if (taxiway.endLocation[0] == this.endLocation[0] && taxiway.endLocation[1] == this.endLocation[1])
            {
                connectedTaxiway.Add(taxiway); 
                return true;
            }
            if (taxiway.endLocation[0] == this.startLocation[0] && taxiway.endLocation[1] == this.startLocation[1])
            {
                connectedTaxiway.Add(taxiway); 
                return true;
            }
            if (taxiway.endLocation[0] == endLocation[0] && taxiway.endLocation[1] == endLocation[1])
            {
                connectedTaxiway.Add(taxiway); 
                return true;
            }
            return false;
        }
    }
}

