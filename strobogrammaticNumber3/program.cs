public class Solution {
    public int StrobogrammaticInRange(string low, string high) {
        long h = Int64.Parse(high), l = Int64.Parse(low);
        var res = new List<string>();
        for(int n = low.Length; n <= high.Length; n++){
			res.AddRange(Find(n, n));
		}
        int cnt = 0;
        foreach (var r in res) {
            long t = Int64.Parse(r);
            if (t >= l && t <= h) cnt++;
        }
        return cnt;
    }
    List<string> Find(int m, int n) {
        if (m == 0) return new List<string>(){""};
        if (m == 1) return new List<string>(){"0", "1", "8"};
        var t = Find(m-2,n);
        List<string> res = new List<string>();
        foreach (string s in t) {
            if (m != n) 
                res.Add ("0" + s + "0");
            res.Add ("1" + s + "1");
            res.Add ("6" + s + "9");
            res.Add ("8" + s + "8");
            res.Add ("9" + s + "6");
        }
        return res;
    }
}
