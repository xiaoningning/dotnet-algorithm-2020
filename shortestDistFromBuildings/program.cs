public class Solution {
    public int ShortestDistance(int[][] grid) {
        int res = Int32.MaxValue, m = grid.GetLength(0), n = grid[0].GetLength(0);
        int[][] dirs = new int[4][];
        dirs[0] = new int[] {0,1};
        dirs[1] = new int[] {1,0};
        dirs[2] = new int[] {0,-1};
        dirs[3] = new int[] {-1,0};
        int[,] sum = new int[m,n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    res = Int32.MaxValue;
                    int[,] dist = new int[m,n];
                    bool[,] visited = new bool[m,n];
                    var q = new Queue<int[]>();
                    q.Enqueue(new int[2]{i,j});
                    while (q.Count != 0) {
                        var t = q.Dequeue();
                        int a = t[0], b = t[1];
                        for (int k = 0; k < dirs.GetLength(0); ++k) {
                            int x = a + dirs[k][0], y = b + dirs[k][1];
                            if (x >= 0 && x < m 
                                && y >= 0 && y < n 
                                && grid[x][y] == 0
                                && !visited[x,y]) {
                                visited[x,y] = true;
                                dist[x,y] = dist[a,b] + 1;
                                sum[x,y] += dist[x,y];
                                q.Enqueue(new int[2]{x, y});
                                res = Math.Min(res, sum[x,y]);
                            }
                        }
                    }
                }
            }
        }
        return res == Int32.MaxValue ? -1 : res;
    }
}
