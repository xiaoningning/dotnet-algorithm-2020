public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int n = grid.Length;
        if (grid[0][0] == 1 || grid[n-1][n-1] == 1) return -1;
        var q = new Queue<Tuple<int, int, int>>();
        q.Enqueue(Tuple.Create(0,0,1));
        while (q.Any()) {
            var t = q.Dequeue();
            if (t.Item1 == n - 1 && t.Item2 == n - 1) return t.Item3;
            foreach (var x in new int[]{t.Item1 - 1, t.Item1, t.Item1 + 1}) {
                foreach (var y in new int[]{t.Item2 - 1, t.Item2, t.Item2 + 1}) {
                    if (x == t.Item1 && y == t.Item2) continue;
                    if (x >= 0 && x < n && y >= 0 && y < n && grid[x][y] == 0) {
                        grid[x][y] = 1;
                        q.Enqueue(Tuple.Create(x, y, t.Item3 + 1));
                    }
                }
            }
        }
        return -1;
    }
}
