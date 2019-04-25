using System;

namespace subarraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("add binary {0}", obj.SubarraySum(new int[]{0,1,2,3}, 2));
        }
    }
    public class Solution {
        public int SubarraySum(int[] nums, int k) {
            int res = 0, sum = 0, n = nums.Length;
            // key: sum, value: cnt of sum
            Dictionary<int, int> m = new Dictionary<int, int>();
            m.Add(0,1);
            for (int i = 0; i < n; ++i) {
                sum += nums[i];
                res += m.ContainsKey(sum-k) ? m[sum - k] : 0;
                if (!m.ContainsKey(sum)) m.Add(sum, 0);
                ++m[sum]; 
            }
            return res;
        }
    }
}
