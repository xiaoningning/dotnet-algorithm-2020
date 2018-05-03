using System;
using System.Collections.Generic;

namespace courseSchedule2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] prereq = new int[,]{
                {0,1},
                {1,2}
            };
            Console.WriteLine("find oder to finish course {0}", string.Join(',', obj.FindOrder(3, prereq)));
        }
        public class Solution {
            public int[] FindOrder(int numCourses, int[,] prerequisites) {
                // key: from value: to 
                Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
                int[] degree = new int[numCourses];
                List<int> res = new List<int>();
                for(int i = 0; i < prerequisites.GetLength(0); i++){
                    int c = prerequisites[i,0];
                    int cp = prerequisites[i,1];            
                    if(!prereq.ContainsKey(cp)) prereq[cp] = new List<int>();
                    prereq[cp].Add(c);
                    degree[c]++;
                }
                // course wiht not any prereq 
                Queue<int> q = new Queue<int>();
                for(int i = 0; i < numCourses; i++){
                    if(degree[i] == 0) q.Enqueue(i);    
                }
                while(q.Count != 0){
                    int t = q.Dequeue();
                    res.Add(t);
                    if (prereq.ContainsKey(t)){
                        foreach(int i in prereq[t]){
                            degree[i]--;
                            if(degree[i] == 0) q.Enqueue(i);
                        }
                    }
                }
                return res.Count == numCourses ? res.ToArray() : new int[]{};        
            } 
        }
    }
}
