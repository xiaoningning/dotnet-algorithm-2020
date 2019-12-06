public class Solution {
    public IList<string> WordsAbbreviation(IList<string> dict) {
        int n = dict.Count;
        var res = new string[n];
        var pre = new int[n]; Array.Fill(pre, 1);
        for (int i = 0; i < n; ++i) {
            res[i] = abbreviate(dict[i], pre[i]);
        }
        for (int i = 0; i < n; ++i) {
            while (true) {
                var st = new HashSet<int>();
                for (int j = i + 1; j < n; ++j) {
                    if (res[j] == res[i]) st.Add(j);
                }
                if (!st.Any()) break;
                st.Add(i);
                // conflict, increase prefix length
                foreach (var a in st) {
                    res[a] = abbreviate(dict[a], ++pre[a]);
                }
            }
        }
        return res;
    }
    string abbreviate(string s, int k) {
        //prefix doesn't make the word shorter, then keep the string
        return (k >= s.Length - 2) ? s : s.Substring(0, k) + (s.Length - k - 1) + s.Last();
    }
}
