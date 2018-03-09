using System;

namespace ClimbStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("stairs: {0}", args[0]);
            int n = int.Parse(args[0]);
            Console.WriteLine("the ways of climb stairs: {0}", ClimbStairs(n));            
        }
        
        static int ClimbStairs(int n){
            if (n <= 1) return 1;
            
            int[] dp = new int[n];
            dp[0] = 1; dp[1] = 2;
            for (int i = 2; i < n; i++){
                dp[i] = dp[i-1] + dp[i-2];
            }
            return dp[n-1];
        }
    }
}
