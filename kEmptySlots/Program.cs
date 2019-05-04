public class Solution {
    public int KEmptySlots1(int[] flowers, int k) {
        // flowers: day -> position
        int n = flowers.Length;
        int[] days = new int[n]; // position -> day
        int res = Int32.MaxValue;
        int left = 0, right = k+1; // position
        for (int i = 0; i < n; i++) days[flowers[i] - 1] = i + 1;
        for (int i = 0; right < n; i++) {
            // days[i-1] > days[left] && > days[right]
            if (days[i] < days[left] || days[i] <= days[right]) {
                if (i == right) res = Math.Min(res, Math.Max(days[left], days[right]));
                left = i ;
                right = left + k + 1;
            }
        }
        return res == Int32.MaxValue ? -1 : res;
    }
}
