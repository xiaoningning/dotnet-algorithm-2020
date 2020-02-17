public class Solution {
    public IList<IList<string>> Partition1(string s) {
        List<IList<string>> res = new List<IList<string>>();
        dfs(s, 0, new List<string>(), res);    
        // O(2^n)
        return res;        
    }
    void dfs(string s, int start, List<string> temp, List<IList<string>> res){
        if (start == s.Length) res.Add(new List<string>(temp));
        else {
            for(int i = start; i < s.Length; i++){
                if(IsPalindrome(s, start, i)){
                    temp.Add(s.Substring(start, i - start + 1));
                    dfs(s, i + 1, temp, res);
                    temp.RemoveAt(temp.Count -1);
                }                    
            }            
        }
    }
    public bool IsPalindrome(string s, int low, int high){
        while(low < high)
            if(s[low++] != s[high--]) return false;
        return true;
    } 
    // output is not right
    public IList<IList<string>> Partition(string s){
        int n = s.Length;
        var dp = new List<IList<string>>[n+1]; // res of str[0:i]
        for(int i = 0; i <= n; i++) dp[i]= new List<IList<string>>();
        for (int len = 1; len <= n; len++) {
            for (int i = 0; i < len; ++i) {
                string right = s.Substring(i, len - i);
                if (!IsPalindrome(right, 0, right.Length - 1)) continue;
                if (i == 0) dp[len].Add(new List<string>(){right});
                foreach (var p in dp[i]) {
                    var t = p.ToList();// copy of new obj
                    t.Add(right);
                    dp[len].Add(t);
                }
            }
        }
        // O(2^n)
        return dp[n];
    }
}
