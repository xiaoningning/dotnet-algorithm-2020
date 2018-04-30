using System;

namespace paintHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();            
            Console.WriteLine("paint house: {0}", obj.MinCost(new int[,]{}));
            int[,] costs = new int[,]{
                {1,3,2},
                {2,1,2}
             };
            Console.WriteLine("paint house: {0}", obj.MinCost(costs));
        }
    }
    public class Solution {
        public int MinCost(int[,] costs) {
            // length is total # of elements
            // GetLength is dimisional size
            if(costs.Length == 0) return 0;
            int[,] dp = costs;
            for(int i = 1; i < costs.GetLength(0); i++){
                // total three colors
                dp[i,0] += Math.Min(dp[i-1,1], dp[i-1,2]);
                dp[i,1] += Math.Min(dp[i-1,0], dp[i-1,2]);
                dp[i,2] += Math.Min(dp[i-1,1], dp[i-1,0]);
            }
            return Math.Min(Math.Min(dp[costs.GetLength(0)-1, 2], dp[costs.GetLength(0)-1,1]), dp[costs.GetLength(0)-1,0]);
        }
    }
}
