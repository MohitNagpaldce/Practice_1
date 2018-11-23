using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class MathLibs
    {

        public int uniquePaths(int A, int B)
        {
            List<int> oneRow = new List<int>();
            oneRow.AddRange(Enumerable.Repeat<int>(0, B));
            List<List<int>> pathCounts = new List<List<int>>();
            pathCounts.AddRange(Enumerable.Repeat<List<int>>(oneRow, A));

            //// first row and first column just fill with 1
            for(int i = 0; i < A; i++)
            {
                pathCounts[i][0] = 1;
            }

            //// first row and first column just fill with 1
            for (int i = 0; i < B; i++)
            {
                pathCounts[0][i] = 1;
            }

            for(int i = 1; i < A; i++)
                for(int j =1; j < B; j++)
                {
                    int topCount = i - 1 >= 0 ? pathCounts[i - 1][j] : 0;
                    int leftCount = j - 1 >= 0 ? pathCounts[i][j - 1] : 0;
                    pathCounts[i][j] = topCount + leftCount;
                }


            return pathCounts[A-1][B-1];
        }

        public int RankOfStringWithRepeat(string input)
        {
            long rank = 1;
            long length = input.Length;
            long mul = fact(length);
            long mod = 1000003;

            for (int i = 0; i < input.Length; i++)
            {
                mul = fact(length - i - 1);
                List<int> dups = this.PreCalculateDuplicateCounts(input, i);
                int seq = this.sequenceNumber(input, i);
                long invesre = 1;
                foreach(int dup in dups)
                {
                    invesre *= this.CalculateInverseModulo(fact(dup), mod);
                    invesre %= mod;
                }

                rank += (mul * seq  * invesre) % mod;
                rank = rank % mod;
            }

            return (int)rank;
        }
        public int RankOfString(string input)
        {
            long rank = 1;
            long length = input.Length;
            long mul = fact(length);
            long mod = 1000003;

            for (int i = 0; i < input.Length; i++)
            {
                mul = fact(length - i - 1);
                int seq = this.sequenceNumber(input, i);
                rank += mul * (seq % mod);
                rank = rank % mod;
            }

            return (int)rank;
        }
        public long fact(long n)
        {
            //long mod = 1000003;
            long mod = 1000003;
            if (n <= 1)
                return 1;
            else
                return n * fact(n - 1) % mod ;
        }
        public int SumOfHammingDistance(List<int> input)
        {
            long mod = 1000000007;
            long result = 0;
            long totalCount = input.Count;
            for (int i = 1; i <= 32; i++)
            {
                long curCount = 0;
                foreach (int a in input)
                {
                    int ithBit = 1 << i - 1;
                    if ((a & ithBit) == ithBit)
                    {
                        curCount++;
                    }
                }

                result += curCount % mod * ((totalCount - curCount) % mod) * 2;
                result = result % mod;
            }

            return (int)result;
        }
        public int LargetCoprime(int a, int b)
        {
            int gcd = GCD(a, b);

            while (gcd != 1)
            {
                a = a / gcd;
                gcd = GCD(a, b);
            }

            return a;
        }
        private int GCD(int a, int b)
        {
            if(b == 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }
        private int sequenceNumber(string s, int low)
        {
            int sequenceNum = 0;
            for (int i = low + 1; i < s.Length; i++)
            {
                if (s[low] > s[i])
                {
                    sequenceNum++;
                }
            }

            return sequenceNum;
        }

        /// <summary>
        /// The divison factor
        /// </summary>
        /// <param name="dupCounts"></param>
        /// <returns></returns>
        private long DivisonFactor(List<int> dupCounts)
        {
            //long mod = 1000003;
            long mod = 1;
            long result = 1;
            foreach(int c in dupCounts)
            {
                result *= fact(c);
                // result %= mod;
            }

            return result;
        }

        private long CalculateInverseModulo(long a, long mod)
        {
            // inverse modulo is a^mod-2 % mod value.
            long ans = 1;
            long bas = a;
            long power = mod - 2;
            while(power > 0)
            {
                if(power == 1)
                {
                    ans = (ans * bas) % mod;
                    power--;
                }
                else if(power % 2 == 0)
                {
                    bas = (bas * bas) % mod;
                    power = power / 2;
                }
                else
                {
                    ans = (ans * bas) % mod;
                    power--;
                }
            }

            return ans;
        }

        /// <summary>
        /// PreCalculateDuplicateCounts
        /// </summary>
        /// <param name="s">The string input.</param>
        /// <param name="low">The starting number in string.</param>
        /// <returns></returns>
        private List<int> PreCalculateDuplicateCounts(string s, int low)
        {
            //// create Ascii Char array
            List<int> allChar = new List<int>();
            List<int> duplicates = new List<int>();
            allChar.AddRange(Enumerable.Repeat<int>(0, 257).ToList());
            for(int i = low; i < s.Length; i++)
            {
                allChar[s[i]]++;
            }

            for(int i = 0; i < 257; i++)
            {
                if(allChar[i] > 1)
                {
                    duplicates.Add(allChar[i]);
                }
            }

            return duplicates;
        }

    }
}
