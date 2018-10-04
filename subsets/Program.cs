using System;
using System.Collections.Generic;

namespace subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{1,2,3};
            var res = obj.Subsets(nums);
            Console.WriteLine("Subsets");
            foreach(var r in res) Console.WriteLine(string.Join(",",r));
        }
    }
    public class Solution {
        public IList<IList<int>> Subsets(int[] nums) {
            List<IList<int>> res = new List<IList<int>>();
            Backtrack(nums, 0, new List<int>(), res);
            return res;
        }
        void Backtrack(int[] nums, int pos, List<int> tmp, List<IList<int>> res){
            res.Add(new List<int>(tmp));
            for (int i = pos; i < nums.Length; ++i) {
                tmp.Add(nums[i]);
                Backtrack(nums, i+1, tmp, res);
                tmp.RemoveAt(tmp.Count -1);  
            }
        }
    }
}
