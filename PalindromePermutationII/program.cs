public class Solution {
    public IList<string> GeneratePalindromes(string s) {
        var res = new HashSet<string>();
        var m = new int[256];
        foreach (var c in s) m[c]++;
        string t = "", mid = "";
        for (int i = 0; i < 256; i++) {
            if (m[i] == 0) continue;
            if (m[i] % 2 == 1) mid += (char)(i);
            m[i] /= 2;
            while (m[i]-- > 0) t += (char)(i);
            if (mid.Length > 1) return res.ToList();
        }
        permute(t.ToCharArray(), 0, mid, res);
        return res.ToList();
    }
    void permute(char[] t, int start, string mid, HashSet<string> res) {
        if (start >= t.Length) {
            var ta = new char[t.Length];
            Array.Copy(t, ta, t.Length);
            Array.Reverse(ta);
            res.Add(new string(t) + mid + new string(ta));
            return;
        }
        for (int i = start; i < t.Length; i++) {
            if (i != start && t[i] == t[start]) continue;
            swap(t, i, start);
            permute(t, start + 1, mid, res);
            swap(t, i, start);
        }
    }
    void swap(char[] ta, int x, int y){
        var t = ta[x]; ta[x] = ta[y]; ta[y] = t;
    }
}
