using System;
using System.Collections.Generic;

namespace courseSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] prereq = new int[,]{
                {0,1},
                {1,0}
            };
            Console.WriteLine("course schedule: {0}", obj.CanFinish(2, prereq));
        }
        public class Solution {
            public bool CanFinish(int numCourses, int[,] prerequisites) {
                Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
                for(int i = 0; i < prerequisites.GetLength(0); i++){
                    int c = prerequisites[i,0];
                    int cp = prerequisites[i,1];            
                    if(!prereq.ContainsKey(c)) prereq[c] = new List<int>();
                    prereq[c].Add(cp);
                }
                bool[] visited = new bool[numCourses];
                for(int i = 0; i < numCourses; i++){
                    if(!CheckPreReq(prereq, visited, i)) return false;    
                }
                return true;        
            }
            
            bool CheckPreReq(Dictionary<int, List<int>> prereq, bool[] visited, int i){
                if (visited[i]) return false;
                else visited[i] = true;
                
                if (prereq.ContainsKey(i)){
                    foreach(int n in prereq[i]){                
                        if(!CheckPreReq(prereq, visited, n)) return false;
                    }    
                }
                visited[i] = false;
                return true;
            }
        }
    }
}
