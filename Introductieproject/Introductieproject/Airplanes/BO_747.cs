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
            manufacturerName = "Boeing";
            typeName = "747-XXX";
            maxSpeed = 270;
            cruisingSpeed = 230;
            takeofSpeed = 90;
            taxiSpeed = 20;
        }
    }
}
