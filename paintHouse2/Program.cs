using System;

namespace paintHouse2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();            
            Console.WriteLine("paint house: {0}", obj.MinCostII(new int[,]{}));
            int[,] costs = new int[,]{
                {1,5,3},
                {2,9,4}
             };
            Console.WriteLine("paint house: {0}", obj.MinCostII(costs));
        }
    }
    public class Solution {
        public int MinCostII(int[,] costs) {
            // length is total # of elements
            // GetLength is dimisional size
            if(costs.Length == 0) return 0;
            
            int n = costs.GetLength(0);
            int k = costs.GetLength(1);
            int[,] dp = costs;
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
}
