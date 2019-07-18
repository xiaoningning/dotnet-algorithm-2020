public class Solution {
    public string CrackSafe(int n, int k) {
        // n =2, k = 3
        // hashset: 00,02,22,21,12,20,01,11,10
        // res: 0022120110
        string res = "";
        int t = n;
        while (--t >= 0) res += "0";
        var visited = new HashSet<string>();
        visited.Add(res);
        for (int i = 0; i < Math.Pow(k,n); i++) {
            // last n-1 digits of string
            string pre = res.Substring(res.Length - (n - 1), n - 1);
            // permutation
            for (int j = k - 1; j >= 0; j--) {
                // cur is n digits of pwd
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
