public class Solution {
    public string ReverseParentheses1(string s) {
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
        // O(n)
        return res;
    }
    public string ReverseParentheses(string s) {
        var st = new Stack<string>();
        st.Push("");
        foreach (var c in s) {
            if (c == '(') st.Push("");
            else if (c != ')') {
                var t = st.Pop();
                t += c;
                st.Push(t);
            }
            else {
                var t1 = st.Pop();
                t1 = new string(t1.ToCharArray().Reverse().ToArray());
                var t2 = st.Pop();
                t2 += t1;
                st.Push(t2);
            }            
        }
        // O(n^2)
        return st.Peek();
    }
}
