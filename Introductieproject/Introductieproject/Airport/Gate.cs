using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Gate
    {
        public int[] location = new int[2];

        public int waitingPassengers;
        public int waitingLuggage;
        public double waitingLuggageKg;

        public Airplane airplane;
    }
}
