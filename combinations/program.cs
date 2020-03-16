public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        if (k > n || k < 0) return new List<IList<int>>();
        if (k == 0) return new List<IList<int>>(){new List<int>()};
        // C(n, k) = C(n-1, k-1) + C(n-1, k)
        var res = Combine(n-1, k -1);
        foreach (var a in res) a.Add(n);
        foreach (var a in Combine(n-1, k)) res.Add(a);
        return res;
    }
    public IList<IList<int>> Combine1(int n, int k) {
        var res = new List<IList<int>>();
        backtrack(res, new List<int>(), 1, n, k);
        return res;
    }
    void backtrack(List<IList<int>> res, List<int> tmp, int start, int n, int k) {
        if (k == 0) res.Add(new List<int>(tmp));
        for (int i = start; i <= n; i++) {
            tmp.Add(i);
            backtrack(res, tmp, i+1, n, k -1);
            tmp.RemoveAt(tmp.Count -1);
        }
    }
}
