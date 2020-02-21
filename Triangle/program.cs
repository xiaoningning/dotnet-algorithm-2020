public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int res = 0, n = triangle.Count;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < triangle[i].Count; j++) {
                if (i == 0 && j == 0) continue;
                if (j == 0) triangle[i][j] += triangle[i - 1][j];
                else if (j == triangle[i].Count - 1) triangle[i][j] += triangle[i-1][j-1];
                else triangle[i][j] += Math.Min(triangle[i-1][j-1], triangle[i-1][j]);
            }
        }
        return triangle[n-1].Min();
    }
}
