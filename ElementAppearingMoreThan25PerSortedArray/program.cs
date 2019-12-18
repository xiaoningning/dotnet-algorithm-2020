public class Solution {
    public int FindSpecialInteger(int[] arr) {
        int n = arr.Length, g = n / 4;
        for (int i = g; i < n; i += g) {
            int first = FindFirst(arr, arr[i]);
            if (arr[i] == arr[first + g]) return arr[i];
        }
        return Int32.MinValue;
    }
    int FindFirst(int[] nums, int target) {
        int l = 0, r = nums.Length;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (nums[m] < target) l = m + 1;
            else r = m;
        }
        return l;
    }
}
