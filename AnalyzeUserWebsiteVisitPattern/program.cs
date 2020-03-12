public class Solution {
    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website) {
        var m = new Dictionary<string, SortedDictionary<int, string>>();
        int n = username.Length;
        var cnt = new Dictionary<string, int>();
        for (int i = 0; i < n; i++)  {
            if (!m.ContainsKey(username[i])) m.Add(username[i], new SortedDictionary<int,string>());
            m[username[i]][timestamp[i]] = website[i];
        }
        foreach (var kv in m) {
            var v = new List<string>();
            foreach (var w in kv.Value) v.Add(w.Value);
            // 3 seq combinations
            var seqs = new HashSet<string>();
            for (int i = 0; i < v.Count; i++)
                for (int j = 0; j < i; j++) 
                    for (int k = 0; k < j; k++)
                        seqs.Add(string.Join("#", new string[]{v[k], v[j], v[i]}));
            foreach (var s in seqs) {
                if (!cnt.ContainsKey(s)) cnt[s] = 0; 
                cnt[s]++;
            }
        }
        var res = new List<Tuple<string,int>>();
        foreach (var kv in cnt) res.Add(new Tuple<string,int>(kv.Key, kv.Value));
        res.Sort((x,y) => x.Item2 == y.Item2 ? y.Item1.CompareTo(x.Item1) : x.Item2 - y.Item2);
        return res.Last().Item1.Split("#").ToArray();
    }
}
