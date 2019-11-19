public class Solution {
    public bool CanConvert(string str1, string str2) {
        if (str1.Length != str2.Length) return false;
        if (str1 == str2) return true;
        var m = new Dictionary<char, char>();
        for(int i = 0; i < str1.Length; i++) {
            if (!m.ContainsKey(str1[i])) m.Add(str1[i], str2[i]);
            if (m[str1[i]] != str2[i]) return false;
        }
        // transformation of cycle, like a -> b -> c -> a
        // str2 need extra char
        return new HashSet<char>(m.Values).Count < 26;
    }
}
