public class Solution {
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
        string res = "";
        for (int i = 0; i < S.Length;) {
            int p = Array.FindIndex(indexes, (x) => x == i) ;
            if (p >= 0 
                && S.Substring(i, sources[p].Length) == sources[p]) {
                res += targets[p];
                i += sources[p].Length;
            } else {
                res += S[i++];
            }
        }
        return res;
    }
}
