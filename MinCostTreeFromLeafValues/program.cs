public class Solution {
    public int MctFromLeafValues(int[] arr) {
        // 503. Next Greater Element II
        int res = 0;
        var st = new Stack<int>();
        st.Push(Int32.MaxValue); // border
        foreach (var right in arr) {
            while (st.Peek() <= right) {
                int mid = st.Pop();
                // st.Peek() is left
                res += mid * Math.Min(st.Peek(), right);
            }
            st.Push(right);
        }
        // for the last pair
        while (st.Count > 2) {
            res += st.Pop() * st.Peek();
        }
        return res;
    }
    public int MctFromLeafValues1(int[] arr) {
        int n = arr.Length;
        // max prod of i, j leaves
        var m = new int[n, n];
        // dp[i][j] := answer of build a tree from a[i] ~ a[j]
        var dp = new int[n, n];
        for (int i = 0; i < n; i++) {
            m[i,i] = arr[i];
            for (int j = i + 1; j < n; j++)
                m[i,j] = Math.Max(m[i,j-1], arr[j]);
        }
        for (int l = 2; l <= n; l++) {
            for (int i = 0; i + l <= n; i++) {
                int j = i + l - 1;
                dp[i,j] = Int32.MaxValue;
                for (int k = i ; k < j; k++)
                    dp[i,j] = Math.Min(dp[i,j], dp[i,k] + dp[k+1,j] + m[i,k]*m[k+1,j]);
            }
        }
        // time: O(n^3) space: O(n^2)
        return dp[0, n-1];
    }
}
