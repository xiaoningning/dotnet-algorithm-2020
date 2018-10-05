using System;

namespace searchRotatedSortedArrayII
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            int t = 3;
            int[] nums = new int[]{1,3,1,1};
            Console.WriteLine("search in rotated sorted array II with duplicates {0} : {1}", t, obj.Search(nums, t));
        }
    }
    public class Solution {
        public bool Search(int[] nums, int target) {
            int n = nums.Length;
            if (n == 0) return false;
            int left = 0, right = n - 1;
            while (left <= right) {
                int mid = left + (right - left) / 2;
                // [3 1 1] or [1 1 3 1]
                // shift the far right to left
                if (nums[mid] == target) return true;
                else if (nums[mid] < nums[right]) {
                    if (nums[mid] < target && target <= nums[right]) left = mid + 1;
                    else right = mid - 1;
                }
                else if (nums[mid] > nums[right]){
                    if (nums[left] <= target && target < nums[mid]) right = mid - 1;
                    else left = mid + 1;
                } 
                // duplicates on the rotation edge
                // shift the far right to left
                else {
                    right--;
                }
            }
            return false;
        }
    }
}
