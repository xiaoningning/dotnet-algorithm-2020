public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        Array.Sort(nums);
        int n = nums.Length, l = 0, r = nums[n -1] - nums[0];
        while (l < r) {
            int mid = l + (r - l) / 2;
            int cnt = 0;
            for (int i = 0, j = 0; i < n - 1; ++i) {  
                while (j < n && nums[j] <= nums[i] + mid) j++;
                // -1 extra ++
                cnt += j - i - 1;
            }
            if (cnt < k) l = mid + 1;
            else r = mid;
        }
        // smallest distance
        return l;
    }
}
