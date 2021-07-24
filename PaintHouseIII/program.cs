public class Solution {
    // DFS
    int MAX = (int)1e8; // avoid overflow
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target) {
        // 0 color as unknown prevClr, => n+1
        var memo = new int[m,target+1,n+1];
        var res = DFS(houses, cost, memo, 0, 0, target);
        return res >= MAX ? -1 : res;
    }
    int DFS(int[] houses, int[][] cost, int[,,] memo, int houseIdx, int preClr, int target) {
        if (houseIdx == houses.Length || target < 0) return target == 0 ? 0 : MAX;
        // memo is calculated, just return
        if (memo[houseIdx,target,preClr] != 0) return memo[houseIdx,target,preClr];
        if (houses[houseIdx] != 0) {
            return memo[houseIdx,target,preClr] = DFS(houses,cost,memo, houseIdx+1, houses[houseIdx], target - ((houses[houseIdx] != preClr) ? 1 : 0));
        }
        
        var res = MAX;
        for (int c = 1; c <= cost[houseIdx].Length; c++) {
            var val = DFS(houses, cost, memo, houseIdx + 1, c, target - ((c != preClr) ? 1 : 0));
            res = Math.Min(res, val + cost[houseIdx][c-1]);
        }
        return memo[houseIdx,target,preClr] = res;
    }
    
    // buttom up
    public int MinCost2(int[] houses, int[][] cost, int m, int n, int target) {
        // i: house, k: neighbor, c: color,
        var dp = new int[m,target+1,n];
        for (int i = 0; i < m; i++) 
            for (int k = 0; k <= target; k++)
                for (int c = 0; c < n; c++) dp[i,k,c] = Int32.MaxValue;
        
        for (int c = 1; c <= n; c++) {
            if (houses[0] == 0) dp[0,1,c-1] = cost[0][c-1];
            else if (houses[0] == c) dp[0,1,c-1] = 0;
        }
        
        for (int i = 1; i < m; i++) {
            for (int k = 1; k <= target; k++) {
                for (int c = 1; c <= n; c++){
                    if (houses[i] != 0 && houses[i] != c) continue;
                    int same_neighbor = dp[i-1,k,c-1];
                    int new_neighbor = Int32.MaxValue;
                    for (int _c = 1; _c <= n; _c++) {
                        if (_c != c) new_neighbor = Math.Min(new_neighbor, dp[i-1,k-1,_c-1]);
                    }
                    var prevCost = Math.Min(same_neighbor, new_neighbor);
                    // avoid overflow since default is Int32.MaxValue already
                    // if set MAX as some 1e8, then no need to do this without overflow issue
                    var paintCost = (prevCost == Int32.MaxValue) ? 0 : cost[i][c-1] * (houses[i] == 0 ? 1 : 0);
                    dp[i,k,c-1] = prevCost + paintCost;
                    // Console.WriteLine("i:"+i+"k:"+k+"c:"+(c-1)+"=>"+dp[i,k,c-1]);
                }
            }
        }
        var res = Int32.MaxValue;
        for (int c = 1; c <= n; c++) res = Math.Min(res, dp[m-1,target,c - 1]);
        return res < Int32.MaxValue ? res : -1;
    }
    
    // TLE
    public int MinCost1(int[] houses, int[][] cost, int m, int n, int target) {
        var memo1 = new Dictionary<string, int>(){{"0-0", 0}};
        var memo2 = new Dictionary<string, int>();
        foreach (var (clr, idx) in houses.Select((color, index) => (color, index))) {
            var ncArray = clr == 0 ? Enumerable.Range(1, n) : new int[]{clr};
            foreach (int nc in ncArray) {
                foreach (var kv in memo1) {
                    int pc = Int32.Parse(kv.Key.Split('-')[0]);
                    int pn = Int32.Parse(kv.Key.Split('-')[1]);
                    int nn = pn + ((pc != nc) ? 1 : 0);
                    if (nn > target) continue;
                    int pcost = memo1[string.Format($"{pc}-{pn}")] + ((nc != clr) ? cost[idx][nc-1] : 0);
                    int ncost = memo2.ContainsKey(string.Format($"{nc}-{nn}")) ? memo2[string.Format($"{nc}-{nn}")] : Int32.MaxValue;
                    memo2[string.Format($"{nc}-{nn}")] = Math.Min(pcost, ncost);
                    Console.WriteLine("c: " + nc + " n: "+ nn + "=>" + memo2[string.Format($"{nc}-{nn}")]);
                }
            }
            memo1 = memo2;
            memo2 = new Dictionary<string, int>();
        }
        var res = Int32.MaxValue;
        foreach (var kv in memo1) {
            int nb = Int32.Parse(kv.Key.Split('-')[1]);
            if (nb == target) res = Math.Min(res, kv.Value);
        }
        return res != Int32.MaxValue ? res : -1;
    }
}
