using System;
using System.Collection.Generics;
using System.Linq;

namespace FindMedianDataStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("add binary {0}", obj.MedianFinder().Add(1));
        }
    }
    public class MedianFinder {

        /** initialize your data structure here. */
        public MedianFinder() {

        }

        public void AddNum(int num) {
            min.Add(num,0);
            max.Add(min.Last().Key, 0);
            min.Remove(min.Last().Key);
            if (min.Count < max.Count) {
                min.Add(max.First().Key,0);
                max.Remove(max.First().Key);
            }
        }

        public double FindMedian() {
            return (min.Count > max.Count) ? 
                    (double) min.Last().Key 
                    :  0.5 * (min.Last().Key + max.First().Key);
        }

        private SortedList<int, int> min = new SortedList<int, int>();
        private SortedList<int, int> max = new SortedList<int, int>();
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */
 }
    
