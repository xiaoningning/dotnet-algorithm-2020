public class Solution {
    public int MaxDistToClosest(int[] seats) {
        int res = 0, pre = 0, n = seats.Length;
        // pre is previous 0
        // j counts 0;
        for (int j = 0; j < n; j++) {
            if (seats[j] == 1) {
                res = pre > 0 ? 
                    Math.Max(res, (j - pre + 1) / 2) 
                    : Math.Max(res, j - pre);
                pre = j + 1;
            }
        }
        // case: [1,0,0,0] seat at the last
        if (seats[n-1] == 0) res = Math.Max(res, n - pre);
        return res;
    }
}
