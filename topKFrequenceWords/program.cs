public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        var res = new List<string>();
        var freq = new Dictionary<string, int>();
        for (int i = 0; i < words.Length; i++) {
            if (!freq.ContainsKey(words[i])) freq.Add(words[i],0);
            freq[words[i]]++;
        }
        var q = new SortedDictionary<int,List<string>>();
        foreach (var f in freq) {
            if (!q.ContainsKey(f.Value)) q.Add(f.Value, new List<string>());
            q[f.Value].Add(f.Key);
        }
        for (int i = q.Keys.Count - 1; i >= 0; i--)  {
            if (k <= 0) break;
            var r = q[q.Keys.ToList()[i]];
            r.Sort();
            if (k >= r.Count) 
                res.AddRange(r);
            else {
                for (int j = 0; j < k; j++) res.Add(r[j]);
            }
            k -= r.Count;
        }
        return res;
    }
}
