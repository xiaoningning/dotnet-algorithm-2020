public class Solution {
    public int MinTotalDistance(int[][] grid) {
        var cols = new List<int>();
        var rows = new List<int>();
        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; j < grid[i].GetLength(0); j++) {
                if (grid[i][j] == 1) {
                    rows.Add(i);
                    cols.Add(j);
                }
            }
        }
        cols.Sort();
        int res = 0, x = 0, y = rows.Count - 1;
        while (x < y) res += rows[y] - rows[x] + cols[y--] - cols[x++];
        return res;
    }
}
