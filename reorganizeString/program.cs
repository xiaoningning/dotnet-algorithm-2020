public class Solution {
    public string ReorganizeString(string S) {
        int[] cnt = new int[26];
        string res = "";
        var q = new List<int[]>();
        foreach (var c in S) cnt[c-'a'] += 1; 
        for (int i = 0; i < 26; i++) {
            int t = cnt[i];
            if (t == 0) continue;
            if (t  > (S.Length + 1) / 2) return res;
            q.Add(new int[]{t, i});
        }
        q = q.OrderByDescending(x => x[0]).ToList();
        while (q.Count >= 2) {
            var t1 = q.First(); q.RemoveAt(0);
            var t2 = q.First(); q.RemoveAt(0);
            res += (char)(t1[1] + 'a');
            res += (char)(t2[1] + 'a');
            if (--t1[0] > 0) q.Add(t1);
            if (--t2[0] > 0) q.Add(t2);
            q = q.OrderByDescending(x => x[0]).ToList();
        }
        
        if (q.Count > 0) res += (char)(q.First()[1] + 'a');
        return res;
        
    }
    
    public string ReorganizeString1(string S) {
        int[] cnt = new int[26];
        int idx = 1;
        foreach (var c in S) cnt[c-'a'] += 100; // val = cnt * 100
        for (int i = 0; i < 26; i++) cnt[i] += i; // val = cnt * 100 + char
        Array.Sort(cnt);
        var res = new char[S.Length];
        foreach (var cn in cnt) {
            int t = cn / 100;
            char c = Convert.ToChar('a' + cn % 100);
            // cnt more than half, then impossible
            if (t > (S.Length + 1) / 2 ) return "";
            // smallest cnt char put on 2nd
            // b/c largest cnt char is always on 1st
            for (int i = 0; i < t; ++i) {
                // reset idx for largest cnt char
                if (idx >= S.Length) idx = 0;
                res[idx] = c;
                idx += 2;
            }
        }
        return new string(res);
    }
}
