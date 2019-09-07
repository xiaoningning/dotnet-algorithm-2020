public class Solution {
    public IList<string> SubdomainVisits(string[] cpdomains) {
        var res = new List<string>();
        var m = new Dictionary<string, int>();
        foreach (var cpdomain in cpdomains) {
            int idx = cpdomain.IndexOf(" ");
            int cnt = Convert.ToInt32(cpdomain.Substring(0, idx));
            string str = cpdomain.Substring(idx+1);
            for (int i = 0; i < str.Length; i++) {
                if (str[i] == '.') {
                    if (!m.ContainsKey(str.Substring(i+1))) m.Add(str.Substring(i+1),0);
                    m[str.Substring(i+1)] +=cnt;
                }
            }
            if (!m.ContainsKey(str)) m.Add(str,0);
            m[str] +=cnt;
        }
        foreach (var a in m) {
            res.Add(a.Value + " " + a.Key);
        }
        return res;
    }
}
