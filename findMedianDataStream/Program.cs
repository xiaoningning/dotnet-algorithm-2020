using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMedianDataStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MedianFinder();
            obj.AddNum(-1);
            Console.WriteLine("FindMedian {0}", obj.FindMedian());
            obj.AddNum(-2);
            Console.WriteLine("FindMedian {0}", obj.FindMedian());
            obj.AddNum(-3);
            obj.AddNum(-4);
            obj.AddNum(-5);
            Console.WriteLine("FindMedian {0}", obj.FindMedian());
        }
    }
    public class MedianFinder {

        public MedianFinder() {
            min = new SortedList<int, int>(new DuplicateKeyComparer<int>());
            max = new SortedList<int, int>(new DuplicateKeyComparer<int>());
        }

        public void AddNum(int num) {
            max.Add(num,0);
            // max.Add(min.Last().Key, 0);
            // min.Remove(min.Last().Key);
            if (min.Count < max.Count) {
                min.Add(max.First().Key,0);
                max.RemoveAt(0);
            }
        }

        public double FindMedian() {
            Console.WriteLine("min:"+string.Join(",", min.Keys));
            Console.WriteLine("max:"+string.Join(",", min.Keys));
            return (min.Count > max.Count) ? 
                    (double) min.Last().Key 
                    :  0.5 * (min.Last().Key + max.First().Key);
        }

        private SortedList<int, int> min;
        private SortedList<int, int> max;
    }
    public class DuplicateKeyComparer<TKey> : IComparer<TKey> 
                where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);
            if (result == 0) return 1;   // Handle equality as beeing greater
            else return result;
        }        
    }
 }
    
