using System;

namespace missingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int[] nums = new int[]{3, 0, 1};
            Console.WriteLine("find missing number: {0}", obj.MissingNumber(nums));            
        }
    }
    public class Solution {
        public int MissingNumber1(int[] nums) {
            int sum = 0;
            int n = nums.Length;
            foreach(int i in nums){
                sum += i;
            }        
            for(int i = 1; i <= n; i++){
                sum -= i;
            }
            return -sum;
        }

        public int MissingNumber2(int[] nums) {
            Array.Sort(nums);
            int left = 0, right = nums.Length;
            while (left < right){
                int mid = left + (right - left) / 2;
                if (nums[mid] > mid) right = mid;
                else left = mid+1;
            }
            return left;
        }

        public int MissingNumber(int[] nums) {
            // only miss one
            int xor = nums.Length;
            for (int i = 0; i < nums.Length; i++) {
                xor ^= i;
                xor ^= nums[i];
            }
            return xor;
        }
    }
}
