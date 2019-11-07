public class Solution {
    public bool HasPath(int[][] maze, int[] start, int[] destination) {
        if (!maze.Any() || !maze[0].Any()) return true;
        int m = maze.Length, n = maze[0].Length;
        var visited = new bool[m,n];
        var dirs = new int[4,2]{{0,-1},{-1,0},{0,1},{1,0}};
        var q = new Queue<int[]>();
        q.Enqueue(start);
        while (q.Any()) {
            var t = q.Dequeue();
            if (t[0] == destination[0] && t[1] == destination[1]) return true;
            for (int i = 0; i < dirs.GetLength(0); i++) {
                int x = t[0], y = t[1];
                // the same direction untill hit wall
                while (x >= 0 && x < m && y >= 0 && y < n && maze[x][y] == 0) {
                    x += dirs[i,0]; y += dirs[i,1];
                }
                x -= dirs[i,0]; y -= dirs[i, 1];
                if (!visited[x, y]) {
                    visited[x, y] = true;
                    q.Enqueue(new int[]{x, y});
                }
            }
        }
        return false;
    }
}
