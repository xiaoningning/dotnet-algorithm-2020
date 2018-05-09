using System;
using System.Collections.Generic;

namespace numDistinctIsland
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[,] grid = new int[,]{
                {1,1,0,0},
                {1,1,0,0},
                {0,0,1,1},
                {0,0,1,1}
            };
            Console.WriteLine("num of islands {0}", string.Join(',',obj.NumDistinctIslands(grid)));
        }
    }
    public class Solution {
        private static int[,] directions = new int[,]{ {0, 1}, {1, 0}, {0, -1}, {-1, 0} };
        public int NumDistinctIslands(int[,] grid) {
            HashSet<string> islands = new HashSet<string>();
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if (grid[i,j] != 1) continue;
                    List<List<int>> islandXY = new List<List<int>>();
                    DFS(i, j, i, j, grid, islandXY);
                    string coordinate = string.Empty;
                    foreach(var x in islandXY){
                        coordinate += string.Join(',', x.ToArray()) + "-";
                    } 
                    if(!string.IsNullOrEmpty(coordinate)) islands.Add(coordinate);
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
    }
}
