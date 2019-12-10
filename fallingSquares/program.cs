public class Solution {
    public IList<int> FallingSquares(int[][] positions) {
        int n = positions.Length, cur = 0;
        var heights = new int[n]; 
        var res = new List<int>();
        for (int i = 0; i < n; ++i) {
            int left = positions[i][0], right = left + positions[i][1];
            heights[i] += positions[i][1];
            for (int j = i + 1; j < n; ++j) {
                int l = positions[j][0], r = l + positions[j][1];
                // overlap
                if (l < right && r > left) {
                    heights[j] = Math.Max(heights[j], heights[i]);
                }
            }
        }
        foreach (int h in heights) {
            cur = Math.Max(cur, h);
            res.Add(cur);
        }
        return res;
    }
}
