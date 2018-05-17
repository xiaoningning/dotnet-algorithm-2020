using System;

namespace removeDuplicatesSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{1,1,2,2,2,3};
            Console.WriteLine("remove duplicated from sorted array {0}", obj.RemoveDuplicates(nums));
        }
    }
    public class Solution {
        public int RemoveDuplicates(int[] nums) {
            // only allow up to 2 duplicates
            if(nums.Length <= 2) return nums.Length;
            int pre = 0;
            int cnt = 1;
            for(int i = 1; i < nums.Length; i++){
                if(nums[pre] == nums[i] && cnt == 2) {                
                }
                else {                
                    if(nums[pre] == nums[i]) cnt++;                
                    else cnt = 1;
                    nums[++pre] = nums[i];                
                }
            }
            return pre+1;
        }
    }
}
