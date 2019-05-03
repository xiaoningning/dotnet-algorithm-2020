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

        /** initialize your data structure here. */
        public MedianFinder() {
            min = new SortedDictionary<int, List<int>>();
            max = new SortedDictionary<int, List<int>>();
            minC = 0;
            maxC = 0;
        }

        public void AddNum(int num) {
            if(!max.ContainsKey(num)) max.Add(num,new List<int>());
            max[num].Add(num);
            maxC++;
            if (minC < maxC) {
                if(!min.ContainsKey(max.First().Key)) 
                    min.Add(max.First().Key,new List<int>());
                min[max.First().Key].Add(max.First().Key);
                minC++;
                max.First().Value.RemoveAt(0);
                maxC--;
                if(max.First().Value.Count == 0) max.Remove(max.First().Key);
            }
        }

        public double FindMedian() {
            return (minC > maxC) ? 
                    (double) min.Last().Key 
                    :  0.5 * (min.Last().Key + max.First().Key);
        }

        private SortedDictionary<int, List<int>> min;
        private int minC;
        private SortedDictionary<int, List<int>> max;
        private int maxC;
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */
 }
    
