public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
        Array.Sort(envelopes,(a,b) => a[0] == b[0] ? b[1] - a[1] : a[0] - b[0]);
        var dp = new List<int>();
        foreach (var e in envelopes) {
            int left = 0, right = dp.Count;
            while (left < right) {
                int mid = (left + right) / 2;
                if (dp[mid] < e[1]) left = mid + 1;
                else right = mid;
            }
            if (right >= dp.Count) dp.Add(e[1]);
            else dp[right] = e[1];
        }
        return dp.Count;
    }
}
