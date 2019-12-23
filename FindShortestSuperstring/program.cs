public class Solution {
    public string ShortestSuperstring(string[] A) {
        int n = A.Length;
        int[,] graph = new int[n,n];
        // build the graph
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                graph[i,j] = calc(A[i], A[j]);
                graph[j,i] = calc(A[j], A[i]);
            }
        }
        int[,] dp = new int[1 << n,n];
        int[,] path = new int[1 << n,n];
        int last = -1, min = Int32.MaxValue;
		
        // Travelling salesmane problem DP
        for (int i = 1; i < (1 << n); i++) {
            for (int t = 0; t < n; t++) dp[i,t] = Int32.MaxValue;
            for (int j = 0; j < n; j++) {
                if ((i & (1 << j)) > 0) {
                    int prev = i - (1 << j);
                    if (prev == 0) {
                        dp[i,j] = A[j].Length;
                    } else {
                        for (int k = 0; k < n; k++) {
                            if (dp[prev,k] < Int32.MaxValue
                                && dp[prev,k] + graph[k,j] < dp[i,j]) {
                                dp[i,j] = dp[prev,k] + graph[k,j];
                                path[i,j] = k;
                            }
                        }
                    }
                }
                if (i == (1 << n) - 1 && dp[i,j] < min) {
                    min = dp[i,j];
                    last = j;
                }
            }
        }
		
        // build the path
        var sb = new StringBuilder();
        int cur = (1 << n) - 1;
        var st = new Stack<int>();
        while (cur > 0) {
            st.Push(last);
            int temp = cur;
            cur -= (1 << last);
            last = path[temp,last];
        }
		
        // build the result
        int x = st.Pop();
        sb.Append(A[x]);
        while (st.Any()) {
            int j = st.Pop();
            sb.Append(A[j].Substring(A[j].Length - graph[x,j]));
            x = j;
        }
	// O(n^2 * 2^n)
        return sb.ToString();
    }
    private int calc(string a, string b) {
        for (int i = 1; i < a.Length; i++) {
            if (b.StartsWith(a.Substring(i))) {
                return b.Length - a.Length + i;
            }
        }
        return b.Length;
    }
}
