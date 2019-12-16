public class Solution {
    public IList<IList<string>> FindDuplicate(string[] paths) {
        var res = new List<IList<string>>();
        var m = new Dictionary<string, HashSet<string>>();
        foreach (string path in paths) {
            string[] strs = path.Split(" ");
            for (int i = 1; i < strs.Length; i++) {
                int idx = strs[i].IndexOf("(");
                string content = strs[i].Substring(idx);
                // dir + filename
                string fn = strs[0] + "/" + strs[i].Substring(0, idx);
                var filenames = m.GetValueOrDefault(content, new HashSet<string>());
                filenames.Add(fn);
                m[content] = filenames;
            }
        }
        foreach (string key in m.Keys) {
            if (m[key].Count > 1) res.Add(new List<string>(m[key]));
        }
        return res;
    }
}
