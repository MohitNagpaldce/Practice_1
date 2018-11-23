using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraverse
{
    public class SimpleGraph
    {
        public int V; // vertex count
        List<LinkedList<int>> Adj;

        public SimpleGraph(int v)
        {
            this.V = v;
            this.Adj = new List<LinkedList<int>>();
            for(int i = 0; i < v; i++)
            {
                this.Adj.Add(new LinkedList<int>());
            }
        }

        public void AddEdge(int s, int e)
        {
            this.Adj[s].AddFirst(e);
        }

        #region traversals
        public List<int> DoBFS()
        {
            List<bool> isVisted = new List<bool>();
            isVisted.AddRange(Enumerable.Repeat(false, this.V));
            List<int> result = new List<int>();
            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < this.V; i++)
            {
                if (!isVisted[i])
                {
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        int element = queue.Dequeue();
                        result.Add(element);
                        isVisted[element] = true;
                        foreach(int neighbour in this.Adj[element])
                        {
                            if (!isVisted[neighbour])
                            {
                                queue.Enqueue(neighbour);
                            }
                        }
                    }
                    
                }
            }

            return result;
        }

        public List<int> DoDFS()
        {
            List<bool> isVisted = new List<bool>();
            isVisted.AddRange(Enumerable.Repeat(false, this.V));
            List<int> result = new List<int>();
            for (int i = 0; i < this.V; i++)
            {
                if (!isVisted[i])
                {
                    result.AddRange(DFSUtil(isVisted, i));
                }
            }

            return result;
        }

        #endregion

        #region DFS applications
        public List<int> TopoLogicalSort()
        {
            List<bool> isVisted = new List<bool>();
            isVisted.AddRange(Enumerable.Repeat(false, this.V));
            List<int> result = new List<int>();
            for (int i = 0; i < this.V; i++)
            {
                if (!isVisted[i])
                {
                    result.AddRange(TopoLogicalSortUtil(isVisted, i));
                }
            }

            result.Reverse();
            return result;
        }

        public int GetMotherVertex()
        {
            List<bool> isVisted = new List<bool>();
            isVisted.AddRange(Enumerable.Repeat(false, this.V));
            List<int> result = new List<int>();
            int candidateMotherVertex = -1;
            for (int i = 0; i < this.V; i++)
            {
                if (!isVisted[i])
                {
                    candidateMotherVertex = i;
                    result.AddRange(DFSUtil(isVisted, i));
                }
            }

            isVisted = new List<bool>();
            isVisted.AddRange(Enumerable.Repeat(false, this.V));
            DFSUtil(isVisted, candidateMotherVertex);
            if (!isVisted.Any( visit => visit))
            {
                candidateMotherVertex = -1;
            }

            return candidateMotherVertex;
        }

        /// <summary>
        /// Returns true if cycle is detected in a graph.
        /// </summary>
        /// <returns>True, if cycle is detected in a graph.</returns>
        public bool IsCycleInGraph()
        {
            bool isCycle = false;
            List<bool> isVisted = new List<bool>();
            isVisted.AddRange(Enumerable.Repeat(false, this.V));
            for (int i = 0; i < this.V; i++)
            {
                if (!isVisted[i])
                {
                    if (IsCycleUtil(isVisted, i, new List<int>()))
                        {

                        return true;
                    }
                }
            }

            return isCycle;
        }
        #endregion

        #region BFS applications
        public bool isBipartite()
        {
            bool resultB = true;
            List<bool> isVisted = new List<bool>();
            isVisted.AddRange(Enumerable.Repeat(false, this.V));

            List<int> color = new List<int>();
            color.AddRange(Enumerable.Repeat(-1, this.V));

            Queue<int> queue = new Queue<int>();
            color[0] = 1; // 1 = red color , 0 = green color.
            for (int i = 0; i < this.V; i++)
            {
                if (!isVisted[i])
                {
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        int element = queue.Dequeue();
                        isVisted[element] = true;
                        int parentColor = color[element];

                        foreach (int neighbour in this.Adj[element])
                        {
                            if (!isVisted[neighbour])
                            {
                                queue.Enqueue(neighbour);
                            }

                            if (color[neighbour] != -1)
                            {
                                color[neighbour] = parentColor == 1 ? 0 : 1;
                            }
                            else if (color[neighbour] == parentColor)
                            {
                                return false;
                            }
                        }
                    }

                }
            }

            return resultB;
        }


        /// <summary>
        /// Clones the graphs and returns new graph.
        /// </summary>
        /// <param name="s">The starting vertex</param>
        /// <returns></returns>
        public SimpleGraph Clone(int s)
        {
            SimpleGraph clone = new SimpleGraph(this.V);
            return clone;
        }

        /// <summary>
        /// Returns the maximum flow for graph. Not tested fully.
        /// </summary>
        /// <param name="graph">The graph input.</param>
        /// <param name="s">The source vertex.</param>
        /// <param name="t">The target vertex.</param>
        /// <returns>Returns the maximum flow for graph.</returns>
        int MaxFlowForFulkInSon(List<List<int>> graph, int s, int t)
        {
            int answer = 0;
            do
            {
                Tuple<bool, List<int>, int> res = this.BFS(
                    graph, s, t);
                if (res.Item1)
                {
                    answer += res.Item3;
                    this.CreateResidualGraph(graph, res.Item3, res.Item2);
                }
                else
                {
                    break;
                }

            } while (true);

            return answer;
        }

        #endregion

        #region Spanning tree
        List<int> GetMinSpanningTree(List<List<int>> graph)
        {
            List<int> result = new List<int>();
            List<int> mSet = new List<int>();

            // length of key for ith node.
            List<int> keys = new List<int>();



            // list of indices those are already part of minimum spanning tree.
            return result;
        }

        #endregion

        #region private methods
        private IEnumerable<int> TopoLogicalSortUtil(List<bool> isVisted, int i)
        {
            List<int> result = new List<int>();
            isVisted[i] = true;
            foreach (int neighbour in this.Adj[i])
            {
                if (!isVisted[neighbour])
                {
                    result.AddRange(DFSUtil(isVisted, neighbour));
                }
            }

            result.Add(i);
            return result;
        }

        private IEnumerable<int> DFSUtil(List<bool> isVisted, int i)
        {
            List<int> result = new List<int>();
            result.Add(i);
            isVisted[i] = true;
            foreach (int neighbour in this.Adj[i])
            {
                if (!isVisted[neighbour])
                {
                    result.AddRange(DFSUtil(isVisted, neighbour));
                }
            }

            return result;
        }


        private bool IsCycleUtil(List<bool> isVisted, int i, List<int> soFarSeen)
        {
            bool isCycle = false;
            isVisted[i] = true;
            if (soFarSeen.Contains(i))
            {
                return true;
            }

            List<int> soFarCopy = new List<int>();
            soFarCopy.AddRange(soFarSeen);
            soFarCopy.Add(i);

            foreach (int neighbour in this.Adj[i])
            {
                if (soFarSeen.Contains(neighbour))
                {
                    return true;
                }

                if (!isVisted[neighbour])
                {
                    if (IsCycleUtil(isVisted, neighbour, soFarCopy))
                    {
                        return true;
                    }
                }
            }

            return isCycle;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        Tuple<bool, List<int>, int> BFS(List<List<int>> graph, int s, int t)
        {
            List<bool> isVisited = Enumerable.Repeat<bool>(false, graph.Count).ToList();
            List<int> parents = Enumerable.Repeat<int>(-1, graph.Count).ToList();
            bool isTargetFound = false;
            int minFlow = Int32.MaxValue;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            while (queue.Count > 0)
            {
                int element = queue.Dequeue();
                isVisited[element] = true;
                for(int j = 0; j < graph.Count && j != element; j++)
                {
                    if(!isVisited[j] && graph[element][j] > 0)
                    {
                        queue.Enqueue(element);
                        minFlow = Math.Min(minFlow, graph[element][j]);
                        parents[j] = element;
                        if (j == t)
                        {
                            isTargetFound = true;
                            break;
                        }
                    }
                }

                if(isTargetFound)
                {
                    break;
                }
            }


            return Tuple.Create<bool, List<int>, int>(isTargetFound, parents, minFlow);
        }

        /// <summary>
        /// Creates the residual graph.
        /// </summary>
        /// <param name="graph">The given graph.</param>
        /// <param name="flow">The min flow selected.</param>
        /// <param name="parents">The parents array.</param>
        private void CreateResidualGraph(List<List<int>> graph, int flow, List<int> parents)
        {
            // no parent defined for 0;
            for(int i = 1; i < parents.Count; i++)
            {
                graph[i][parents[i]] -= flow;
                graph[parents[i]][i] += flow;
            }
        }
        #endregion
    }
}
