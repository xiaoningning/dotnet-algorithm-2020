using System;
using System.Collections.Generic;

namespace CombinationSum2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{10,1,2,7,6,1,5};
            int target = 8;
            var res = CombinationSum2(nums, target);
            foreach(var r in res){
                Console.WriteLine("rest list: {0}", string.Join(',', r));
            } 
        }
        static IList<IList<int>> CombinationSum2(int[] candidates, int target) {
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
                    // avoid duplications
                    if (i > start && candidates[i] == candidates[i-1]) continue;
                    temp.Add(candidates[i]);
                    // i is no resue.
                    BackTrack(candidates, remain - candidates[i], i+1, temp, res);
                    temp.RemoveAt(temp.Count -1);
                }            
            }
        }
    }
}
