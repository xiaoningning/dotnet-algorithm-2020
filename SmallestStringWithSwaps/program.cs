public class Solution {
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        int n = s.Length;
        int[] roots = new int[n];
        for (int i = 0; i < n; i++) roots[i] = i;
        foreach(var p in pairs) {
            roots[FindRoot(roots, p[0])] = FindRoot(roots, p[1]);
        }
        var idx = new Dictionary<int,List<int>>();
        for (int i = 0; i < n; i++) {
            int id = FindRoot(roots, i);
            if (!idx.ContainsKey(id)) idx.Add(id, new List<int>());
            idx[id].Add(i);
        }
        var sArr = s.ToCharArray();
        foreach (var ids in idx) {
            string ss = "";
            foreach (var id in ids.Value) ss += sArr[id];
            ss = new string(ss.OrderBy(c => c).ToArray());            
            for (int j = 0; j < ids.Value.Count; j++) 
                sArr[ids.Value[j]] = ss[j];
        }      
        // O(nlogn + V+E)
        return new string(sArr);
    }
    int FindRoot(int[] roots, int x) {
        return x == roots[x] ? x : FindRoot(roots, roots[x]);
    }
}
