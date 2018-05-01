using System;
using System.Collections.Generic;

namespace meetingRoom2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Interval[] rooms = new Interval[]{
                new Interval(0,30),
                new Interval(5,6),
                new Interval(15,130)
            };

            Console.WriteLine("Min Meeting Rooms: {0}", obj.MinMeetingRooms(rooms));
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
        public int MinMeetingRooms(Interval[] intervals) {
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            foreach(var i in intervals){
                if(!map.ContainsKey(i.start)) map.Add(i.start,0);
                if(!map.ContainsKey(i.end)) map.Add(i.end,0);
                map[i.start]++;
                map[i.end]--;
            }
            int res = 0; 
            int room = 0;
            foreach(int i in map.Keys){
                room += map[i];
                res = Math.Max(res, room);
            }
            return res;
        }
    }
}
