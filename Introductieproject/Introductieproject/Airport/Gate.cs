using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;

namespace Introductieproject.Airport
{
    public class Gate:Way
    {
        public Gate(Node node1, Node node2, int dir, string name) : base(node1, node2, dir, name)
        {
        }
    }
}
