public class Solution {
    public int[] NumMovesStonesII(int[] stones) {
        Array.Sort(stones);
        int n = stones.Length;
        int mx = Math.Max(stones[n-1] - stones[1] - n + 2, stones[n-2] - stones[0] - n + 2);
        int mn = n;
        for (int i = 0, j = 0; j < n; j++) {
            // slide windows
            while (stones[j] - stones[i] + 1 > n) i++;
            int already_store = j - i + 1;
            if (already_store == n - 1 && stones[j] - stones[i] + 1 == n - 1) 
                mn = Math.Min(2, mn);
            else mn = Math.Min(n - already_store, mn);            
        }
        return new int[]{mn, mx};
    }
}
