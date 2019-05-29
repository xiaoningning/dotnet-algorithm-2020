public class Solution {
    public bool IsAnagram(string s, string t) {
        int[] m = new int[26];
        for (int i = 0; i < s.Length; i++) m[s[i] - 'a']++;
        for (int i = 0; i < t.Length; i++) m[t[i] - 'a']--;
        foreach (int i in m) if (i != 0) return false;
        return true;
    }
}
