public class Solution {
    public string RemoveOuterParentheses(string S) {
        var s = new StringBuilder();
        //Primitive string will have equal number of opened and closed parenthesis.
        int opened = 0;
        foreach (char c in S.ToCharArray()) {
            if (c == '(' && opened++ > 0) s.Append(c);
            if (c == ')' && opened-- > 1) s.Append(c);
        }
        return s.ToString();
    }
}
