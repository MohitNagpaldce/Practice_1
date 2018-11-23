using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBitPractice
{
    public class InterviewBitPractice
    {
        public void SolveKinghtProblem()
        {
            // 8 8 1 1 8 8
            int result = this.knight(8, 8, 1, 1, 8, 8);
            Console.WriteLine(result);
        }

        public void SolveAmazingString()
        {
            string s = "ABEC";
            int result = this.solve(s);
        }

        public void SolveVistingNumber()
        {
            List<int> visited = new List<int>() { 2, 5 };
            int a = 5;

            //OrderedDictionary orig = new OrderedDictionary();
            //visited.ForEach(i => orig.Add(i, 0));
            //Dictionary<OrderedDictionary, int> setToCountMap = new Dictionary<OrderedDictionary, int>();
            //int result = this.SolveVistingNumberUtil(orig, a, setToCountMap);
            //Console.WriteLine($"Result = {result

            SortedSet<int> input = new SortedSet<int>();
            visited.ForEach(val => input.Add(val));
            Dictionary<SortedSet<int>, int> setToCountMap = new Dictionary<SortedSet<int>, int>();
            int result = this.SolveVistingNumberUtil(input, a, setToCountMap);
            Console.WriteLine($"Result = {result}");
        }

        public int SolveVistingNumberUtil(
            OrderedDictionary entry, 
            int a,
            Dictionary<OrderedDictionary, int> setToCountMap)
        {
            if(entry.Values.Count == a)
            {
                setToCountMap.Add(entry, 1);
                return 1;

            }
            else if (setToCountMap.ContainsKey(entry))
            {
                return setToCountMap[entry];
            }

            int result = 0;
            HashSet<OrderedDictionary> nextLevelEntries = new HashSet<OrderedDictionary>();
            

            foreach (int i in entry.Keys.OfType<int>().ToList())
            {
                OrderedDictionary newdic = new OrderedDictionary();
                entry.Keys.OfType<int>().ToList().ForEach(val => newdic.Add(val, 0));

                OrderedDictionary newdic2 = new OrderedDictionary();
                entry.Keys.OfType<int>().ToList().ForEach(val => newdic2.Add(val, 0));

                if (i-1 >0 && !entry.Contains(i-1))
                {
                    newdic.Add(i - 1, 0);
                    nextLevelEntries.Add(newdic);
                }

                if (i+1 <= a && !entry.Contains(i + 1))
                {
                    newdic2.Add(i + 1, 0);
                    nextLevelEntries.Add(newdic2);
                }
            }

            foreach(OrderedDictionary singleList in nextLevelEntries)
            {
                Console.WriteLine($"length {singleList.Count} val{ string.Join(",", singleList.Keys.OfType<int>().ToList().Select(en => en))}");
                result += SolveVistingNumberUtil(singleList, a, setToCountMap);
            }

            setToCountMap.Add(entry, result);
            return result;
        }

        public int SolveVistingNumberUtil(
            SortedSet<int> entry,
            int a,
            Dictionary<SortedSet<int>, int> setToCountMap)
        {
            if (entry.Count == a)
            {
                setToCountMap.Add(entry, 1);
                return 1;

            }
            else if (setToCountMap.ContainsKey(entry))
            {
                return setToCountMap[entry];
            }

            int result = 0;
            HashSet<SortedSet<int>> nextLevelEntries = new HashSet<SortedSet<int>>();


            foreach (int i in entry)
            {
                SortedSet<int> newdic = new SortedSet<int>();
                entry.ToList().ForEach(val => newdic.Add(val));

                SortedSet<int> newdic2 = new SortedSet<int>();
                entry.ToList().ForEach(val => newdic2.Add(val));

                if (i - 1 > 0 && !entry.Contains(i - 1))
                {
                    newdic.Add(i - 1);

                    if (!nextLevelEntries.Any(en => en.Equals(newdic)))
                    {
                        nextLevelEntries.Add(newdic);
                    }
                }

                if (i + 1 <= a && !entry.Contains(i + 1))
                {
                    newdic2.Add(i + 1);
                    if (!nextLevelEntries.Any(en => en.Equals(newdic2)))
                    {
                        nextLevelEntries.Add(newdic2);
                    }
                }
            }

            foreach (SortedSet<int> singleList in nextLevelEntries)
            {
                Console.WriteLine($"length {singleList.Count} val{ string.Join(",", singleList.ToList().Select(en => en))}");
                result += SolveVistingNumberUtil(singleList, a, setToCountMap);
            }

            setToCountMap.Add(entry, result);
            return result;
        }
        public int solve(string A)
        {
            int mod = 10003;
            int result = 0;
            int length = A.Length;
            for(int i = 0; i < length; i++)
            {
                if(this.IsVowel(A[i]))
                {
                    result += (length - i);
                    result %= mod;
                }
            }

            return result;
        }
        public string SolveAttendence(int k, int a)
        {
            int pending = k;
            int answer = -1;
            for(int start=1; start < 9; start++)
            {
                int pown = 0;
                int s = start;
                int curMaxDiff = 1;
                bool found = false;
                while(pending >= 0)
                {
                    pending -= (int)Math.Pow(10, pown);
                    if(pending == 0)
                    {
                        answer = start;
                        found = true;
                        break;
                    }

                    pown++;
                    s = (int)Math.Pow(10, pown) * start;
                    if (s > a)
                    {
                        break;
                    }

                    curMaxDiff *= 10;
                    if (pending < curMaxDiff)
                    {
                        if (s + pending - 1 > a)
                        {
                            pending -= a - s + 1;
                            break;
                        }
                        else
                        {
                            answer = s + pending - 1;
                            found = true;
                            break;
                        }
                    }
                }

                if(found)
                {
                    break;
                }
            }

            return answer.ToString();
        }
        private bool IsVowel(char c)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
                || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                return true;
            }

            return false;
        }

        //        N, M, x1, y1, x2, y2
        //where N and M are size of chess board%
        //x1, y1 coordinates of source point
        //x2, y2  coordinates of destination point
        private int knight(int A, int B, int C, int D, int E, int F)
        {
            Cordinate start = new Cordinate() { x = C, y = D };
            Cordinate end = new Cordinate() { x = E, y = F };
            List<List<bool>> isvisted = new List<List<bool>>();
            List<bool> singleEntry = Enumerable.Repeat<bool>(false, B).ToList();
            isvisted = Enumerable.Repeat<List<bool>>(singleEntry, A).ToList();
            int minSoFar = Int16.MaxValue;
            KnightUtil(A, B, start, end, 0, isvisted, ref minSoFar);
            if(minSoFar != Int16.MaxValue)
            {
                return minSoFar;
            }

            return -1;
        }
        private void KnightUtil(int A, int B, Cordinate current, Cordinate end, int steps, List<List<bool>> isVisited, ref int minSoFar)
        {
            if (current.Equals(end))
            {
                minSoFar = Math.Min(steps, minSoFar);
            }
            else
            {
                List<Cordinate> neighbours = this.AllPossibleFromOneLocation(A, B, current);
                foreach (Cordinate item in neighbours)
                {
                    if (!isVisited[item.x][item.y])
                    {
                        isVisited[item.x][item.y] = true;
                        KnightUtil(A, B, item, end, steps + 1, isVisited, ref minSoFar);
                        isVisited[item.x][item.y] = false;
                    }
                }
            }

            return;
        }
        private List<Cordinate> AllPossibleFromOneLocation(int A, int B, Cordinate entry)
        {
            int C = entry.x;
            int D = entry.y;
            List<Cordinate> possibleCorridnates = new List<Cordinate>();
            ////for (int x = -2; x<=2; x++)
            ////    for(int y = -2; y <=2; y++)
            ////    {
            ////        if(x == 0 || y == 0 || (Math.Abs(x) + Math.Abs(y) != 3))
            ////        {
            ////            continue;
            ////        }

            ////        int newx = C + x;
            ////        int newy = D + y;
            ////        if (this.isSafe(A,B, newx, newy))
            ////        { 
            ////            possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            ////        }
            ////    }

            //// first coordinate 
            int newx, newy;
            newx = C - 1;
            newy = D - 2;
            if (this.isSafe(A, B, newx, newy))
            {
                possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            }

            newx = C + 1;
            newy = D - 2;

            if (this.isSafe(A, B, newx, newy))
            {
                possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            }

            newx = C - 2;
            newy = D - 1;

            if (this.isSafe(A, B, newx, newy))
            {
                possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            }

            newx = C + 2;
            newy = D - 1;

            if (this.isSafe(A, B, newx, newy))
            {
                possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            }

            newx = C - 2;
            newy = D + 1;

            if (this.isSafe(A, B, newx, newy))
            {
                possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            }

            newx = C + 2;
            newy = D + 1;

            if (this.isSafe(A, B, newx, newy))
            {
                possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            }

            newx = C - 1;
            newy = D + 2;

            if (this.isSafe(A, B, newx, newy))
            {
                possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            }

            newx = C + 1;
            newy = D + 2;

            if (this.isSafe(A, B, newx, newy))
            {
                possibleCorridnates.Add(new Cordinate() { x = newx, y = newy });
            }

            return possibleCorridnates;
        }
        private bool isSafe(int A, int B, int C, int D)
        {
            if (C < A && D < B && C >=0 && D>=0)
            {
                return true;
            }

            return false;

        }
    }

    internal class Cordinate
    {
        internal int x;
        internal int y;

        public override bool Equals(object obj)
        {
            Cordinate input = obj as Cordinate;
            return input.x == this.x && input.y == this.y;
        }
    }

    public class OrderedSet<T> : ICollection<T>
    {
        private readonly IDictionary<T, LinkedListNode<T>> m_Dictionary;
        private readonly LinkedList<T> m_LinkedList;

        public OrderedSet()
            : this(EqualityComparer<T>.Default)
        {
        }

        public OrderedSet(IEqualityComparer<T> comparer)
        {
            m_Dictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
            m_LinkedList = new LinkedList<T>();
        }

        public int Count
        {
            get { return m_Dictionary.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return m_Dictionary.IsReadOnly; }
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        public void Clear()
        {
            m_LinkedList.Clear();
            m_Dictionary.Clear();
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> node;
            bool found = m_Dictionary.TryGetValue(item, out node);
            if (!found) return false;
            m_Dictionary.Remove(item);
            m_LinkedList.Remove(node);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_LinkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T item)
        {
            return m_Dictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            m_LinkedList.CopyTo(array, arrayIndex);
        }

        public bool Add(T item)
        {
            if (m_Dictionary.ContainsKey(item)) return false;
            LinkedListNode<T> node = m_LinkedList.AddLast(item);
            m_Dictionary.Add(item, node);
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            bool result = true;
            OrderedSet<T> incoming = obj as OrderedSet<T>;
            if (incoming != null)
            {
                if (this.Count == incoming.Count)
                {
                    IEnumerator<T> curr = this.GetEnumerator();
                    IEnumerator<T> inc = incoming.GetEnumerator();
                    while (curr.MoveNext())
                    {
                        inc.MoveNext();
                        if (!curr.Current.Equals(inc.Current))
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
