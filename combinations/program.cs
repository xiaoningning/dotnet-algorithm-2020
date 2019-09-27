public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
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
