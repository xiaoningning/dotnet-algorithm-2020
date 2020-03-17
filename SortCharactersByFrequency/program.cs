public class Solution {
    public string FrequencySort(string s) {
        var m = new Dictionary<char,int>();
        foreach (var c in s) {
            if (!m.ContainsKey(c)) m.Add(c, 0);
            m[c]++;
        }
        var arr = s.ToCharArray();
        Array.Sort(arr, (a,b) => m[a] == m[b] ? a - b: m[b] - m[a]);
        return new string(arr);
    }
}
