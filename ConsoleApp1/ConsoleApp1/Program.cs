using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() { 5,6 };
            List<int> list2 = new List<int>() { 1, 2, 3 };
            List<int> result = new List<int>();
            List<List<int>> re = list1.Zip(list2, (a, b) => new List<int>() { a, b }).ToList();
            
        }
    }
}
