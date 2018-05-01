using System;
using System.Linq;
using System.Collections.Generic;

namespace mergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Interval[] ins = new Interval[]{
                new Interval(1,4),
                new Interval(4,6),
                new Interval(15,130)
            };
            List<Interval> l = new List<Interval>(ins);
            var res = obj.Merge(l);
            Console.WriteLine("merge internals");
            foreach(var r in res){
                Console.WriteLine("{0},{1}", r.start, r.end );
            }
        }
    }
    // Definition for an interval.
    public class Interval {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }
    public class Solution {
        public IList<Interval> Merge(IList<Interval> intervals) {
            List<Interval> res = new List<Interval>();
            if(intervals == null || intervals.Count == 0) return res;            
            List<Interval> tempIntervals = new List<Interval>(intervals);
            tempIntervals.Sort((a,b) => a.start.CompareTo(b.start));
            res.Add(tempIntervals[0]);
            for(int i = 1; i < tempIntervals.Count; i++){
                if (res.Last().end <= tempIntervals[i].start) res.Add(tempIntervals[i]);
                else res.Last().end = Math.Max(tempIntervals[i].end, res.Last().end);
            }            
            return res;
        }
    }
}
