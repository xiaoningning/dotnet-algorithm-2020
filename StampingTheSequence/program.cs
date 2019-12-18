public class Solution {
    List<int> res;
    public int[] MovesToStamp(string stamp, string target) {
        res = new List<int>();
        var s = stamp.ToCharArray();
        var t = target.ToCharArray();
        var next = true;
        while (next) {
            next = false;
            for (int i = 0; i <= t.Length - s.Length; i++)
                next |= Check(i, s, t);
        }
        res.Reverse();
        var done = true;
        foreach (var c in t) done &= c == '?';
        return done ? res.ToArray() : new int[]{};
    }
    bool Check (int i, char[] s, char[] t) {
        int m = s.Length;
        bool replace = false;
        for (int j = 0; j < m; j++) {
            if (t[i+j] == '?') continue;
            if (t[i+j] != s[j]) return false;
            else  replace = true;
        }
        if (replace) {
            Array.Fill(t, '?', i, m);
            res.Add(i);
        }
        return replace;
    }
}
