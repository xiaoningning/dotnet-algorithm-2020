using System;
using System.Collections.Generic;

namespace courseSchedule3
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] course = new int[,]{
                {5,5},
                {4,6},
                {2,6}
            };
            Console.WriteLine("Schedule Course {0}", obj.ScheduleCourse(course));
        }
        public class Solution {
            public int ScheduleCourse(int[,] courses) {
                SortedDictionary<int, List<int>> dTimes = new SortedDictionary<int, List<int>>();
                for(int i = 0; i < courses.GetLength(0); i++){
                    if(!dTimes.ContainsKey(courses[i,1])) dTimes[courses[i,1]] = new List<int>();
                    dTimes[courses[i,1]].Add(courses[i,0]);   
                }
                List<int> res = new List<int>();
                int time = 0;
                foreach(int d in dTimes.Keys){
                    foreach(int start in dTimes[d]){
                        time += start;
                        res.Add(start);
                        res.Sort();
                        if(time > d){
                            time -= res[res.Count-1];
                            res.RemoveAt(res.Count-1);
                        }                            
                    }
                }
                return res.Count;
            }
        }
    }
}
