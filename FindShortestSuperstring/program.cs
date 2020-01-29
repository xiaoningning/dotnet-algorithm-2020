public class Solution {
    public string ShortestSuperstring(string[] A) {
        int n = A.Length;
        if (n == 1) return A[0];
        int[,] g = new int[n,n];
        // build the graph
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                g[i,j] = A[j].Length;
                for (int k = 1; k <= Math.Min(A[i].Length, A[j].Length); ++k)
                    if (A[i].Substring(A[i].Length - k) == A[j].Substring(0, k)) 
                        g[i,j] = A[j].Length - k;
            }
        }
        // dp[s, i] s: state mask, i: ith node of graph
        string[,] dp = new string[1 << n,n];
        string mnStr = "";
        int mn = Int32.MaxValue;
        for (int s = 1; s < (1 << n); ++s) {
            for (int j = 0; j < n; ++j) {
                // state mask does not contains j
                if ((s & (1 << j)) == 0) continue;
                // return A[j] if the mask only contains 1 word
                if (s == (1 << j)) { 
                    dp[s,j] = A[j];
                    continue;
                }
                // prev state mask does not contain j
                int prevs = s & ~(1 << j);
                int curLength = Int32.MaxValue;
                string curStr = "";
                for (int i = 0; i < n; ++i) {
                    if (i != j && (s & (1 << i)) > 0 && 
                        dp[prevs,i].Length + g[i,j] < curLength) {
                        curLength = dp[prevs,i].Length + g[i,j];
                        curStr = dp[prevs,i] + A[j].Substring(A[j].Length - g[i,j]);
                    }
                }
                dp[s,j] = curStr;
                // get the minimum among all results dp[(1<<n)-1, j]
                if (s == ((1<<n) - 1)) {
                    if (mn > dp[s,j].Length) {
                        mn = dp[s,j].Length;
                        mnStr = dp[s,j];
                    }
                }
            } 
        }
        // O(n^2 * 2^n)
        // 1<<n => 2^n
        // i,j combination n^2
        return mnStr;
    }
    
    public string ShortestSuperstring1(string[] A) {
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
		
        // Similar to Travelling salesmane problem DP
        // visit all nodes with smallest weight
        // Shortest Hamiltonian Path in weighted directed graph
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
    
    // the length of string to append when A[i] followed by A[j]. 
    // A[i] = abcd, A[j] = bcde, then graph[i][j] = 1
    private int calc(string a, string b) {
        for (int i = 1; i < a.Length; i++) {
            if (b.StartsWith(a.Substring(i))) {
                return b.Length - (a.Length - i);
            }
        }
        return b.Length;
    }
}
