public class Solution {
    public string RearrangeString(string s, int k) {
        if (k == 0) return s;
        int[] cnt = new int[26];
        string res = "";
        int len = s.Length;
        var q = new List<int[]>();
        foreach (var c in s) cnt[c-'a'] += 1; 
        for (int i = 0; i < 26; i++) {
            int t = cnt[i];
            if (t == 0) continue;
            //if (k != 0 && t  > (len + 1) / k) return res;
            q.Add(new int[]{t, i});
        }
        q = q.OrderByDescending(x => x[0]).ToList();
        while (q.Any()) {
            var v = new List<int[]>();
            int n = Math.Min(k, len);
            for (int i = 0; i < n; ++i) {
                if (!q.Any()) return "";
                var t = q.First(); q.RemoveAt(0);
                res += (char)(t[1] + 'a');
                if (--t[0] > 0) v.Add(t);
                --len;
            }
            q.AddRange(v);
            q = q.OrderByDescending(x => x[0]).ToList();
        }
        return res;
    }
}
