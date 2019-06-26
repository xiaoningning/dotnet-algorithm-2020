public class Solution {
    public int LongestValidParentheses(string s) {
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
