using Introductieproject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    public class Taxiway:Way
    {
        public Taxiway(Node node1, Node node2, int dir, string name) : base(node1, node2, dir, name)
        {
        }
    }
}

