using System;
using System.Collections.Generic;

namespace FindMaxLength
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0/1 array: {0}", args[0]);                        
            int[] nums = Array.ConvertAll(args[0].Split(','), s => int.Parse(s));
            Console.WriteLine("max length of equal of 0, 1: {0}", FindMaxLength(nums));
        }

        static int FindMaxLength(int[] nums) {
            // key: sum, value: index
            Dictionary<int, int> map = new Dictionary<int, int>();
            int sum = 0;
            int maxLen = 0;
            map[0] = -1; // initial position of equal of 0/1
            for(int i = 0; i < nums.Length; i++){
                sum += nums[i] == 1 ? 1 : -1;
                if (map.ContainsKey(sum)){
                    maxLen = Math.Max(maxLen, i - map[sum]);
                }
                else{
                    map[sum] = i;
                }
            }
            return maxLen;
        }
    }
}
