using System;

namespace missingRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("reverse words: {0}", obj.FindMissingRanges(new int[]{0,1,3,4,67}, 0, 99));
        }
    }
    public class Solution {
        public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
            List<string> res = new List<string>();

                int l = lower;
                for (int i = 0; i < nums.Length; ++i) {
                    // int r = (i < nums.Length && nums[i] <= upper) ? nums[i] : upper + 1;
                    int r = nums[i];
                    if (r > l) {
                        res.Add(r - l == 1 ? l.ToString() : l.ToString() + "->" + (r - 1).ToString()); 
                    }
                    // over flow case
                    l = r == Int32.MaxValue ? r : r + 1;
                }
                // do a final check empty array case
                if (l <= upper && upper != nums[nums.Length - 1]) res.Add(l == upper ? l.ToString() : l.ToString() + "->" + upper.ToString());
                return res;
        }
    }  
}
