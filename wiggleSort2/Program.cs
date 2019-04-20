using System;

namespace wiggleSort2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{1,5,1,1,6,4};
            obj.WiggleSort(nums);
            Console.WriteLine("wiggle sort: {0}", string.Join(",", nums));
        }
    }
    public class Solution {
        public void WiggleSort(int[] nums) {
            int n = nums.Length;
            int k = (n+1) / 2;
            int j = n;
            int[] t = new int[n];
            nums.CopyTo(t, 0);
            Array.Sort(t);            
            for (int i = 0; i < n; i++) {
                nums[i] = (i % 2) == 1 ? t[--j] : t[--k];
            }        
        }
    }
}
