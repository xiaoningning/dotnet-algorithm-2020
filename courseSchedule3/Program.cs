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
                // time: O(n*res.Count)
                // Priority queue is not supported in C#
                foreach(int d in dTimes.Keys){
                    foreach(int t in dTimes[d]){
                        if(time + t > d){
                            int max_i = 0;
                            for(int j = 1; j < res.Count; j++){
                                if(res[j] > res[max_i]) max_i = j;
                            }
                            if(res.Count > 0 && t < res[max_i]){
                                time  += t - res[max_i];
                                res[max_i] = t;
                            }
                        }
                        else {
                            time += t;
                            res.Add(t);
                        }
                    }
                }
                return res.Count;
            }
        }
    }
}
