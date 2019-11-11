public class Solution {
    public int FindCheapestPrice1(int n, int[][] flights, int src, int dst, int K) {
        var dp = new int[n];
        // don't use int32.maxvalue
        // + price later overflow as negative
        for (int j = 0; j < n; j++) dp[j] = (int)1e9;
        dp[src] = 0;
        for (int i = 0; i <= K; ++i) {
            // dp is prevous K
            int[] t = new int[n];
            Array.Copy(dp, 0, t, 0, n);
            foreach (var x in flights) {
                t[x[1]] = Math.Min(t[x[1]], dp[x[0]] + x[2]);
            }
            Array.Copy(t, 0, dp, 0, n);;
        }
        return (dp[dst] == (int)1e9) ? -1 : dp[dst];
    }
    // BFS
    int res = (int)1e9;
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        var visited = new bool[n];
        var m = new Dictionary<int, List<int[]>>();
        foreach (var f in flights){
            if (!m.ContainsKey(f[0])) m.Add(f[0], new List<int[]>());
            m[f[0]].Add(new int[]{f[1],f[2]});
        }
        helper(m, src, dst, K, visited, 0);
        return (res == (int)1e9) ? -1 : res;
    }
    void helper(Dictionary<int, List<int[]>> m, int cur, int dst, int K, bool[] visited, int cost) {
        if (cur == dst) {
            res = cost; 
            return;
        } 
        if (!m.ContainsKey(cur)) return;
        if (K < 0) return;
        foreach (var a in m[cur]) {
            if (visited[a[0]] || cost + a[1] > res) continue;
            visited[a[0]] = true;
            helper(m, a[0], dst, K - 1, visited, cost + a[1]);
            visited[a[0]] = false;
        }
    }
}
