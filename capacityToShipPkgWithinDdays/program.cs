public class Solution {
    public int ShipWithinDays(int[] weights, int D) {
        // int mn = weights.Max(), mx = weights.Sum();
        int mn = 0, mx = 0;
        foreach (int w in weights) {
            mn = Math.Max(mn, w);
            mx += w;
        }
        
        while (mn < mx) {
            int mid = mn + (mx - mn) / 2;
            int need = 1, cur = 0;
            foreach (var w in weights) {
                if (cur + w > mid) {
                    need += 1; 
                    cur = 0;
                }
                cur += w;
            }
            if (need > D) mn = mid + 1;
            else mx = mid;
        }
        // larger side capacity
        return mn;
    }
}
