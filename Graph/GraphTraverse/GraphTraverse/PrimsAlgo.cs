using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraverse
{
    class PrimsAlgo
    {
        private List<List<int>> edges;
        int nodeCount;

        public PrimsAlgo(List<List<int>> edges)
        {
            this.edges = edges;
            int nodeCount = edges.Count;
        }

        public int MinSpanningTreeWeight()
        {
            List<int> previous = new List<int>();
            List<int> parent = new List<int>();
            List<bool> mst = new List<bool>();
            previous.AddRange(Enumerable.Repeat<int>(Int16.MaxValue, this.nodeCount));
            mst.AddRange(Enumerable.Repeat<bool>(false, this.nodeCount));

            // pick random node.
            previous[0] = 0;
            parent[0] = -1;
            mst[0] = true;
            for(int count = 0; count < this.nodeCount-1; count++)
            {

            }

            return 1;
        }
    }
}
