public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var res = new List<IList<string>>();
        var map = new Dictionary<string, List<string>>();
        foreach (string str in strs){
            int[] cnt = new int[26];
            string t = string.Empty;
            foreach (char c in str) cnt[c - 'a']++;
            foreach (int i in cnt) t += (char) i + "/"; 
            if (!map.ContainsKey(t)) map[t] = new List<string>();
            map[t].Add(str);
        }
        foreach(var pv in map){
            res.Add(pv.Value);
        }
        return res; 
    }
}
