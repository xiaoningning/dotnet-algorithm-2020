public class Solution {
    public string RemoveOuterParentheses(string S) {
        var s = new StringBuilder();
        //Primitive string will have equal number of opened and closed parenthesis.
        int opened = 0;
        foreach (char c in S.ToCharArray()) {
            /*
            opened count the number of opened parenthesis.
            Add every char to the result,
            unless the first left parenthesis,
            and the last right parenthesis.
            */
            if (c == '(' && opened++ > 0) s.Append(c);
            if (c == ')' && opened-- > 1) s.Append(c);
        }
        return s.ToString();
    }
}
