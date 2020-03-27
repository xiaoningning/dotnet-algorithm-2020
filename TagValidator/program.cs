public class Solution {
    public bool IsValid(string code) {
        var st = new Stack<string>();
        for (int i = 0; i < code.Length; ++i) {
            Console.WriteLine(i);
            if (i > 0 && !st.Any()) return false; // should start with a tag
            if (i + 9 < code.Length && code.Substring(i, 9) == "<![CDATA[") {
                int j = i + 9;
                i = code.IndexOf("]]>", j);
                if (i < 0) return false;
                i += 2;
            }
            else if (code.Substring(i,2) == "</") { // check </ first, then <
                int j = i + 2;
                i = code.IndexOf(">", j);
                if (i < 0) return false;
                if (!st.Any() || st.Peek() != code.Substring(j, i - j)) return false;
                st.Pop();
            }
            else if (code.Substring(i,1) == "<") {
                int j = i + 1;
                i = code.IndexOf('>', j);
                if (i < 0 || i == j || i - j > 9) return false;
                for (int k = j; k < i; ++k) {
                    if (code[k] < 'A' || code[k] > 'Z') return false;
                }
                st.Push(code.Substring(j, i - j));
            }
        }
        return !st.Any();
    }
}
