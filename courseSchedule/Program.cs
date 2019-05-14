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
                // key: from value: to 
                Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
                int[] inDegrees = new int[numCourses];
                for(int i = 0; i < prerequisites.GetLength(0); i++){
                    int c = prerequisites[i,0];
                    int cp = prerequisites[i,1];            
                    if(!prereq.ContainsKey(cp)) prereq[cp] = new List<int>();
                    prereq[cp].Add(c);
                    inDegrees[c]++;
                }
                Queue<int> q = new Queue<int>();
                for (int i = 0; i < numCourses; i ++) {
                    if (inDegrees[i] == 0) q.Enqueue(i);
                }
                while (q.Count != 0) {
                    int t = q.Dequeue();
                    foreach (int c in prereq[t]) {
                        inDegrees[c]--;
                        if (inDegrees[c] == 0) q.Enqueue(c);
                    }
                }
                for (int i = 0; i < numCourses; i ++) {
                    if (inDegrees[i] != 0) return false;;
                }
                return true;        
            }
            
            public bool CanFinish1(int numCourses, int[,] prerequisites) {
                // key: from value: to 
                Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
                for(int i = 0; i < prerequisites.GetLength(0); i++){
                    int c = prerequisites[i,0];
                    int cp = prerequisites[i,1];            
                    if(!prereq.ContainsKey(cp)) prereq[cp] = new List<int>();
                    prereq[cp].Add(c);
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
