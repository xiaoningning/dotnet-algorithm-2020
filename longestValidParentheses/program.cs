public class Solution {
    public int LongestValidParentheses(string s) {
        int res = 0, n = s.Length;
        var dp = new int[n+1];
        for (int i = 1; i <= n; i++) {
            // i - 1 - length of parantheses then -1 for the index of s
            int j = (i - 1) - dp[i - 1] - 1;
            if (s[i-1] == '(' || j < 0 || s[j] == ')') 
                dp[i] = 0;
            else { // s[i-1] = ')', j >= 0, s[j] = '('
                dp[i] = dp[i-1] + 2 + dp[j];
                res = Math.Max(res, dp[i]);
            }
        }
        return res;
    }
    public int LongestValidParentheses1(string s) {
        int res = 0, start = 0;
        var st = new Stack<int>();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') st.Push(i);
            else {
                if (st.Count == 0) start = i + 1;
                else {
                    st.Pop();
                    res = st.Count == 0 ? 
                        Math.Max(res, i - start + 1)
                        : Math.Max(res, i - st.Peek());
                }
            }
        }
        return res;
    }
}
