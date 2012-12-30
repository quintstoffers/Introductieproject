using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introductieproject.Objects;

namespace Introductieproject.Airport
{
    public class Gateway:Way
    {
        public Gateway(Node node1, Node node2, int dir) : base(node1, node2, dir)
        {
        }
    }
}
