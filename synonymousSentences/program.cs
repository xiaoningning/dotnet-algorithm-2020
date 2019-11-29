public class Solution {
    List<string> res = new List<string>();
    Dictionary<string, HashSet<string>> merged = new Dictionary<string, HashSet<string>>();
    public IList<string> GenerateSentences(IList<IList<string>> synonyms, string text) {
        var uf = new UnionFind();
        foreach (var p in synonyms) {
            uf.union(p[0], p[1]);
        }
        foreach (var r in uf.roots) {
            if (!merged.ContainsKey(r.Value)) merged.Add(r.Value, new HashSet<string>());
            merged[r.Value].Add(r.Key);
        }
        helper(text.Split(" "), 0, "");
        res.Sort();
        return res;
    }
    public void helper(string[] words, int i, string cur){
        if(i == words.Length){
            res.Add(cur);
            return;
        }
        
        bool found = false;
        foreach (var s in merged.Values.ToList()){
            if(s.Contains(words[i])){
                foreach(string str in s){
                    helper(words, i + 1, cur + (i == 0 ? "" : " ") + str);
                }
                found = true;
                break;
            }
        }

        if(!found)
            helper(words, i + 1, cur + (i == 0 ? "" : " ") + words[i]);
    }
}
public class UnionFind {
    public Dictionary<string, string> roots = new Dictionary<string, string>();
    public UnionFind() {
    }
    string find(string t1) {
        if (!roots.ContainsKey(t1)) roots.Add(t1, t1);
        while (t1 != roots[t1]) {
            // path compression
            // roots[i] = roots[roots[i]];
            t1 = roots[t1];
        }
        return t1;
    }
    public void union(string t1, string t2) {
        t1 = find(t1);
        t2 = find(t2);
        if (!t1.Equals(t2)) {
            roots[t2] = t1;
        }
    }
}

