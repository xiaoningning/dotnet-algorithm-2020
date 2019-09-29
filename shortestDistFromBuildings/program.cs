public class Solution {
    public int ShortestDistance(int[][] grid) {
        int res = Int32.MaxValue, m = grid.GetLength(0), n = grid[0].GetLength(0);
        int[,] dirs = new int[4,2] {{0,1},{1,0},{0,-1},{-1,0}};
        int[,] dist = new int[m,n];
        int[,] cnt = new int[m,n];
        int buildingCnt = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    buildingCnt++;
                    bool[,] visited = new bool[m,n];
                    var q = new Queue<int[]>();
                    q.Enqueue(new int[2]{i,j});
                    int level = 1;
                    while (q.Count != 0) {
                        int size = q.Count;
                        for (int s = 0; s < size; ++s) {
                            var t = q.Dequeue();
                            int a = t[0], b = t[1];
                            for (int k = 0; k < dirs.GetLength(0); ++k) {
                                int x = a + dirs[k,0], y = b + dirs[k,1];
                                if (x >= 0 && x < m 
                                    && y >= 0 && y < n 
                                    && grid[x][y] == 0
                                    && !visited[x,y]) {
                                    visited[x,y] = true;
                                    dist[x,y] += level;
                                    cnt[x,y]++;
                                    q.Enqueue(new int[2]{x, y});
                                }
                            }
                        }
                        level++;
                    }
                }
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0 && cnt[i,j] == buildingCnt) {
                    res = Math.Min(res, dist[i,j]);
                }
            }
        }
        // O(m^2*n^2)
        return res == Int32.MaxValue ? -1 : res;
    }
}
