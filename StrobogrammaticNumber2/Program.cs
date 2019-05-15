public class Solution {
    public IList<string> FindStrobogrammatic(int n) {
        return Find(n,n);
    }
    string[] Find(int m, int n) {
        if (m == 0) return new string[]{""};
        if (m == 1) return new string[]{"0", "1", "8"};
        var t = Find(m-2,n);
        List<string> res = new List<string>();
        foreach (string s in t) {
            if (m != n) res.Add ("0" + s + "0");
            res.Add ("1" + s + "1");
            res.Add ("6" + s + "9");
            res.Add ("8" + s + "8");
            res.Add ("9" + s + "6");
        }
        return res.ToArray();
    }
}
