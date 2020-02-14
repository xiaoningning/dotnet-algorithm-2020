public class Solution {
    public int MinCostII(int[][] costs) {
        if (!costs.Any() || !costs[0].Any()) return 0;
        int min1 = 0, min2 = 0, idx = -1;
        for (int i = 0; i < costs.Length; i++) {
            int m1 = Int32.MaxValue, m2 = m1, id = -1;
            for (int k = 0; k < costs[i].Length; k++) {
                int cost = costs[i][k] + (k == idx ? min2 : min1);
                if (cost < m1) {
                    m2 = m1; m1 = cost; id = k;
                }
                else if (cost < m2) m2 = cost;
            }
            min1 = m1; min2 = m2; idx = id;
        }
        return min1;
    }
    
    public int MinCostII1(int[,] costs) {
        // length is total # of elements
        // GetLength is dimisional size
        if(costs.Length == 0) return 0;
        
        int n = costs.GetLength(0);
        int k = costs.GetLength(1);
        int[,] dp = costs;
        // min1 is the index of the 1st-smallest cost till previous house
        // min2 is the index of the 2nd-smallest cost till previous house
        int min1 = -1, min2 = min1;
        for(int i = 0; i < n; i++){
            int tmpMin1 = min1, tmpMin2 = min2;
            min1 = -1;
            min2 = -1;
            for(int j = 0; j < k; j++){
                // only check the house with previous min cost and 2nd min cost colors 
                if(j != tmpMin1){
                    dp[i,j] += tmpMin1 < 0 ? 0 : dp[i - 1,tmpMin1];
                }
                else {
                    dp[i,j] += tmpMin2 < 0 ? 0 : dp[i - 1,tmpMin2];
                }
                // update the last two min costs of index
                if (min1 < 0 || dp[i,j] < dp[i,min1]) {
                    // assign min to 2nd min index since there is a new min
                    min2 = min1;
                    min1 = j;                     
                } else if (min2 < 0 || dp[i,j] < dp[i,min2]) {
                    min2 = j;
                }
            }
        }
        return dp[n-1,min1];
    }
}
