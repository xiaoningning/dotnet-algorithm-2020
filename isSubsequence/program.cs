public class Solution {
    public bool IsSubsequence(string s, string t) {
        if (s.Length == 0) return true;
        int i = 0, j = 0;
        while (i < t.Length) {
            if (t[i] == s[j]) {
                j++;
                if (j == s.Length) return true;
            }
            i++;
        }
        return false;
    }
}
