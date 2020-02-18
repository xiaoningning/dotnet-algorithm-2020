public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        var res = new List<string>();
        int l = 0, r = 0;
        foreach (var c in s) {
            l += c == '(' ? 1 : 0;
            if (l == 0) r += c == ')' ? 1 : 0;
            else l -= c == ')' ? 1 : 0;
        }
        dfs(s, 0, l, r, res);
        // O(2^(l+r))
        return res;
    }
    void dfs (string s, int start, int l, int r, List<string> res) {
        if (l == 0 && r == 0) {
            if (isValid(s)) res.Add(s);
            return;
        }
        for (int i = start; i < s.Length; i++) {
            // remove the 1st parenthes if there are consecutive ones to avoid duplications.
            if (i != start && s[i] == s[i -1]) continue;
            if (l > 0 && s[i] == '(') dfs(s.Substring(0,i) + s.Substring(i+1), i, l - 1, r, res);
            if (r > 0 && s[i] == ')') dfs(s.Substring(0,i) + s.Substring(i+1), i, l, r - 1, res);
        }
    }
    public IList<string> RemoveInvalidParentheses1(string s) {
        List<string> res = new List<string>();
        HashSet<string> visited = new HashSet<string>();
        Queue<string> q = new Queue<string>();
        q.Enqueue(s);
        bool found = false;
        
        while(q.Count > 0){
            string str = q.Dequeue();
            if (isValid(str)){
                res.Add(str);
                found = true;
            }

            if(found) continue;
            for(int i = 0; i < str.Length; i++){
                if (str[i] != ')' && str[i] != '(') continue;
                string t = str.Substring(0,i) + str.Substring(i+1);
                if(!visited.Contains(t)){
                    visited.Add(t);
                    q.Enqueue(t);
                }
            }
        }

        return res;
    }

    bool isValid(string t) {
        int cnt = 0;
        for (int i = 0; i < t.Length; ++i) {
            if (t[i] == '(') ++cnt;
            else if (t[i] == ')' && --cnt < 0) return false;
        }
        return cnt == 0;
    }
}
