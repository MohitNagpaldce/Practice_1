using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumoLogicBEContest_11_23
{
    public class SumoLogicBEContest
    {
        /// <summary>
        ///  Special substring problem. Find all substrings which are prefix and
        ///  return prodct of sum of that strings.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>

        long resultMod = 1000000007;

        public int solve(string A)
        {
            // first set of substring in string itself.

            long finalResult = 0;
            long fistChar = A[0] - 'a' + 1;
            
            long sum = fistChar;
            finalResult += sum;
            for (int i = 1; i < A.Length; i++)
            {
                sum = (sum + (A[i] - 'a' + 1)) % resultMod;
                finalResult *= sum;
                finalResult %= resultMod;
            }

            for (int i = 1; i < A.Length; i++)
            {
                if(A[i] == A[0]) // potential prefix match here
                {
                    long sum1 = A[i] - 'a' + 1;
                    finalResult *= sum1;
                    finalResult %= resultMod;
                    int cur = 1;
                    for(int j = i+1; j < A.Length; j++)
                    {
                        if(A[j] != A[cur])
                        {
                            break;
                        }
                        else
                        {
                            sum1 = (sum1 + (A[j] - 'a' + 1)) % resultMod;
                            finalResult *= sum1;
                            finalResult %= resultMod;
                            cur++;
                        }
                    }
                }
            }


            return (int)finalResult;

        }


        public int solve(int A, int B, int C)
        {
            int first, second, third;

            if(A >= B)
            {
                if(A >=C)
                {
                    first = A;
                    if(B>=C)
                    {
                        second = B;
                        third = C;
                    }
                    else
                    {
                        second = C;
                        third = B;
                    }
                }
                else
                {
                    first = C;
                    if(A>=B)
                    {
                        second = A;
                        third = B;
                    }
                    else
                    {
                        second = B;
                        third = A;
                    }
                }
            }
            else
            {
                if(B >=C)
                {
                    first = B;
                    if(A>=C)
                    {
                        second = A;
                        third = C;
                    }
                    else
                    {
                        second = C;
                        third = A;
                    }
                }
                else
                {
                    first = C;
                    if(B>=A)
                    {
                        second = B;
                        third = A;
                    }
                    else
                    {
                        second = A;
                        third = B;
                    }
                }
            }

            long result = (third % resultMod) * ((second - 1) % resultMod);
            result %= resultMod;
            resultMod = (result * ((first - 2) % resultMod)) % resultMod;

            return 1;
        }
    }
}
