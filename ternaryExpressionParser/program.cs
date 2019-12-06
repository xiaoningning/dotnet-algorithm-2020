public class Solution {
    public string ParseTernary(string expression) {
        string res = expression;
        while (res.Length > 1) {
            int i = res.LastIndexOf("?");
            // digits 1~9
            res = res.Substring(0, i - 1) + (res[i - 1] == 'T' ? res[i + 1] : res[i + 3]) + res.Substring(i + 4);
        }
        return res;
    }
}
