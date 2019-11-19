public class Solution {
    public string ReverseParentheses(string s) {
        int n = s.Length;
        int[] pair = new int[n];
        var st = new Stack<int>();
        for (int i = 0; i < n; i++) {
            if (s[i] == '(') st.Push(i);
            if (s[i] == ')') {
                int j = st.Pop();
                pair[i] = j; pair[j] = i;
            }
        }
        string res = "";
        for (int i = 0, d = 1; i < n; i += d) {
            if (s[i] == '(' || s[i] == ')') {
                // reverse direction
                d = -d; i = pair[i];
            }
            else {
                res += s[i];
            }
        }
        return res;
    }
}
