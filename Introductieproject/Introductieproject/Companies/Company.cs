using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Objects
{
    abstract class Company
    {
        public String name;
        public float[] airplaneDistribution = new float[Airplanes.NUM_AIRPLANES];   // Array met kansen op elk vliegtuig, positi gedefinieert als constanten in Companies
    }
}
