public class Solution {
    // bit mask
    public IList<IList<int>> CombinationSum3(int k, int n) { 
        var res = new List<IList<int>>();
        // 2^9, generate all combinations states of [1 .. 9]
        // n state is 9
        for (int s = 0; s < (1 << 9); ++s) {
            var cur = new List<int>();
            int sum = 0;
            for (int j = 1; j <= 9; ++j) {
                // Use j if (j - 1)-th bit is 1
                if ((s & (1 << (j - 1))) > 0) {
                    sum += j;
                    cur.Add(j);
                }
            }
            if (sum == n && cur.Count == k) res.Add(cur);
        }
        return res; 
    }
    public IList<IList<int>> CombinationSum3_1(int k, int n) {
        var res = new List<IList<int>>();
        dfs(k, n, 1, new List<int>(), res);        
        return res; 
    }
    // dfs + backtracking
    void dfs(int k, int target, int start, List<int> temp, List<IList<int>> res){
        if (target < 0) return;
        else if (target == 0 && temp.Count == k) res.Add(new List<int>(temp));
        else {
            // 1 - 9
            for(int i = start; i <= 9; i++){
                temp.Add(i);                    
                dfs(k, target - i, i + 1, temp, res);
                temp.RemoveAt(temp.Count -1);
            }            
        }
    }
}
