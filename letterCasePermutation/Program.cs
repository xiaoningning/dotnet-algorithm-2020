public class Solution {
    // BFS
    public IList<string> LetterCasePermutation1(string S) {
        var res = new List<string>();
        if (S == null) return res;
        res.Add(S);
        int n = S.Length;
        for (int i = 0; i < n; i++){
            if (S[i] >= '0' && S[i] <= '9') continue;
            var temp = new List<string>();
            foreach(string s in res){
                char[] c = s.ToCharArray();
                c[i] = char.ToLower(c[i]);
                temp.Add(new string(c));
                c[i] = char.ToUpper(c[i]);
                temp.Add(new string(c));
            }
            res = temp;
        }
        return res;
    }
    // DFS
    public IList<string> LetterCasePermutation(string S) {
        List<string> res = new List<string>();
        if (S == null) return res;
        dfs(S.ToArray(), res, 0);
        // O(n*2^l), l = # of letters in the string
        return res;
    }
    void dfs(char[] s, List<string> res, int p) {
        if (p == s.Length) {
            res.Add(new string(s));
            return;
        }
        if (s[p] >= '0' && s[p] <= '9') {
            dfs(s, res, p + 1);
            return;
        }
        s[p] = char.ToLower(s[p]);
        dfs(s, res, p + 1);
        s[p] = char.ToUpper(s[p]);
        dfs(s, res, p + 1);
    }
}
