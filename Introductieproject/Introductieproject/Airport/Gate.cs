using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;

namespace Introductieproject.Airport
{
    class Gate:Way
    {
        public int[] location = new int[2];

        public int waitingPassengers;
        public int waitingLuggage;
        public double waitingLuggageKg;

        public Airplane airplane;

        public string gateName;
    }
}
