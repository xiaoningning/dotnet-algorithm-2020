public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var res = new List<int>();
        if (s == null
           || s.Length == 0
           || p == null
           || p.Length == 0) return res;
        
        int[] m = new int[256];
        foreach (var c in p.ToCharArray()) m[c]++;
        int left = 0, i = 0, cnt = 0;
        while (i < s.Length) {
            if (m[s[i++]]-- > 0) cnt++;
            if (cnt == p.Length) res.Add(left);
            if (i - left == p.Length && m[s[left++]]++ >= 0) cnt--;
        }
        return res;
    }
}
