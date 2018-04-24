using System;
using System.Collections.Generic;

namespace CombinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{2,3,6,7};
            int target = 7;
            var res = CombinationSum(nums, target);
            foreach(var r in res){
                Console.WriteLine("rest list: {0}", string.Join(',', r));
            } 
        }
        static IList<IList<int>> CombinationSum(int[] candidates, int target) {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(candidates);
            BackTrack(candidates, target, 0, new List<int>(), res);        
            return res;
        }
        static void BackTrack(int[] candidates, int remain, int start, List<int> temp, List<IList<int>> res){
            if (remain < 0) return;
            else if (remain == 0) res.Add(new List<int>(temp));
            else {
                for(int i = start; i < candidates.Length; i++){
                    temp.Add(candidates[i]);
                    // i can be reused, so it is not i++.
                    BackTrack(candidates, remain - candidates[i], i, temp, res);
                    temp.RemoveAt(temp.Count -1);
                }            
            }
        }
    }
}
