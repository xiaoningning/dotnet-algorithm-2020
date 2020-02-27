public class Solution {
    public int SubarraysDivByK(int[] A, int K) {
        var cnt = new int[K];
        cnt[0]  = 1;
        int res = 0, sum = 0;
        foreach (var a in A) {
            // a can be negative => + k
            sum = (sum + a % K + K) % K;
            res += cnt[sum]++;
        }
        return res;
    }
}
