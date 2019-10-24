public class Solution {
    public int MaximizeSweetness(int[] sweetness, int K) {
        int left = sweetness.Min(), right = sweetness.Sum();
        while (left < right) {
            int mid = (left + right + 1) / 2;
            int cur = 0, cuts = 0;
            foreach (int a in sweetness) {
                if ((cur += a) >= mid) {
                    cur = 0;
                    if (++cuts > K) break;
                }
            }
            if (cuts > K)
                left = mid;
            else
                right = mid - 1;
        }
        return left;
    }
}
