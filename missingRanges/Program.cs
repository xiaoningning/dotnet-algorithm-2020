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
            for (int i = 0; i <= nums.Length; ++i) {
                int r = i < nums.Length ? nums[i] : upper + 1;
                if (r > l) {
                    res.Add(r - l == 1 ? l.ToString() : l.ToString() + "->" + (r - 1).ToString()); 
                }
                l = r + 1;
            }
            return res;
        }
    }
}
