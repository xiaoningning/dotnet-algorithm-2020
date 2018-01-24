using System;
using System.Collections.Generic;

namespace brickWall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wall list: in the code");
            var wall = new List<List<int>>();
            // [[1,2,2,1],[3,1,2],[1,3,2],[2,4],[3,1,2],[1,3,1,1]]
            wall.Add(new List<int>(new int[]{1,2,2,1}));
            wall.Add(new List<int>(new int[]{3,1,2}));
            wall.Add(new List<int>(new int[]{1,3,2}));
            wall.Add(new List<int>(new int[]{2,4}));
            wall.Add(new List<int>(new int[]{3,1,2}));
            wall.Add(new List<int>(new int[]{1,3,1,1}));
            Console.WriteLine("cut: {0}", LeastBricks(wall));
        }
        static int LeastBricks(List<List<int>> wall) {            
            int res = 0;
            Dictionary<int, int> edgeMap = new Dictionary<int, int>();
            if (wall.Count != 0){
                int cnt = 0;
                foreach (var w in wall)
                {
                    int edge = 0;
                    for (int i = 0; i < w.Count -1; i++){
                        edge += w[i];
                        edgeMap[edge] = edgeMap.ContainsKey(edge) ? edgeMap[edge]+1 : 1;
                        cnt = Math.Max(cnt, edgeMap[edge]);
                    }                   
                }
                res = wall.Count - cnt;
            }
            return res;
        }
    }
}
