public class Solution {
    public int NumSquarefulPerms(int[] A) { 
        // avoid duplicates in A
        Array.Sort(A);
        var used = new bool[A.Length];
        Permutation(A, new List<int>(), used);
        return res;
    }
    void Permutation(int[] A, List<int> tmp, bool[] used) {
        if (tmp.Count == A.Length) { 
            res++;
            return;
        }
        for (int i = 0; i < A.Length; i ++) {
            // like permutation II
            if (used[i] || (i > 0 && A[i] == A[i - 1] && !used[i - 1])) continue;
            if (tmp.Count == 0 || IsSquareful(A[i], tmp.Last())) {
                used[i] = true;
                tmp.Add(A[i]);
                Permutation(A, tmp, used);
                tmp.RemoveAt(tmp.Count - 1);
                used[i] = false;
            }
        }
    }
    bool IsSquareful(int x, int y) {
        var s = (int) Math.Sqrt(x + y);
        return s * s == x + y;
    }
    Dictionary<int, int> count = new Dictionary<int, int>();
    Dictionary<int, HashSet<int>> cand = new Dictionary<int, HashSet<int>>();
    int res = 0;
    public int NumSquarefulPerms1(int[] A) {
        foreach (int a in A) count[a] = count.GetValueOrDefault(a,0) + 1;
        foreach (var i in count) {
            foreach (var j in count) {
                int x = i.Key, y = j.Key, s = (int) Math.Sqrt(x + y);
                if (!cand.ContainsKey(x)) cand.Add(x, new HashSet<int>());
                // sqrt is double => check here as int
                if (s * s == x + y) cand[x].Add(y);
            }
        }
        // combination of candidates
        var ks = count.Keys.ToList();
        foreach (var k in ks) dfs(k, A.Length - 1);
        return res;
    }
    // back track
    void dfs(int x, int left) {
        count[x]--;
        if (left == 0) res++;
        foreach (int y in cand[x])
            if (count[y] > 0) dfs(y, left - 1);
        count[x]++;
    }
}
