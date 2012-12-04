using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Objects
{
    class KLM : Company
    {
        public KLM()
        {
            name = "KLM";

            airplaneDistribution[Airplanes.BO_747] = 0.6f;      // Kans van 60%
            airplaneDistribution[Airplanes.AB_A380] = 0.4f;     // Kans van 40%
        }
    }
}
