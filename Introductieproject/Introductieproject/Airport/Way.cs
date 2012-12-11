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

        public List<Way> connectedWays = new List<Way>(); //Algemene lijst met alle connecties
        
        //Bepalen in welke richting moet rijden
        public int direction;

        public Way()
        {
        }

        public double length
        {
            get
            {
                int deltaX = Math.Max(this.endLocation[0], this.startLocation[0]) - Math.Min(this.endLocation[0], this.startLocation[0]);
                int deltaY = Math.Max(this.endLocation[1], this.startLocation[1]) - Math.Min(this.endLocation[1], this.startLocation[1]);
                return Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
            }
        }
    }
}
