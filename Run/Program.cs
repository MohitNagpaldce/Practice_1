using HeapsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreedyAlgorithms;
using GoogleAtGeeksPractice;
using InterviewBitPractice;
using MathLib;
using BackTrackingLib;
using SumoLogicBEContest_11_23;


namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestInterviewBitPractice_Week2_Q3();
            // TestTSProblem();
            // TestSumoLogicContestProblem();
            //TestMathLib();

            //TestBackTrackingProblem();
            TestSumoLogicBEContest();
        }

        static void TestSumoLogicBEContest()
        {
            SumoLogicBEContest be = new SumoLogicBEContest_11_23.SumoLogicBEContest();
            be.solve("abab");
        }
        static void TestMathLib()
        {
            MathLibs m = new MathLibs();
            //List<int> input = new List<int>() { 1, 3, 5 };
            //m.SumOfHammingDistance(input);

            //string input = "DTNGJPURFHYEW";
            //m.RankOfString(input);

            // m.uniquePaths(2, 2);
            m.RankOfStringWithRepeat("asasdsdsadasdadsadasdsa");

            // expected value : 502900

            //asasdsdsadasdadsadasdsa 
        }

        static void TestHeap()
        {
            int[] arr = { 10, 64, 7, 52, 32, 18, 2, 48 };
            Heap hp = new Heap();
            hp.HeapSortMaxHeap(arr);
        }

        static void TestheapCount()
        {
            Heap hp = new Heap();
            int input = 10;
            int result = hp.CountHeaps(input);
            Console.WriteLine($"input : {input} result{result}");
        }

        static void TestGreedyAlogrithms()
        {
            GreedyAlogs algos = new GreedyAlogs();
            algos.GasStationProblem();
        }

        static void TestGooglePractice()
        {
            GoogleAtGeeksPractice.GoogleAtGeeksPractice practice = new GoogleAtGeeksPractice.GoogleAtGeeksPractice();
            practice.SolvePainterProblem();
        }

        static void TestInterviewBitPractice()
        {
            InterviewBitPractice.InterviewBitPractice practice = new InterviewBitPractice.InterviewBitPractice();
            // practice.SolveAttendence(5, 12);
            practice.SolveVistingNumber();
        }

        static void TestInterviewBitPractice_Week2_Q1()
        {
            WeeklyContest2 week2 = new WeeklyContest2();
            List<int> A = new List<int>() {1,2,3 };
            List<List<int>> B = new List<List<int>>()
            {
                { new List<int>() {2,1,1 } },
                { new List<int>() {2,1,2 } },
                { new List<int>() {1,3,1 }},
                { new List<int>() {2,1,3 }},
            };

            int result = week2.Solve(A, B);
            Console.WriteLine($"Result{result}");
        }

        static void TestBackTrackingProblem()
        {
            BackTrackingLibs lib = new BackTrackingLibs();
            List<int> input = new List<int>() { 8, 10, 6, 11, 1, 16, 8 };
            // lib.subsets1(input);
            // lib.combinationSum(input, 28);
            // lib.PalindromicPartioning("ababbbabbababa");
            lib.letterCombinations("2");
        }

        /// <summary>
        ///  Valuable Nodes problem.
        /// </summary>
        static void TestInterviewBitPractice_Week2_Q3()
        {
            WeeklyContest2 week2 = new WeeklyContest2();
            List<int> A = new List<int>() { 0, 1, 1, 1, 3, 3, 6, 6 };
            List<int> B = new List<int>() { 1, 2, 3, 4, 5, 100, 7, 8 };

            /// new input 
            A = new List<int>() { 0, 1, 1, 1, 3, 3, 6, 6 };
            B = new List<int>() { 100, 2, 3, 4, 5, 6, 7, 8 };
            int result = week2.Solve(A, B);
            Console.WriteLine($"Result{result}");
        }

        static void TestTSProblem()
        {
            TravellingSalesManProblem p = new GoogleAtGeeksPractice.TravellingSalesManProblem();
            p.SolveTravellingSalesManProblem();
        }

        static void TestSumoLogicContestProblem()
        {
            /// problem 1
            SumoLogicContest sumoLogicContest = new InterviewBitPractice.SumoLogicContest();
            List<int> input = new List<int>() { 2,2};
            // sumoLogicContest.solve(input);

            // sumoLogicContest.solve("bcccabbabc");

            sumoLogicContest.minSteps("00", "001");

        }
    }
}
