using System;
using System.Collections.Generic;

namespace permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var res = obj.PermuteUnique(new int[]{1,1,2});
            Console.WriteLine("Permute Unique");
            foreach(var r in res) {
                Console.WriteLine(string.Join(",", r));
            }
        }
    }
    public class Solution {
        public IList<IList<int>> PermuteUnique(int[] nums) {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            dfs(nums, new List<int>(), res, new bool[nums.Length]);
            // O(n!)
            return res;
        }
        void dfs(int[] nums, List<int> tmp, List<IList<int>> res, bool[] used){
            if (tmp.Count == nums.Length) res.Add(new List<int>(tmp));
            else {
                for (int i = 0; i < nums.Length; ++i) {
                    // Same number can be only used once at each depth.
                    if (used[i] || i > 0 && nums[i-1] == nums[i] && !used[i-1]) continue;
                    tmp.Add(nums[i]);
                    used[i] = true;
                    dfs(nums, tmp, res, used);
                    used[i] = false;
                    tmp.RemoveAt(tmp.Count - 1);
                }
            }
        }
    }    

}
