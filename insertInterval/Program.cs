using System;
using System.Collections.Generic;

namespace insertInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var newInterval = new Interval(2,5);
            List<Interval> intervals = new List<Interval>();
            var tmp =  new Interval(1,3);
            intervals.Add(tmp);
            tmp =  new Interval(6,9);
            intervals.Add(tmp);
            Console.WriteLine("insert intervals");
            var res = obj.Insert(intervals, newInterval);
            foreach (var r in res)
            {
                Console.WriteLine("{0} {1}", r.start, r.end);
            }
        }
    }

    /**
    * Definition for an interval.
    */
    public class Interval {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }
 
    public class Solution {
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
            List<Interval> res = new List<Interval>();
            int n = intervals.Count, cur = 0;
            while (cur < n && intervals[cur].end < newInterval.start) {
                res.Add(intervals[cur++]);
            }
            while (cur < n && intervals[cur].start <= newInterval.end) {
                newInterval.start = Math.Min(newInterval.start, intervals[cur].start);
                newInterval.end = Math.Max(newInterval.end, intervals[cur].end);
                cur++;
            }
            res.Add(newInterval);
            while (cur < n) {
                res.Add(intervals[cur++]);
            }
            return res;
        }
    }
}
