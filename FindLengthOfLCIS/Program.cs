using System;

namespace FindLengthOfLCIS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("array: {0}", args[0]);
            int[] nums = Array.ConvertAll(args[0].Split(','), s => int.Parse(s));
            Console.WriteLine("the length of LCIS: {0}", FindLengthOfLCIS(nums));
        }
        
        static int FindLengthOfLCIS(int[] nums) {
            int res = 0, cnt = 0;
            for (int i = 0; i < nums.Length; i++){
                if (i ==0 || nums[i] > nums[i - 1]){
                    res = Math.Max(res, ++cnt);
                }
                else
                {
                    cnt = 1;
                }
            }
            return res;
        }
    }
}
