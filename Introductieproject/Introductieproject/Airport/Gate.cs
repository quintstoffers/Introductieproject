using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;

namespace Introductieproject.Airport
{
    class Gate:Way
    {
        public Gate(Node node1, Node node2, int dir)
        {
            this.nodeConnections.Add(node1);
            this.nodeConnections.Add(node2);
            this.direction = dir;
        }

        //public int[] location = new int[2]; startlocation en endlocation ipv location want subklasse van Way. Consistentie

        public int waitingPassengers;
        public int waitingLuggage;
        public double waitingLuggageKg;

        public Airplane airplane;

        public string gateName;
    }
}
