using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;

namespace Introductieproject.Airport
{
    class Gateway:Way
    {                                                    
        //public int[] startLocation = new int[2];             
        //public int[] endLocation = new int[2];               
                                                         
        public List<Airplane> airplanes = new List<Airplane>();
        public List<Taxiway> connectedTaxiways = new List<Taxiway>();
        public List<Gate> connectedGates = new List<Gate>();

        public Gateway(int[] startLocation, int[] endLocation)
        {
            this.startLocation = startLocation;
            this.endLocation = endLocation;
        }

        /*
        * berekent de lengte van de baan (vanuit de coords)
        */
        public double length
        {
            get
            {
                int deltaX = Math.Max(this.endLocation[0], this.startLocation[0]) - Math.Min(this.endLocation[0], this.startLocation[0]);
                int deltaY = Math.Max(this.endLocation[1], this.startLocation[1]) - Math.Min(this.endLocation[1], this.startLocation[1]);
                return Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
            }
        }

        public bool isConnectedWithTaxiway(Taxiway taxiway)
        {
            //Als er 1tje direction 0 heeft heb je altijd alle mogelijkheden aangezien je de banen naar eigen inzicht kunt draaien etc
            if (taxiway.startLocation[0] == this.startLocation[0] && taxiway.startLocation[1] == this.startLocation[1])
            {
                connectedTaxiways.Add(taxiway);
                return true;
            }
            if (taxiway.startLocation[0] == this.endLocation[0] && taxiway.startLocation[1] == this.endLocation[1])
            {
                connectedTaxiways.Add(taxiway);
                return true;
            }
            if (taxiway.endLocation[0] == this.startLocation[0] && taxiway.endLocation[1] == this.startLocation[1])
            {
                connectedTaxiways.Add(taxiway);
                return true;
            }
            if (taxiway.endLocation[0] == this.endLocation[0] && taxiway.endLocation[1] == this.endLocation[1])
            {
                connectedTaxiways.Add(taxiway);
                return true;
            }
            return false;
        }

        public bool isConnectedWithGate(int[] Location, Gate gate)
        {
            if ((startLocation[0] == Location[0] && startLocation[1] == Location[1]) || (endLocation[0] == Location[0] && endLocation[1] == Location[1]))
            {
                connectedGates.Add(gate);
                return true;
            }
            return false;
        }
    }
}
