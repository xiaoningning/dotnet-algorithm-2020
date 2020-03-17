public class Solution {
    public int FindUnsortedSubarray1(int[] nums) {
        // assume it always have a shortest unsorted array
        int n = nums.Length, mx = nums[0], mn = nums[n-1], start = -1, end = -2;
        for (int i = 1; i < n; i++) {
            mx = Math.Max(mx, nums[i]);
            mn = Math.Min(mn, nums[n - 1 - i]);
            if (mx > nums[i]) end = i;
            if (mn < nums[n-1-i]) start = n-1-i;
            // Console.WriteLine($"{end},{start}");
        }
        // time: O(n), space: O(1)
        return end - start + 1;
    }
    public int FindUnsortedSubarray(int[] nums) { 
        int n = nums.Length, i = 0, j = n - 1;
        var t = new int[n];
        Array.Copy(nums, t, n);
        Array.Sort(t);
        while (i < n && nums[i] == t[i]) i++;
        while (j > i && nums[j] == t[j]) j--;
        // time: O(nlogn), space: O(n)
        return j - i + 1;
    }
}
