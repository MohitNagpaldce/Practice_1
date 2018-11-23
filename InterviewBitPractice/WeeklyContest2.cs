using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBitPractice
{
    public class WeeklyContest2
    {
        double resultMode = Math.Pow(10, 9) + 7;

        #region Question 1
        //// problem 1 
        //You are given an array A having n integers.You have to perform some very hard queries on A.There are 2 types of queries
        //1 id X, change A[id] with X.
        //2 L R, you have to find the minimum number of steps required to change all elements in [L, R] such that every element in [L, R] will have the odd number of divisors.In one step you can choose any element from A and can add or subtract 1 from it.
        //Note that in the second type of query, the array does not change.

        public int Solve(List<int> A, List<List<int>> B)
        {
            int result = 0;
            if(A == null || A.Count == 0)
            {
                return result;
            }
            if (B == null || B.Count == 0)
            {
                return result;
            }

            foreach(List<int> query in B)
            {
                if (query != null && query.Count == 3)
                {
                    result += this.NumberOfStepsInOneQuery(A, query);
                }
            }

            return result;
        }

        int NumberOfStepsInOneQuery(List<int> input, List<int> query)
        {
            int answer = 0;
            if(query[0] == 1)
            {
                //// it is a update query
                input[query[1] - 1] = query[2]; 
            }
            else if(query[0] == 2)
            {
                //// it is L to R query to count the steps.
                int start = query[1]-1;
                int end = query[2] - 1;
                for(int index = start; index <= end; index++)
                {
                    answer += (int)(DifferenceToNearestNumberWithOddDivisors(input[index]) % resultMode);
                }
            }

            return answer;
        }
        double DifferenceToNearestNumberWithOddDivisors(int number)
        {
            //// perfect square numbers have odd divisors.
            double num = Math.Sqrt(number);
            if (num == Math.Floor(num))
            {
                return 0;
            }

            number = (int)(number % resultMode);
            num = Math.Floor(num);
            num = num % resultMode;

            double firstSquare = (num * num) % resultMode;
            double secondSquare = (firstSquare + 1 + 2 * num) % resultMode;
            return Math.Abs(firstSquare - number) > Math.Abs(secondSquare - number) ?
                Math.Abs(secondSquare - number) : Math.Abs(firstSquare - number);
        }

        #endregion

        #region Question 2
        //Given a tree T containing N nodes numbered[1, 2, ..., N] rooted at node 1. 
        //Each node has a value associated with it.You need to choose some of the nodes from 
        //the tree such that the sum of values of the chosen nodes is maximum possible. Moreover, 
        //if you have chosen a node V you cannot choose any of its children or grand children.
        //In simple words, you have to choose a subset of nodes such that no two nodes in the chosen
        //set have a parent-child relation or grandfather-grandchild relation between them.

        int modValue = 1000000007;
        public int Solve(List<int> A, List<int> B)
        {
            int result = 0;
            // B contains the values.
            int totalCount = B.Count;

            //// this map contains source and all child node maps.
            Dictionary<int, List<int>> nodeToChildMap = new Dictionary<int, List<int>>();
            for(int i = 0; i <= B.Count; i++)
            {
                nodeToChildMap.Add(i, new List<int>());
            }

            // now iterate through the A and set the childrens
            for(int i = 0; i < A.Count; i++)
            {
                int child = i + 1;
                int parent = A[i];
                if(!nodeToChildMap[parent].Contains(child))
                {
                    nodeToChildMap[parent].Add(child);
                }
            }

            // 0th node has 0th weight so set it to 0.
            B.Insert(0, 0);

            Dictionary<int, int> sumMap = new Dictionary<int, int>();
            MaxSumUtil(nodeToChildMap, 0, sumMap, B);
            result = sumMap.Values.Max();
            return result;
        }


        private int MaxSumUtil(Dictionary<int, List<int>> nodeToChildMap, int source, Dictionary<int, int> sumMap, List<int> weights)
        {
            if(sumMap.ContainsKey(source))
            {
                return sumMap[source];
            }

            //// else first option is self + all 3rd gen childs
            int firstOption = weights[source];
            foreach(int child in this.GetThirdGeneration(nodeToChildMap, source))
            {
                firstOption += MaxSumUtil(nodeToChildMap, child, sumMap, weights) % modValue;
            }

            int secondOption = 0;
            foreach (int child in this.GetFirstGeneration(nodeToChildMap, source))
            {
                secondOption += MaxSumUtil(nodeToChildMap, child, sumMap, weights) % modValue;
            }

            sumMap[source] = Math.Max(firstOption, secondOption);
            return sumMap[source];
        }

        private List<int> GetFirstGeneration(Dictionary<int, List<int>> nodeToChildMap, int source)
        {
            return nodeToChildMap[source];
        }
        private List<int> GetThirdGeneration(Dictionary<int, List<int>> nodeToChildMap, int source)
        {
            List<int> result = new List<int>();

            /// first generation 
            List<int> firstGen = nodeToChildMap[source];
            List<int> secondGen = new List<int>();
            List<int> thirdGen = new List<int>();
            firstGen.ForEach(fgen => secondGen.AddRange(nodeToChildMap[fgen]));
            secondGen.ForEach(sgen => thirdGen.AddRange(nodeToChildMap[sgen]));
            result = thirdGen.Distinct().ToList();
            return result;
        }

        #endregion

        #region Question 3
        //You are given an array A consisting of strings made up of the letters 'a' and 'b' only.
        //Each string goes through a number of operations, where:

        //At time 1, you circularly rotate each string by 1 letter.
        //At time 2, you circularly rotate the new rotated strings by 2 letters.
        //At time 3, you circularly rotate the new rotated strings by 3 letters.
        //At time i, you circularly rotate the new rotated strings by i % length(string) letters.
        //Eg: String is abaa
        //At time 1, string is baaa, as 1 letter is circularly rotated to the back
        //At time 2, string is aaba, as 2 letters of the string baaa is circularly rotated to the back
        //At time 3, string is aaab, as 3 letters of the string aaba is circularly rotated to the back
        //At time 4, string is again aaab, as 4 letters of the string aaab is circularly rotated to the back
        //At time 5, string is aaba, as 1 letters of the string aaab is circularly rotated to the back
        //After some units of time, a string becomes equal to it's original self.
        //Once a string becomes equal to itself, it's letters start to rotate from the first letter again (process resets). So, if a string takes t time to get back to the original, at time t+1 one letter will be rotated and the string will be it's original self at 2t time.
        //You have to find the minimum time, where maximum number of strings are equal to their original self.
        //As this time can be very large, give the answer modulo 109+7.
        //Note: Your solution will run on multiple test cases so do clear global variables after using them.

        public int solve(List<string> A)
        {
            Dictionary<long, long> cacheOfSum = new Dictionary<long, long>();
            long sum = 0;
            for(int i = 1; i < Math.Pow(10, 5); i++)
            {
                sum += i;
                cacheOfSum.Add(sum, i);
            }

            int result = 0;
            List<long> moves = new List<long>();
            if(A != null && A.Count > 0)
            {
                A.ForEach(s => moves.Add(SolveOneString(s, cacheOfSum)));
            }

            result = this.LCMOfNumbers(moves);
            return result;
        }

        public long SolveOneString(string s, Dictionary<long, long> cacheOfSum)
        {
            long result = 0;
            bool noFound = true;
            int length = this.MoveRequiredByOneString(s);
            long factor = 1;
            while(noFound)
            {
                if(cacheOfSum.ContainsKey(factor*length))
                {
                    result = cacheOfSum[factor * length];
                    noFound = false;
                }

                factor++;

            }

            return result;
        }

        public int MoveRequiredByOneString(string s)
        {
            int result = s.Length;

            return result;
        }
        public int LCMOfNumbers(List<long> values)
        {
            long result = values[0];
            for(int i = 1; i < values.Count; i++)
            {
                result = (long)((values[i] * result) % resultMode) / GCD(values[i], result);
            }

            return (int)result;
        }
        

        private long GCD(long a, long b)
        {
            if(b == 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }
        #endregion

    }
}
