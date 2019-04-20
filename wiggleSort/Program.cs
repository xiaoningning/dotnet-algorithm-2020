using System;

namespace wiggleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{3,2,1,5,6};
            obj.WiggleSort(nums);
            Console.WriteLine("wiggle sort: {0}", string.Join(",", nums));
        }
    }
    public class Solution {
        public void WiggleSort(int[] nums) {
            if (nums.Length <= 1) return;
            for (int i = 1; i < nums.Length; ++i) {
                if ((i % 2 == 1 && nums[i] < nums[i - 1]) 
                    || (i % 2 == 0 && nums[i] > nums[i - 1])) {
                    Swap(nums, i, i - 1);
                }
            }
        }
        
        public void Swap(int[] nums, int i, int j) {
            int t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }
    }
}
