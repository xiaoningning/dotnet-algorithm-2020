public class Solution {
    public string CountOfAtoms(string formula) {
        string res = "";
        int pos = 0;
        var m = Parse(formula, ref pos);
        foreach (var a in m) {
            res += a.Key + (a.Value == 1 ? "" : a.Value.ToString());
        }
        return res;
    }
    SortedDictionary<string,int> Parse(string str, ref int pos) {
        var res = new SortedDictionary<string,int>();
        while (pos < str.Length) {
            if (str[pos] == '(') {
                ++pos;
                foreach (var a in Parse(str, ref pos)) {
                    if (!res.ContainsKey(a.Key)) res.Add(a.Key, 0);
                    res[a.Key] += a.Value;
                }
            } else if (str[pos] == ')') {
                int i = ++pos;
                while (pos < str.Length 
                       && Char.IsNumber(str[pos])) ++pos;
                int multiple = Int32.Parse(str.Substring(i, pos - i));
                var ks = res.Keys.ToList();
                foreach (var k in ks) {
                    res[k] *= multiple;
                }
                return res;
            } else {
                int i = pos++;
                while (pos < str.Length && Char.IsLower(str[pos])) ++pos;
                string elem = str.Substring(i, pos - i);
                i = pos;
                while (pos < str.Length 
                       && Char.IsNumber(str[pos])) ++pos;
                string cnt = str.Substring(i, pos - i);
                if (!res.ContainsKey(elem)) res.Add(elem, 0);
                res[elem] += cnt == "" ? 1 : Int32.Parse(cnt);
            }
        }
        return res;
    }
}
