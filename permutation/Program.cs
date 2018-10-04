using System;
using System.Collections.Generic;

namespace permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var res = obj.Permute(new int[]{1,2,3});
            Console.WriteLine("permutation");
            foreach(var r in res) {
                Console.WriteLine(string.Join(",", r));
            }
        }
    }
    public class Solution {
        public IList<IList<int>> Permute(int[] nums) {
            List<IList<int>> res = new List<IList<int>>();
            Backtracking(nums, new List<int>(), res);
            return res;
        }
        void Backtracking(int[] nums, List<int> tmp, List<IList<int>> res){
            if (tmp.Count == nums.Length) res.Add(new List<int>(tmp));
            else {
                for (int i = 0; i < nums.Length; ++i) {
                    if (tmp.Contains(nums[i])) continue;
                    tmp.Add(nums[i]);
                    Backtracking(nums, tmp, res);
                    tmp.RemoveAt(tmp.Count - 1);
                }
            }
        }
    }
}
