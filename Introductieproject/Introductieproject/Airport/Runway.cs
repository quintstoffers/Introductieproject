using Introductieproject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Runway:Way
    {
        public Runway(Node node1, Node node2, int dir) : base(node1, node2, dir)
        {
        }
    }
}
