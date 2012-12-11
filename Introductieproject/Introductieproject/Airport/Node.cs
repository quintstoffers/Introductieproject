using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introductieproject.Airport
{
    class Node
    {
        public int[] location = new int[2];
        public IList<Way> connections;

        public Node(int x, int y)
        {
            this.location[0] = x;
            this.location[1] = y;
        }

        public void addConnection(Way newWay)
        {
            this.connections.Add(newWay);
        }

        public bool checkConnection(Way checkWay)
        {
            foreach (Way w in this.connections)
                if (w == checkWay) return true;
            return false;
        }
    }
}
