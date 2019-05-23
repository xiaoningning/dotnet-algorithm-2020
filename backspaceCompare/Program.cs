public class Solution {
    public bool BackspaceCompare(string S, string T) {
        int i = S.Length - 1, j = T.Length - 1, cnt1 = 0, cnt2 = 0;
        while (i >= 0 || j >= 0) {
            while (i >= 0 && (S[i] == '#' || cnt1 > 0)) cnt1 += S[i--] == '#' ? 1 : -1;;
            while (j >= 0 && (T[j] == '#' || cnt2 > 0)) cnt2 += T[j--] == '#' ? 1 : -1;;
            if (i < 0 || j < 0) return i == j;
            if (S[i--] != T[j--]) return false;
        }
        // time: O(n), space: O(1)
        return i == j;
    }
    
    public bool BackspaceCompare1(string S, string T) {
        var q = new Stack<char>();
        var t = new Stack<char>();
        foreach(char c in S) {
            if (c == '#' && q.Count > 0) q.Pop();
            else if (c !='#') q.Push(c);
        }
        
        foreach(char c in T) {
            if (c == '#' && t.Count > 0) t.Pop();
            else if (c !='#') t.Push(c);
        }
        return new string(q.ToArray()) == new string(t.ToArray());
    }
}
