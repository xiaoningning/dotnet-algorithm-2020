public class Solution {
    public string RemoveKdigits(string num, int k) {
        var res = "";
        foreach (var c in num) {
            while (k > 0 && res.Length > 0 && res.Last() > c) {
                res = res.Remove(res.Length - 1, 1); 
                k--;
            }
            if (res.Any() || c != '0') res += c;
        }
        while (res.Any() && k-- > 0) res = res.Remove(res.Length - 1, 1);
        // while (res.Any() && res.First() == '0') res = res.Remove(0,1);
        return res.Length == 0 ? "0" : res;
    }
}
