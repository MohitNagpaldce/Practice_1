using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBitPractice
{
    public class SumoLogicContest
    {
        int maxNumber = 1000000;
        int resultModulo = 1000000007;
        long resultMod = 1000000007;

        List<long> fact = SumoLogicContest.PreCalculateFacN(100000);

        /// <summary>
        ///  Solve prime subsequence
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int solve(List<int> A)
        {
            int result = 0;
            if (A != null && A.Count > 0)
            {
                int max = A.Max();
                List<bool> primes = this.AllPrimeLessThan(max);
                int primeCount = 0;
                foreach(int i in A)
                {
                    if(primes[i])
                    {
                        if(result == 0)
                        {
                            result = 1;
                        }
                        else
                        {
                            result = 2 * result;
                            result = result % resultModulo;
                        }

                        primeCount++;
                    }
                }

                if (primeCount > 1)
                {
                    result--;
                }
                
            }

            return result;
        }

        /// <summary>
        /// Solve
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int solve(string A)
        {
            long result = 1;
            if(!string.IsNullOrEmpty(A))
            {
                char firstChar = A[0];
                int length = A.Length;
                result = fact[length];

                for(int i = 1; i < length; i++)
                {
                    if(A[i] == firstChar)
                    {
                        int interLength = 1;
                        int j = 1;
                        int k = i + 1;
                        while(j < length && k < length && A[j] == A[k])
                        {
                            j++;
                            k++;
                            interLength++;
                        }

                        result = result % resultMod * fact[interLength] % resultMod;
                    }
                }
            }

            return (int)result;
        }

        /// <summary>
        /// Min steps required.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int minSteps(string A, string B)
        {
            int result = -1;
            if(A == B)
            {
                return 0;
            }
            if(A.Length >= B.Length)
            {
                return -1;
            }

            Dictionary<string, List<Tuple<string, int>>> costMap = new Dictionary<string, List<Tuple<string, int>>>();
            result = minStepUtil(A, B, costMap);

            return result;
        }

        private int minStepUtil(string first, string second, Dictionary<string, List<Tuple<string, int>>> costMap)
        {
            if (first == second)
            {
                return 0;
            }
            if (first.Length >= second.Length)
            {
                return -1;
            }

            if (costMap.ContainsKey(first))
            {
                Tuple<string, int> t = costMap[first].Where(m => m.Item1 == second).FirstOrDefault();
                if (t != null)
                {
                    return t.Item2;
                }
            }

            int val = -1;
            // two options
            // append 1
            int step1 = minStepUtil(first + '1', second, costMap);
            int step2 = minStepUtil(first.Reverse().ToString() + '0', second, costMap);
            if(step1 == -1 && step2 == -1)
            {
                val = - 1;
            }
            else if (step1 != -1 && step2 != -1)
            {
                val = 1 + Math.Min(step1, step2);
            }
            else if(step1 == -1)
            {
                val = 1 + step2;
            }
            else
            {
                val = 1 + step1;
            }
            if(!costMap.ContainsKey(first))
            {
                costMap.Add(first, new List<Tuple<string, int>>());
            }

            costMap[first].Add(Tuple.Create<string, int>(second, val));
            return val;
        }

        static List<long> PreCalculateFacN(int n)
        {
            long resultMod = 1000000007;
            List<long> fact = new List<long>();
            fact.Add(1);
            long result = 1;
            for(int i = 1; i <=n; i++)
            {
                result = result * i;
                result = result % resultMod;
                fact.Add(result);
            }

            return fact;
        }

        List<bool> AllPrimeLessThan(int n)
        {
            List<bool> prime = new System.Collections.Generic.List<bool>();
            prime.AddRange(Enumerable.Repeat<bool>(true, n + 1).ToList());
            prime[1] = false;

            for (int p = 2; p * p <= n; p++)
            {
                // If prime[p] is not changed, then it is a prime 
                if (prime[p])
                {
                    // Update all multiples of p 
                    for (int i = p * 2; i <= n; i += p)
                        prime[i] = false;
                }
            }

            return prime;
        }
    }
}
