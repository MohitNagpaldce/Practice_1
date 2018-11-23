using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAtGeeksPractice
{
    /// <summary>
    /// Dyanmic progragramming based solution for travelling salesman problem.
    /// </summary>
    public class TravellingSalesManProblem
    {
        public void SolveTravellingSalesManProblem()
        {
            List<HashSet<int>> allSets = GetAllPossibleSets(1, 4);
            Console.WriteLine($"Count {allSets.Count}");
        }

        List<HashSet<int>> GetAllPossibleSets(int start, int end)
        {
            List<HashSet<int>> FinalList = new List<HashSet<int>>();
            // Empty set is first option
            FinalList.Add(new HashSet<int>());
            PossibleSetUtil(new HashSet<int>(), start, end, FinalList);
            return FinalList;
        }

        void PossibleSetUtil(HashSet<int> currentSet, int start, int end, List<HashSet<int>> FinalList)
        {
            if (currentSet.Count == end-start+1)
            {
                return;
            }

            for(int i = start; i <= end; i++)
            {
                if(!currentSet.Contains(i))
                {
                    currentSet.Add(i);
                    FinalList.Add(currentSet);
                    PossibleSetUtil(currentSet, start, end, FinalList);
                }
            }
        }
    }
}
