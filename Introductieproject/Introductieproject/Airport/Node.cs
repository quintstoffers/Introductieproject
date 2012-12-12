using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Node
    {
        public int[] location = new int[2];
        public IList<Way> connections = new List<Way>();

        public Node(int x, int y)
        {
            this.location[0] = x;
            this.location[1] = y;
        }

        public bool checkConnection(Way checkWay)
        {
            foreach (Way w in this.connections)
                if (w == checkWay) return true;
            return false;
        }

        public Node getConnectedNode(Way currentWay)
        {
            foreach (Node node in currentWay.nodeConnections)
            {
                if (node != this)
                {
                    return node;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "NODE: location (" + location[0] + "," + location[1] + ")";
        }
    }
}
