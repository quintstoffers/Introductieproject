using Introductieproject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Objects
{
    class BO_747 : Airplane
    {
        public BO_747()
        {
            type = Airplanes.BO_747;
            company = null;
            manufacturerName = "Boeing";
            typeName = "747-XXX";

            maxSpeed = 270;
            cruisingSpeed = 230;
            takeofSpeed = 90;
            taxiSpeed = 20;

            maxCapacityKg = 10000;  // Geen idee :P
        }
    }
}
