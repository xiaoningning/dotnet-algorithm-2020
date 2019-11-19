public class Solution {
    public int[] CorpFlightBookings(int[][] bookings, int n) {
        int[] res = new int[n];
        foreach (int[] b in bookings) {
            res[b[0] - 1] += b[2];
            // j + 1
            if (b[1] < n) res[b[1]] -= b[2];
        }
        // add previous lebal b/c i-j with the same k
        for (int i = 1; i < n; i++) res[i] += res[i - 1]; 
        return res;
    }
}
