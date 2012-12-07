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
            int deltaX = Math.Max(endLocation[0], startLocation[0]) - Math.Min(endLocation[0], startLocation[0]);
            int deltaY = Math.Max(endLocation[1], startLocation[1]) - Math.Min(endLocation[1], startLocation[1]);
            return Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
        }

        public void isConnectedWithTaxiway(int[] startLoc, int[] endLoc)
        {
            if (startLoc[0] == startLocation[0] && startLoc[1] == startLocation[1])
            {
                connectedTaxiways.Add(Taxiway); //OOk deze is niet goed, wat moet hier komen?
            }
            if (startLoc[0] == endLocation[0] && startLoc[1] == endLocation[1])
            {
                connectedTaxiways.Add(Taxiway); //OOk deze is niet goed, wat moet hier komen?
            }
            if (endLoc[0] == startLocation[0] && endLoc[1] == startLocation[1])
            {
                connectedTaxiways.Add(Taxiway); //OOk deze is niet goed, wat moet hier komen?
            }
            if (endLoc[0] == endLocation[0] && endLoc[1] == endLocation[1])
            {
                connectedTaxiways.Add(Taxiway); //OOk deze is niet goed, wat moet hier komen?
            }
        }

        public void isConnectedWithGate(int[] Location)
        {
            if ((startLocation[0] == Location[0] && startLocation[1] == Location[1]) || (endLocation[0] == Location[0] && endLocation[1] == Location[1]))
            {
                connectedGates.Add(Gate);   //Ook deze is niet goed, wat moet hier komen?
            }
        }
    }
}
