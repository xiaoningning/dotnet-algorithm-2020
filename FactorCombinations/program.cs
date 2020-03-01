public class Solution {
    public IList<IList<int>> GetFactors(int n) {
        var res = new List<IList<int>>();
        helper(n, 2, new List<int>(), res);
        return res;
    }
    void helper(int n, int s, List<int> t, List<IList<int>> res){
        if (n == 1) { 
            if (t.Count > 1) res.Add(new List<int>(t));
        }
        else {
            for (int i = s; i <= n; i++) {
                if (n % i == 0) {
                    t.Add(i);
                    helper(n / i, i, t, res);
                    t.RemoveAt(t.Count - 1);
                }
            }
        }
    }
    public IList<IList<int>> GetFactors1(int n) {
        var res = new List<IList<int>>();
        for (int i = 2; i * i <= n; i++) {
            if (n % i == 0) {
                var t = GetFactors(n / i);
                res.Add(new List<int>(){i, n / i});
                foreach (var a in t) {
                    // a[0] > i, it's been processed already
                    if (i <= a[0]) {
                        a.Insert(0, i);
                        res.Add(a);
                    }
                }
            }
        }
        return res;
    }
}
