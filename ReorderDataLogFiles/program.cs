public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        var digit = new List<string>();
        var letter = new List<string>();
        foreach (var l in logs) {
            if (Char.IsNumber(l.Split(" ")[1][0])) digit.Add(l);
            if (Char.IsLetter(l.Split(" ")[1][0])) letter.Add(l);
        }
        // letter.Sort((a,b) => (a.Split(" ")[1] == b.Split(" ")[1]) ? string.Compare(a.Split(" ")[0], b.Split(" ")[0]) : string.Compare(a.Split(" ")[1], b.Split(" ")[1]));   
        letter.Sort((a,b) => {
            int la = a.Split(" ")[0].Length;
            int lb = b.Split(" ")[0].Length;
            int cmp = string.Compare(a.Substring(la+1), b.Substring(lb+1));
            return cmp != 0 ? cmp
                : string.Compare(a.Split(" ")[0], b.Split(" ")[0]);
        });
        letter.AddRange(digit);
        return letter.ToArray();
    }
}
