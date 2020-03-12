public class Solution {
    public int MaximumMinimumPath(int[][] A) {
        var dirs = new int[,] {{0,1},{1,0},{0,-1},{-1,0}};
        var q = new List<int[]>();
        int r = A.Length, c = A[0].Length, res = A[0][0];
        q.Add(new int[]{A[0][0], 0, 0});
        A[0][0] = -1; // visited
        while (q.Any()) {
            q.Sort((a,b) => b[0] - a[0]);
            var t = q.First();
            q.RemoveAt(0);
            int sc = t[0], i = t[1], j = t[2];
            res = Math.Min(res, sc);
            if (i == r - 1 && j == c - 1) break;
            for (int d = 0; d < 4; d++) {
                int ni = i + dirs[d,0], nj = j + dirs[d,1];
                if (ni < 0 || ni >= r || nj < 0 || nj >= c || A[ni][nj] < 0) continue;
                q.Add(new int[]{A[ni][nj], ni, nj});
                A[ni][nj] = -1;
            }
        }
        // O(rc*logrc)
        return res;
    }
}
