public class Solution {
    public bool ConfusingNumber(int N) {
        string num = N.ToString(), res = "";
        var m = new Dictionary<char, char>();
        m.Add('0','0');
        m.Add('1','1');
        m.Add('8','8');
        m.Add('6','9');
        m.Add('9','6');
        foreach (var c in num) {
            if (!m.ContainsKey(c)) return false;
            res = m[c] + res;
        }
        return res != num;
    }
}
