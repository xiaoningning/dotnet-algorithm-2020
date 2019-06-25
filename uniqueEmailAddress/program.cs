public class Solution {
    public int NumUniqueEmails(string[] emails) {
        var res = new HashSet<string>();
        foreach (var e in emails) {
            var parts = e.Split('@');
            var name = parts[0].Split('+');
            res.Add(name[0].Replace(".","") + "@" + parts[1]);
        }
        return res.Count;
    }
}
