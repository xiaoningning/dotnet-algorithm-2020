using System;

namespace meetingRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Interval[] rooms = new Interval[]{
                new Interval(0,30),
                new Interval(5,6),
                new Interval(100,130)
            };

            Console.WriteLine("CanAttendMeetings {0}", obj.CanAttendMeetings(rooms));
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
        public bool CanAttendMeetings1(Interval[] intervals) {
            if(intervals == null) return false;
            for(int i = 0; i < intervals.Length; i++){
                for(int j = i+1; j < intervals.Length; j++){
                    if((intervals[i].start >= intervals[j].start && intervals[i].start < intervals[j].end)
                    || (intervals[j].start >= intervals[i].start && intervals[j].start < intervals[i].end) ) return false;
                }
            }
            return true;
        }

        public bool CanAttendMeetings(Interval[] intervals) {
            if(intervals == null) return false;
            
            Array.Sort(intervals, (a,b) => a.start.CompareTo(b.start));
            for(int i = 1; i < intervals.Length; i++){
                if(intervals[i].start < intervals[i-1].end) return false;               
            }
            return true;
        }
    }
}
