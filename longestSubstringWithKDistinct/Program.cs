public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        Dictionary<char, int> m = new Dictionary<char, int>();
        int res = 0, left = 0;
        for (int i = 0; i < s.Length; i++) {
            if (!m.ContainsKey(s[i])) m.Add(s[i],0);
            m[s[i]]++;
            while (m.Count() > k) {
                if (--m[s[left]] == 0) m.Remove(s[left]);
                ++left;
            }
            res = Math.Max(res, i - left + 1);
        }
        return res;
    }
}
