using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTrackingLib
{
    public class BackTrackingLibs
    {
        public List<string> letterCombinations(string A)
        {
            List<string> numMapping = new List<string>()
            {
                "", "", "abc", "def", "ghi", "jkl",
                               "mno", "pqrs", "tuv", "wxyz"
            };

            List<string> result = new List<string>();
            List<string> possibleSelections = new List<string>();

            for(int i = 0; i < A.Length; i++)
            {
                possibleSelections.Add(numMapping[A[i] - '0']);
            }

            LetterCombinationUtil(0, "", possibleSelections, result);

            result.ForEach(r => Console.WriteLine(r));
            return result;
        }

        void LetterCombinationUtil(int index, string currentString, List<string> possibleSelections, List<string> result)
        {
            if(index == possibleSelections.Count)
            {
                result.Add(currentString);
                return;
            }
            foreach(char c in possibleSelections[index])
            {
                string newString = currentString + c;
                LetterCombinationUtil(index + 1, newString, possibleSelections, result);
            }
        }
        public int PalindromicPartioning(string s)
        {
            int result = 0;

            /// first fill palindrom matrix
            int length = s.Length;
            List<List<bool>> palindrom = new List<List<bool>>();
            List<List<int>> minCut = new List<List<int>>();
            for (int i = 0; i < length; i++)
            {
                List<bool> n = new List<bool>();
                List<int> m = new List<int>();
                palindrom.Add(n);
                minCut.Add(m);
                for (int j = 0; j < length; j++)
                {
                    palindrom[i].Add(false);
                    minCut[i].Add(int.MaxValue);
                }
            }

             for (int j = 0; j < length; j++)
            {
                palindrom[j][j] = true;
                minCut[j][j] = 0;
            }

            for (int l = 2; l <= length; l++)
            {
                for (int i = 0; i < length - l + 1; i++)
                {
                    int j = i + l - 1;
                    if (l == 2)
                    {
                        palindrom[i][j] = (s[i] == s[j]);
                    }
                    else
                    {
                        palindrom[i][j] = (s[i] == s[j] && palindrom[i + 1][j - 1]);
                    }
                }
            }

            for (int l = 2; l <= length; l++)
            {
                for (int i = 0; i < length - l + 1; i++)
                {
                    int j = i + l - 1;
                    if (palindrom[i][j])
                    {
                        minCut[i][j] = 0;
                    }
                    else if(l == 2)
                    {
                        minCut[i][j] = 1;
                    }
                    else
                    {
                        minCut[i][j] = Int32.MaxValue;
                        int k = i;
                        for(;k < j; k++)
                        {
                            minCut[i][j] = Math.Min(minCut[i][j], 1 + minCut[i][k] + minCut[k+1][j]);
                        }
                    }
                }
            }


            result = minCut[0][length - 1];
                    return result;
        }

        public List<List<int>> subsets(List<int> A)
        {
            A.Sort();
            List<List<int>> result = new List<List<int>>();
            int length = A.Count;
            int totalCount = (int)Math.Pow(2, length);
            for (int i = 0; i < totalCount; i++)
            {
                int curNum = i;
                List<int> curSubset = new List<int>();
                for (int j = 0; j < length; j++)
                {
                    if ((curNum & (1 << j)) > 0)
                    {
                        curSubset.Add(A[j]);
                    }
                }

                result.Add(curSubset);
            }

            result.ForEach(res => Console.WriteLine($"({string.Join(",", res.Select(r => r))})"));
            return result;
        }

        public List<List<int>> subsets1(List<int> A)
        {
            A.Sort();
            List<List<int>> result = new List<List<int>>();
            result.Add(new List<int>());
            SubsetUtil1(A, new List<int>(), 0, result);
            result.ForEach(res => Console.WriteLine($"({string.Join(",", res.Select(r => r))})"));
            return result;
        }

        public List<List<int>> combinationSum(List<int> A, int B)
        {

            A.Sort();
            A = A.Distinct().ToList();
            List<List<int>> result = new List<List<int>>();
            CombinationSumUtil(A, new List<int>(), 0, result, B);
            result.ForEach(res => Console.WriteLine($"({string.Join(",", res.Select(r => r))})"));
            return result;
        }

        private void CombinationSumUtil(List<int> A, List<int> currentSet, int index, List<List<int>> result, int sum)
        {
            if (sum == 0)
            {
                // uniqueness check 
                result.Add(currentSet);
                return;
            }
            for (int i = index; i < A.Count; i++)
            {
                List<int> newCopy = new List<int>();
                newCopy.AddRange(currentSet);
                if (sum >= A[i])
                {
                    newCopy.Add(A[i]);
                    CombinationSumUtil(A, newCopy, i, result, sum - A[i]);
                }
            }
        }

        public List<List<int>> combinationSum2(List<int> A, int B)
        {

            A.Sort();
            A = A.Distinct().ToList();
            List<List<int>> result = new List<List<int>>();
            CombinationSumUtil2(A, new List<int>(), 0, result, B);
            result.ForEach(res => Console.WriteLine($"({string.Join(",", res.Select(r => r))})"));
            return result;
        }

        private void CombinationSumUtil2(List<int> A, List<int> currentSet, int index, List<List<int>> result, int sum)
        {
            if (sum == 0)
            {
                result.Add(currentSet);
                return;
            }
            for (int i = index; i < A.Count; i++)
            {
                List<int> newCopy = new List<int>();
                newCopy.AddRange(currentSet);
                if (sum >= A[i])
                {
                    newCopy.Add(A[i]);
                    CombinationSumUtil(A, newCopy, i+1, result, sum - A[i]);
                }
            }
        }
        private void SubsetUtil1(List<int> A, List<int> currentSet, int index, List<List<int>> result)
        {
            for(int i = index; i < A.Count;)
            {
                List<int> newCopy = new List<int>();
                newCopy.AddRange(currentSet);
                newCopy.Add(A[i]);
                result.Add(newCopy);
                SubsetUtil1(A, newCopy, i + 1, result);

                int dupCount = 0;
                // skip duplicates ??
                while(i+ dupCount + 1 < A.Count && A[i+ dupCount+1] == A[i])
                    {
                       dupCount++;
                    }

                i += dupCount;
                i += 1;
            }
        }

        //private List<List<T>> PrepareMatrix(int row, int col)
        //{

        //}
    }
}
