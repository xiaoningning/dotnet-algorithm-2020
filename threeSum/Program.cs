using System;
using System.Collections.Generic;

namespace threeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{-1, 0, 1, 2, -1, -4};
            Console.WriteLine("three sum to zero:");
            var res = obj.ThreeSum(nums);
            foreach(var r in res){
                Console.WriteLine(string.Join(",", r));
            }
        }
    }
    public class Solution {
        public IList<IList<int>> ThreeSum(int[] nums) {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            for (int k = 0; k < nums.Length; ++k) {
                // at least one negative
                if (nums[k] > 0) break;
                // skip duplicated
                if (k > 0 && nums[k] == nums[k - 1]) continue;
                
                // 3 sums target is 0
                int target = 0 - nums[k];

                int i = k + 1, j = nums.Length - 1;
                while (i < j) {
                    if (nums[i] + nums[j] == target) {
                        res.Add(new int[]{nums[k], nums[i], nums[j]});
                        while (i < j && nums[i] == nums[i + 1]) ++i;
                        while (i < j && nums[j] == nums[j - 1]) --j;
                        ++i; --j;
                    } 
                    else if (nums[i] + nums[j] < target) ++i;
                    else --j;
                }
            }
            return res;
        }
    }
}
