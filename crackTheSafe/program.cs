public class Solution {
    public string CrackSafe(int n, int k) {
        string res = "";
        int t = n;
        while (--t >= 0) res += "0";
        var visited = new HashSet<string>();
        visited.Add(res);
        // permutation
        for (int i = 0; i < Math.Pow(k,n); i++) {
            string pre = res.Substring(res.Length - (n - 1), n - 1);
            for (int j = k - 1; j >= 0; j--) {
                string cur = pre + j;
                if (!visited.Contains(cur)){
                    visited.Add(cur);
                    res += j;
                    break;
                }
            }
        }
        return res;
    }
}
