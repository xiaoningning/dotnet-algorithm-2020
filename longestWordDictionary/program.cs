public class Solution {
    public string LongestWord(string[] words) {
        Array.Sort(words);
        string res = "";
        var s = new HashSet<string>();
        foreach (var w in words) {
            if (w.Length == 1 || s.Contains(w.Substring(0, w.Length -1))) {
                s.Add(w);
                res = w.Length > res.Length ? w : res;
            }
        }
        return res;
    }
}
