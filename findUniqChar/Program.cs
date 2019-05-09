public class Solution {
    public int FirstUniqChar(string s) {
        Dictionary<char, int> m = new Dictionary<char, int>();
        foreach (char c in s) {
            if(!m.ContainsKey(c)) m.Add(c,0);
            m[c]++;
        };
        for (int i = 0; i < s.Length; ++i) {
            if (m[s[i]] == 1) return i;
        }
        return -1;
    }
}
