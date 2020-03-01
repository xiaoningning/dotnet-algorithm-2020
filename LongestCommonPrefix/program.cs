public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs == null | strs.Length == 0) return "";
        Array.Sort(strs);
        int i = 0, len = Math.Min(strs[0].Length, strs[strs.Length - 1].Length);
        while ( i < strs[0].Length && strs[0][i] == strs[strs.Length -1][i]) i++;
        return strs[0].Substring(0, i);
    }
    public string LongestCommonPrefix1(string[] strs) {
        var res = "";
        if (strs == null | strs.Length == 0) return res;
        for (int j = 0; j < strs[0].Length; j++) {
            var c = strs[0][j];
            for (int i = 1; i < strs.Length; i++) {
                if (j >= strs[i].Length || strs[i][j] != c) return res;
            }
            res += c;
        }
        return res;
    }
}
