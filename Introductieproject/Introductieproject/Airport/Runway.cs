using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Runway
    {
        public int[] startLocation = new int[2];
        public int[] endLocation = new int[2];

        public Airplane airplane;

        public List<Taxiway> connectedTaxiway = new List<Taxiway>();

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
            //Ik wil het zo doen dat een runway alleen verbonden is met de taxiway die van de runway weggaat, dus een taxiway die naar een runway toegaat is wel verbonden met de runway
            //Maar de runway is niet verbonden met die taxiway, en andersom ook.
            if (startLoc[0] == endLocation[0] && startLoc[1] == endLocation[1])
            {
                connectedTaxiway.Add(Taxiway); //Dit klopt niet maar weet niet wat hier moet komen :S
            }
        }
    }
}
