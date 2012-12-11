using Introductieproject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Runway:Way
    {
        
        //public int[] startLocation = new int[2];
        //public int[] endLocation = new int[2];

        /*public Airplane airplane;

        public List<Taxiway> connectedTaxiway = new List<Taxiway>();

        public Runway()
        {
        }
        */
        /*
        * berekent de lengte van de baan (vanuit de coords)
        */
        /*
        public double length
        {
            get
            {
                int deltaX = Math.Max(this.connections[1].x, this.connections[0].x) - Math.Min(this.connections[1].x, this.connections[0].x);
                int deltaY = Math.Max(this.connections[1].y, this.connections[0].y) - Math.Min(this.connections[1].y, this.connections[0].y);
                return Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
            }
        }

        public bool isConnectedWithTaxiway(Taxiway taxiway)
        {
            //Ik wil het zo doen dat een runway alleen verbonden is met de taxiway die van de runway weggaat, dus een taxiway die naar een runway toegaat is wel verbonden met de runway
            //Maar de runway is niet verbonden met die taxiway, en andersom ook.

            //Ga ervan uit dat runway altijd direction 1 is
            //Direction -1 = van eind naar begin, dus dat hij van de start van de runway terug gaat
            if (taxiway.direction == -1)
            {
                if (taxiway.endLocation[0] == this.endLocation[0] && taxiway.endLocation[1] == this.endLocation[1])
                {
                    connectedTaxiway.Add(taxiway);
                    return true;
                }
            }
            
            //Direction 0 = beide kanten op
            if (taxiway.direction == 0)
            {
                if (taxiway.endLocation[0] == this.startLocation[0] && taxiway.endLocation[1] == this.startLocation[1])
                {
                    connectedTaxiway.Add(taxiway);
                    return true;
                }
                if (taxiway.endLocation[0] == this.endLocation[0] && taxiway.endLocation[1] == this.endLocation[1])
                {
                    connectedTaxiway.Add(taxiway);
                    return true;
                }
                if (taxiway.startLocation[0] == this.startLocation[0] && taxiway.startLocation[1] == this.startLocation[1])
                {
                    connectedTaxiway.Add(taxiway);
                    return true;
                }
                if (taxiway.startLocation[0] == this.endLocation[0] && taxiway.startLocation[1] == this.endLocation[1])
                {
                    connectedTaxiway.Add(taxiway);
                    return true;
                }
            }

            //Direction 1 = van begin naar einde
            if (taxiway.direction == 1)
            {
                if (taxiway.endLocation[0] == this.startLocation[0] && taxiway.endLocation[1] == this.startLocation[1])
                {
                    connectedTaxiway.Add(taxiway);
                    return true;
                }
            }
            return false;
        }
        */
    }
}
