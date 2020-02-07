public class Solution {
    public int LargestComponentSize(int[] A) {
        int n = A.Max();
        var uf = new UF(n+1);
        foreach (var a in A) {
            int t = (int)Math.Sqrt(a);
            for (int k = 2; k <= t; k++) {
                if (a % k == 0) {
                    uf.Union(a, k);
                    uf.Union(a, a / k);
                }
            }
        }
        var m = new Dictionary<int,int>();
        int res = 1; // with itself, min = 1;
        foreach (var a in A) {
            int x = uf.FindRoot(a);
            if (!m.ContainsKey(x)) m.Add(x, 0); 
            res = Math.Max(res, ++m[x]);
        }
        return res;
    }
    public class UF {
        int[] _roots;
        public UF(int n) {
            _roots = new int[n];
            for (int i = 0; i < n; i++) _roots[i] = i;
        }
        public void Union(int x, int y) {
            _roots[FindRoot(x)] = _roots[FindRoot(y)];
        }
        public int FindRoot(int x) {
            return x == _roots[x] ? x : FindRoot(_roots[x]);
        }
    }
}
