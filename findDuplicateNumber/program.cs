public class Solution {
    public int FindDuplicate1(int[] nums) {
        // 1 <= nums[i] <= nums.Length - 1
        int left = 1, right = nums.Length - 1;
        while (left < right) {
            int mid = left + (right - left) / 2, cnt = 0;
            foreach (int n in nums) {
                if (n <= mid) cnt++;
            }
            if (cnt <= mid) left = mid + 1;
            else right = mid;
        }
        // O(nlogn)
        return right;
    }
    
    public int FindDuplicate(int[] nums) { 
        // it is a cycled list b/c of duplicates
        int slow = 0, fast = 0, head = 0;
        // 1 <= nums[i] <= nums.Length - 1
        // fast will meet slow
        while (true) {
            slow = nums[slow];
            fast = nums[nums[fast]];
            if (slow == fast) break;
        }
        while (true) {
            slow = nums[slow];
            head = nums[head];
            if (slow == head) break;
        }
        // O(n)
        return head;
    }
}
