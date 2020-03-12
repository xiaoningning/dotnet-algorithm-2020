public class Solution {
    public string MostCommonWord(string paragraph, string[] banned) {
        var st = new HashSet<string>(banned);
        var cnt = new Dictionary<string, int>();
        string pattern = "!?',;. ", res = "", word = "";
        int mx = 0, n = paragraph.Length;
        for (int i = 0; i <= n; i++) {
            // i == n => check last word
            if (i == n || pattern.IndexOf(paragraph[i]) >= 0) {
                if (!cnt.ContainsKey(word)) cnt.Add(word,0);
                if (++cnt[word] > mx && !st.Contains(word) && word != "") {
                    mx = cnt[word];
                    res = word;
                }
                word = "";
            }
            else word += Char.ToLower(paragraph[i]);
        }
        return res;
    }
}
