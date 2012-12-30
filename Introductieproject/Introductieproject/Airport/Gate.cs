using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;

namespace Introductieproject.Airport
{
    public class Gate:Way
    {
        public Gate(Node node1, Node node2, int dir) : base(node1, node2, dir)
        {
        }

        //public int[] location = new int[2]; startlocation en endlocation ipv location want subklasse van Way. Consistentie

        public int waitingPassengers;
        public int waitingLuggage;
        public double waitingLuggageKg;

        public string gateName;
    }
}
