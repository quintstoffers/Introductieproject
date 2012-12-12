using Introductieproject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Taxiway:Way
    {
        public Taxiway(Node node1, Node node2, int dir)
        {
            this.nodeConnections.Add(node1);
            this.nodeConnections.Add(node2);
            this.direction = dir;
        }
        //public int[] startLocation;
        //public int[] endLocation;
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
        
        public List<Airplane> airplanes = new List<Airplane>();
        public List<Runway> connectedRunways = new List<Runway>();
        public List<Taxiway> connectedTaxiway = new List<Taxiway>();

        public Taxiway(int[] startLocation, int[] endLocation)
        {
            this.startLocation = startLocation;
            this.endLocation = endLocation;
        }

        public bool isConnectedWithRunway(Runway runway)
        {
            // -1 direction is van eind naar begin
            if (this.direction == -1)
            {
                if (runway.endLocation[0] == this.endLocation[0] && runway.endLocation[1] == this.endLocation[1])
                {
                    connectedRunways.Add(runway);
                    return true;
                }
            }

            //0 direction is beide kanten
            if (this.direction == 0)
            {
                if (runway.startLocation[0] == this.startLocation[0] && runway.startLocation[1] == this.startLocation[1])
                {
                    connectedRunways.Add(runway);
                    return true;
                }
                if (runway.startLocation[0] == this.endLocation[0] && runway.startLocation[1] == this.endLocation[1])
                {
                    connectedRunways.Add(runway);
                    return true;
                }
                if (runway.endLocation[0] == this.startLocation[0] && runway.endLocation[1] == this.startLocation[1])
                {
                    connectedRunways.Add(runway);
                    return true;
                }
                if (runway.endLocation[0] == this.endLocation[0] && runway.endLocation[1] == this.endLocation[1])
                {
                    connectedRunways.Add(runway);
                    return true;
                }
            }

            //1 direction is begin naar eind
            if (this.direction == 1)
            {
                if (runway.startLocation[0] == this.endLocation[0] && runway.startLocation[1] == this.endLocation[1])
                {
                    connectedRunways.Add(runway);
                    return true;
                }
            }
            return false;
        }

        public bool isConnectedWithTaxiway(Taxiway taxiway)
        {
            if(this.Equals(taxiway))
            {
                return false;
            }

            //Voor allebei moet je nu met de directions rekening houden dus je hebt 9 mogelijkheden.
            if ((this.direction == -1 && taxiway.direction == -1) || (this.direction == 1 && taxiway.direction == 1))
            {
                if (taxiway.endLocation[0] == this.startLocation[0] && taxiway.endLocation[1] == this.startLocation[1])
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

            if ((this.direction == -1 && taxiway.direction == 1) || (this.direction == 1 && taxiway.direction == -1))
            {
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
            }

            if ((this.direction == 0 && (taxiway.direction == -1 || taxiway.direction == 0 || taxiway.direction == 1)) || (this.direction == 1 && taxiway.direction == 0) || (this.direction == -1 && taxiway.direction == 0))
            {
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
            }
            return false;
        }
         */
    }
}

