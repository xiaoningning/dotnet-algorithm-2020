public class Solution {
    public int MinScoreTriangulation1(int[] A) {
        var m = new Dictionary<string, int>();
        return Helper(A, 0, A.Length -1, m);
    }
    
    int Helper(int[] A, int s, int e, Dictionary<string, int> cache) {
        if (e - s < 2) return 0;
        string key = s + "," + e;
        if (cache.ContainsKey(key)) return cache[key];
        int res = Int32.MaxValue;
        for (int m = s+1; m < e; m++) {
            int sum = Helper(A, s, m, cache);
            sum += A[s]*A[m]*A[e];
            sum += Helper(A, m, e, cache);
            res = Math.Min(res, sum);
        }
        cache.Add(key, res);
        return res;
    }
    
    public int MinScoreTriangulation(int[] A) {
        int n = A.Length;
        int[,] dp = new int[n,n];
        // triangle
        for (int k = 2; k <  n; k++) {
            for (int i = 0; i + k < n; i++) {
                int j = i + k;
                dp[i,j] = Int32.MaxValue;
                // middle point of triangle
                for (int m = i+1; m < j; m++) {
                    // calc min value
                    dp[i,j] = Math.Min(dp[i,j], dp[i,m] + A[i]*A[m]*A[j] + dp[m,j]);
                }
            }
        }
        return dp[0,n-1];
    }
}
