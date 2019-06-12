public class Solution {
    // 1　　2　　7　　4　　3　　1 -> 1　　3　　1　　2　　4　　7
    // process:
    /*
    1　　2　　7　　4　　3　　1
    1　　2　　7　　4　　3　　1
    1　　3　　7　　4　　2　　1
    1　　3　　1　　2　　4　　7
    */
    public void NextPermutation(int[] nums) {
        int n = nums.Length, i = n - 2, j = n - 1;
        while (i >= 0 && nums[i] >= nums[i + 1]) --i;
        if (i >= 0) {
            while (nums[j] <= nums[i]) --j;
            Swap(nums, i, j);
        }
        Array.Reverse(nums, i + 1, n - i - 1);
    }
    void Swap(int[] nums, int i, int j) {
        var t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}
