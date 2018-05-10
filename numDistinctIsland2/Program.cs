using System;
using System.Collections.Generic;

namespace numDistinctIsland2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] grid = new int[,]{
                {1,1,0,0},
                {1,0,0,0},
                {0,0,0,1},
                {0,0,1,1}
            };
            Console.WriteLine("num of islands {0}", string.Join(',',obj.NumDistinctIslands2(grid)));
        }
    }
    public class Solution {
        private static int[,] directions = new int[,]{ {0, 1}, {1, 0}, {0, -1}, {-1, 0} };
        private int lift = 0;
        public int NumDistinctIslands2(int[,] grid) {
            HashSet<string> islands = new HashSet<string>();
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            this.lift = m * n;
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if (grid[i,j] != 1) continue;
                    List<List<int>> islandXY = new List<List<int>>();
                    DFS(i, j, i, j, grid, islandXY);
                    string normXYstring = NormXY(islandXY);
                    islands.Add(normXYstring);                                    
                }
            }
            return islands.Count;
        }
        void DFS(int i0, int j0, int i, int j, int[,] grid,  List<List<int>> islandXY){
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            if (i < 0 || m <= i || j < 0 || n <= j || grid[i,j] <= 0) return;
            // mark it as visited
            grid[i,j] = -1;
            // relative coordinate of node
            islandXY.Add(new List<int>(){i-i0,j-j0});
            for (int d = 0; d < directions.GetLength(0); d++) {
                DFS(i0, j0, i + directions[d, 0], j + directions[d, 1], grid, islandXY);
            }
        }
        
        string NormXY (List<List<int>> xy){
            List<List<List<int>>> s = new List<List<List<int>>>();
            for(int i = 0; i < 8; i++) s.Add(new List<List<int>>());
            // compute rotations/reflections.
            // x,y x,-y -x,y -x,-y
            // y,-x -y,x -y,-x y,x
            foreach(var p in xy) {
                int x = p[0], y = p[1];
                s[0].Add(new List<int>(){x,y});
                s[1].Add(new List<int>(){x,-y});
                s[2].Add(new List<int>(){-x,y});
                s[3].Add(new List<int>(){-x,-y});
                s[4].Add(new List<int>(){y,-x});
                s[5].Add(new List<int>(){-y,x});
                s[6].Add(new List<int>(){-y,-x});
                s[7].Add(new List<int>(){y,x});
            }
            // normalize coordinate
            foreach(var l in s) l.Sort((a,b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0] );
            foreach (var l in s) {
                for (int i = 1; i < xy.Count; ++i){
                    l[i] = new List<int>(){l[i][0]-l[0][0], l[i][1]-l[0][1]};  
                }                 
                l[0] = new List<int>(){0,0};
            }
            
            // use lift to trans 2d coordinate as 1d
            List<string> res = new List<string>();
            foreach (var l in s) {
                int[] tmp = new int[xy.Count];
                for (int i = 0; i < xy.Count; ++i){
                    tmp[i] = l[i][0] * lift + l[i][1];  
                }                 
                res.Add(string.Join(",", tmp));
            }
            // sort it as the order will be the same
            res.Sort();
            return res[0];
        }
    }    
}
