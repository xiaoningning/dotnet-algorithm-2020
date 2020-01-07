public class Solution {
    public int MinEatingSpeed(int[] piles, int H) {
        // eat speed: [1, max(piles)]
        // or [1, Int32.MaxValue]
        int left = 1, right = piles.Max();
        // binary search
        while (left < right) {
            int mid = left + (right - left) / 2, cnt = 0;
            foreach (int pile in piles) { 
                cnt += pile % mid == 0 ? pile/mid : pile/mid + 1;
            }
            if (cnt > H) left = mid + 1;
            else right = mid;
        }
        // it can be max(piles) as res
        // smaller side, b/c must <= H
        // O(nlogh)
        return left;
    }
}
