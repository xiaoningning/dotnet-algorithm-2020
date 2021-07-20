public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.GetLength(0), l = grid[0][0], r = n * n;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (!HasPath(grid, m)) l = m + 1;
            else r = m;
        }
        return l;
    }
    bool HasPath(int[][] grid, int t) {
        var dirs = new int[,] {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
        int n = grid.GetLength(0);
        var visited = new HashSet<int>();
        var s = new Stack<int>();
        s.Push(0); 
        visited.Add(0); // x * n + y
        Console.WriteLine(t);
        while (s.Any()) {
            int tmp = s.Pop(), i = tmp / n, j = tmp % n;
            if (i == n - 1 && j == n - 1) return true;
            for (int d = 0; d < 4; d++) {
                int x = i + dirs[d,0], y = j + dirs[d,1];
                if (x < 0 || x >= n || y < 0 || y >= n 
                    || visited.Contains(x * n + y) || grid[x][y] > t) continue;
                s.Push(x * n + y);
                visited.Add(x * n + y);
            }
        }
        return false;
    }
}
