public class Solution {
    public bool IsIsomorphic(string s, string t) {
        int[] m1 = new int[256], m2 = new int[256];
        int n = s.Length;
        for (int i = 0; i < n; ++i) {
            // char and position must be 1:1 map
            if (m1[s[i]] != m2[t[i]]) return false;
            m1[s[i]] = i + 1;
            m2[t[i]] = i + 1;
        }
        return true;
    }
}
