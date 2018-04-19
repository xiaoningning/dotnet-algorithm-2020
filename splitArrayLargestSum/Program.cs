using System;

namespace splitArrayLargestSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{7,2,5,10,8};
            int m = 2;
            Console.WriteLine("Split array with largest sum: {0}", SplitArray(nums, m));
            Console.WriteLine("Split array with largest sum 1: {0}", SplitArray1(nums, m));
        }

        static int SplitArray(int[] nums, int m) {
            int n = nums.Length;
            int max = 0;
            int min = 0;
            for(int i = 0; i< n; i++){
                min = Math.Max(min, nums[i]);
                max += nums[i];
            }
            
            long left = min, right = max;
            while(left < right){
                long mid = left + (right - left)/2;
                if(valid_split(nums, m, mid)) right = mid;
                else left = mid +1;
            }
            
            return (int)left;
        }
        
        static bool valid_split(int[] nums, int m, long sum){
            int cnt = 1;
            int currSum = 0;
            for(int i=0; i< nums.Length; i++){
                currSum += nums[i];
                if(currSum > sum){
                    currSum = nums[i];
                    cnt++;
                    if (cnt > m) return false;
                }
            }
            return true;
        }
        
        
        static int SplitArray1(int[] nums, int m) {
            int n = nums.Length;
            int[,] dp = new int[m + 1, n + 1];
            
            for(int i = 0; i <= m; i++ ) {
                for(int j = 0; j <= n; j++){
                    dp[i,j] = Int32.MaxValue;
                }
            }
            dp[0,0] = 0;
            
            int[] sum = new int[n+1];
            for(int i = 0; i< n; i++){
                sum[i+1] = sum[i] + nums[i];
            }
            
            for(int i = 1; i <= m; i++ ) {
                for(int j = 1; j <= n; j++){
                    for(int k = i-1; k < j; k++){
                        int val = Math.Max(dp[i-1,k], sum[j] - sum[k]);
                        dp[i,j] = Math.Min(dp[i,j], val);
                    }
                }
            }
            return dp[m,n];
        }    
    }
}
