public class Solution {
    public string CustomSortString(string S, string T) {
        var m = new int[26];
        foreach (char c in T) m[c - 'a']++;
        string res ="";
        foreach (char c in S) {
            while (m[c - 'a']-- > 0) res += c;
        }
        for (char i = 'a'; i <= 'z'; i++) {
            while (m[i - 'a']-- > 0) res += i;
        }
        return res;
    }
}
