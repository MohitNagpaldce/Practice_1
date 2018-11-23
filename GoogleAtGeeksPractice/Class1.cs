using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAtGeeksPractice
{
    /// <summary>
    /// Problems from https://practice.geeksforgeeks.org/explore/?company%5B%5D=Google&difficulty%5B%5D=1&difficulty%5B%5D=2&page=1.
    /// </summary>
    public class GoogleAtGeeksPractice
    {
        public void SolveJarvisPalindrom()
        {
            string inputCount = Console.ReadLine();
            int i;
            if (Int32.TryParse(inputCount, out i))
            {
                List<string> allInputs = new List<string>();
                for(int j = 0; j < i; j ++)
                {
                    allInputs.Add(Console.ReadLine());
                }

                foreach(string s in allInputs)
                {
                    if(GoogleAtGeeksPractice.IsPalindromString(s))
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
            }

        }

        public void SolvePainterProblem()
        {
            string inputCount = Console.ReadLine();
            int i;

            if (Int32.TryParse(inputCount, out i))
            {
                string inputLine1, inputLine2;
                for (int j = 0; j < i; j++)
                {
                    inputLine1 = Console.ReadLine();
                    inputLine2 = Console.ReadLine();
                    string[] values1 = inputLine1.Split(' ');
                    int numOfPainters = Int32.Parse(values1[0]);
                    List<int> boards = new List<int>();
                    string[] values2 = inputLine2.Split(' ');
                    foreach (string entry in values2)
                    {
                        boards.Add(Int32.Parse(entry));
                    }

                    int result = GoogleAtGeeksPractice.ComputeMinPaintTime(numOfPainters, boards);
                    Console.WriteLine(result);
                }
            }
        }

        public void SolveMaxAProblem()
        {

        }

        public void SolveUglyNumber()
        {
            int n = 15;
            int result = this.GetUglyNumber(n);
            Console.WriteLine($"{result}");
        }

        private int GetUglyNumber(int n)
        {
            int result = 1;
            int i = 2;
            int next2mul = 2;
            int next3mul = 3;
            int next5mul = 5;
            int i2 = 0, i3 = 0, i5 = 0;
            List<int> numbers = new List<int>();
            numbers = Enumerable.Repeat<int>(0, n + 1).ToList();
            numbers[0] = 1;

            while(i <= n)
            {
                result = MinOf3(next2mul, next3mul, next5mul);
                numbers[i] = result;
                if (result == next2mul)
                {
                    i2++;
                    next2mul *= numbers[i2]*2;
                }
                else if (result == next3mul)
                {
                    i3++;
                    next3mul *= numbers[i3] * 3;
                }
                else
                {
                    i5++;
                    next5mul *= numbers[i5] * 5;
                }

            }

            return result;
        }

        private int MinOf3(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        /// <summary>
        /// Computes the minimum time needed to do the total painting.
        /// </summary>
        /// <param name="n">The number of painters.</param>
        /// <param name="boards">The elements on the board.</param>
        /// <returns></returns>
        private static int ComputeMinPaintTime(int n, List<int> boards)
        {
            int totalTime = 0;
            if (boards == null || boards.Count == 0)
            {
                return totalTime;
            }
            
            if (n == 0)
            {
                return Int32.MaxValue;
            }

            boards.Sort();

            for (int i = boards.Count-1; i >=0;)
            {
                totalTime += boards[i];
                i -= n;
            }

            return totalTime;
        }

        /// <summary>
        /// True if string is palindrom.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <returns>true, if string is palindrom.</returns>
        private static bool IsPalindromString(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            bool result = true;

            Regex regex = new Regex(@"[^a-zA-Z0-9]");
            s = regex.Replace(s, "");

            int length = s.Length;
            for(int i = 0, j = length-1; i < j; i++, j--)
            {
                if (char.ToUpperInvariant(s[i]) != char.ToUpperInvariant(s[j]))
                {
                    result = false;
                    break;
                }
            }

            return result;

        }

    }
}
