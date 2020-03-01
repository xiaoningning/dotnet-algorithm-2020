public class Solution {
    public IList<IList<int>> GetFactors(int n) {
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
