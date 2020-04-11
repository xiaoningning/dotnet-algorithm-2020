public class Solution {
    public int EvalRPN(string[] tokens) {
        if (tokens.Length == 1) return Int32.Parse(tokens[0]);
        var st = new Stack<int>();
        for (int i = 0 ; i < tokens.Length; i++) {
            var c = tokens[i];
            if (c != "/" && c != "+" && c != "-" && c != "*") st.Push(Int32.Parse(c));
            else {
                var n1 = st.Pop();
                var n2 = st.Pop();
                if (c == "+") st.Push(n2 + n1);
                if (c == "-") st.Push(n2 - n1);
                if (c == "/") st.Push(n2 / n1);
                if (c == "*") st.Push(n2 * n1);
            }                                                      
        }
        return st.Peek();
    }
}
