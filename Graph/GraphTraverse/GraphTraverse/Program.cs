using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraverse
{
    class Program
    {
        static void Main(string[] args)
        {
            IsCycleTest();
        }

        static void TravelsalTests()
        {
            SimpleGraph graph = new SimpleGraph(4);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            Console.WriteLine("DOBFS:");
            List<int> result = graph.DoBFS();
            result.ForEach(item => Console.WriteLine(item));

            Console.WriteLine("DODFS:");
            result = graph.DoDFS();
            result.ForEach(item => Console.WriteLine(item));
            Console.ReadLine();
        }

        static void MotherVertexTest()
        {
            SimpleGraph g = new SimpleGraph(7); 
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 3);
            g.AddEdge(4, 1);
            g.AddEdge(6, 4);
            g.AddEdge(5, 6);
            g.AddEdge(5, 2);
            g.AddEdge(6, 0);

            int result = g.GetMotherVertex();
            Console.WriteLine(result);
        }

        static void IsCycleTest()
        {
            SimpleGraph g = new SimpleGraph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            if (g.IsCycleInGraph())
            {
                Console.WriteLine("found cycle");
            }
            else
            {
                Console.WriteLine("no found cycle");
            }

            Console.ReadLine();
        }
    }
}
