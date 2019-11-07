public class Solution {
    public int ShortestDistance(int[][] maze, int[] start, int[] destination) {
        if (!maze.Any() || !maze[0].Any()) return -1;
        int m = maze.Length, n = maze[0].Length;
        var dists = new int[m,n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                dists[i,j] = Int32.MaxValue;
        var dirs = new int[4,2]{{0,-1},{-1,0},{0,1},{1,0}};
        var q = new Queue<int[]>();
        q.Enqueue(start);
        dists[start[0], start[1]] = 0;
        while (q.Any()) {
            var t = q.Dequeue();
            for (int i = 0; i < dirs.GetLength(0); i++) {
                int x = t[0], y = t[1], dist = dists[t[0], t[1]];
                // the same direction untill hit wall
                while (x >= 0 && x < m && y >= 0 && y < n && maze[x][y] == 0) {
                    x += dirs[i,0]; y += dirs[i,1];
                    dist++;
                }
                x -= dirs[i,0]; y -= dirs[i, 1];
                dist--;
                // find the min dist, revisit the same node
                if (dists[x,y] > dist) {
                    dists[x,y] = dist;
                    if (x != destination[0] || y != destination[1])
                        q.Enqueue(new int[]{x, y});
                }
            }
        }
        int res = dists[destination[0], destination[1]];
        return res == Int32.MaxValue ? -1: res;
    }
}
