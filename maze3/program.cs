public class Solution {
    public string FindShortestWay(int[][] maze, int[] ball, int[] hole){
        int m = maze.Length, n = maze[0].Length;
        var dists = new int[m,n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                dists[i,j] = Int32.MaxValue;
        var dirs = new int[4,2]{{0,-1},{-1,0},{0,1},{1,0}};
        var way = new char[]{'l','u','r','d'};
        var u = new Dictionary<int,string>();
        var q = new Queue<int[]>();
        q.Enqueue(ball);
        dists[ball[0], ball[1]] = 0;
        while (q.Any()) {
            var t = q.Dequeue();
            for (int i = 0; i < dirs.GetLength(0); i++) {
                int x = t[0], y = t[1], dist = dists[t[0], t[1]];
                // normalize 2d index
                string path = u.ContainsKey(x*n + y) ? u[x*n + y] : "";
                // the same direction untill hit hole
                while (x >= 0 && x < m 
                       && y >= 0 && y < n
                       && maze[x][y] == 0
                       && (x != hole[0] || y != hole[1])) {
                    x += dirs[i,0]; y += dirs[i,1];
                    dist++;
                }
                if (x != hole[0] || y != hole[1]) {
                    x -= dirs[i,0]; y -= dirs[i, 1];
                    dist--;
                }
                path += way[i];
                // find the min dist, revisit the same node
                if (dists[x,y] > dist) {
                    dists[x,y] = dist;
                    u[x*n + y] = path;
                    if (x != hole[0] || y != hole[1])
                        q.Enqueue(new int[]{x, y});
                }
                // less path directions
                else if (dists[x,y] == dist 
                         && u.ContainsKey(x * n + y)
                         && u[x * n + y].CompareTo(path) > 0) {
                    u[x * n + y] = path;
                    if (x != hole[0] || y != hole[1]) 
                        q.Enqueue(new int[]{x, y});
                }
            }
        }
        string res = u.ContainsKey(hole[0]*n + hole[1]) ? u[hole[0]*n + hole[1]] : "";;
        return res == "" ? "impossible": res;
    }
}
