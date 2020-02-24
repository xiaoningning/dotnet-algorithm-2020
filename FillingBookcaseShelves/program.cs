public class Solution {
    public int MinHeightShelves(int[][] books, int shelf_width) {
        int n = books.Length;
        // dp[i] := min height of placing books[0] ~ books[i]
        var dp = new int[n];
        Array.Fill(dp, Int32.MaxValue / 2);
        for (int i = 0; i < n; i++) {
            int h = 0, w = 0;
            for (int j = i; j < n; j++) {
                if ((w += books[j][0]) > shelf_width) break;
                h = Math.Max(h, books[j][1]);
                dp[j] = Math.Min(dp[j], (i == 0 ? 0 : dp[i-1]) + h);
            }
        }
        return dp.Last();
    }
}
