public class Solution {
    public int ScoreOfParentheses1(string S) {
        var st = new Stack<int>();
        int cur = 0;
        foreach (var c in S.ToCharArray()) {
            if (c == '(') {
                st.Push(cur); 
                cur = 0;
            }
            // S is a balanced parentheses
            else cur = st.Pop() + Math.Max(1, cur * 2);
        }
        return cur;
    }
    public int ScoreOfParentheses(string S) {
        S = S.Replace(")(", ")+(").Replace("()", "1").Replace(")", ") * 2");
        return Eval(S);
    }
    int Eval(string expression)
    {
        System.Data.DataTable t = new System.Data.DataTable();
        return Convert.ToInt32(t.Compute(expression, string.Empty));
    }
}
