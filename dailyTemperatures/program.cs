public class Solution {
    public int[] DailyTemperatures(int[] T) {
        int n = T.Length;
        int[] res = new int[n];
        var st = new Stack<int>();
        for (int i = 0; i < n; ++i) {
            while (st.Count != 0 && T[st.Peek()] < T[i]) {
                int t = st.Pop();
                res[t] = i - t;   
            }
            st.Push(i);
        }
        return res;
    }
}
