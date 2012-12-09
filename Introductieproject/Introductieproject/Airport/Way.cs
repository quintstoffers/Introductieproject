using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Way
    {
        public int[] startLocation = new int[2];
        public int[] endLocation = new int[2];
        
        //Bepalen in welke richting moet rijden
        public int direction;

        public Way()
        {
        }
    }
}
