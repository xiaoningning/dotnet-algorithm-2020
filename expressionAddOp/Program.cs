public class Solution {
    public IList<string> AddOperators(string num, int target) {
        var res = new List<string>();
        if (string.IsNullOrEmpty(num)) return res;
        dfs(num, target, string.Empty, res, 0, 0); 
        // O(4^n)
        return res;
    }
    void dfs(string num, 
                   int target, 
                   string path, 
                   List<string> res, 
                   Int64 eval, 
                   Int64 diff){
        if(0 == num.Length && target == eval) {
            res.Add(path);
            return;
        }
        
        for(int len = 1; len <= num.Length; len++){
            string s = num.Substring(0, len);
            if(s.Length > 1 && s[0] == '0') return;                    
            Int64 cur = Int64.Parse(s);
            string next = num.Substring(len);
            if(string.IsNullOrEmpty(path)){
                dfs(next, target, path + s, res, eval+cur, cur);
            }
            else{
                dfs(next, target, path + "+" + cur, res, eval + cur, cur);
                dfs(next, target, path + "-" + cur, res, eval - cur, -cur);
                // 1+2 -> 1+2*3 => 1-2 + 2*3
                dfs(next, target, path + "*" + cur, res, eval - diff + diff * cur, diff * cur );
            }
        }
    }
}
