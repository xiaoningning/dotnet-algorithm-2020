public class Solution {
    public int MinEatingSpeed(int[] piles, int H) {
        int left = 1, right = Int32.MaxValue;
        // binary search to find
        while (left < right) {
            int mid = left + (right - left) / 2, cnt = 0;
            foreach (int pile in piles) cnt += pile % mid == 0 ? pile/mid : pile/mid + 1;
            if (cnt > H) left = mid + 1;
            else right = mid;
        }
        return right;
    }
}
