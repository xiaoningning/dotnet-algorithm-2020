public class Solution {
    public int MinFlipsMonoIncr(string S) {
        int cnt0 = 0, cnt1 = 0;
        foreach (var c in S) {
            if (c == '0') cnt0++;
            else  cnt1++;
            // if # of flip 1 smaller, res => res = cnt1 
            cnt0 = Math.Min(cnt0, cnt1);
        }
        return cnt0;
    }
    public int MinFlipsMonoIncr1(string S) {
        int n = S.Length, res = Int32.MaxValue;
        int[] cnt0 = new int[n+1], cnt1 = new int[n+1];
        for (int i = 1, j= n-1; i <= n && j >= 0; i++, j--) {
            cnt1[i] += cnt1[i-1] + (S[i-1] == '1' ? 1 : 0);
            cnt0[j] += cnt0[j+1] + (S[j] == '0' ? 1 : 0);
        }
        for (int i = 0; i <= n; i++) res = Math.Min(res, cnt0[i] + cnt1[i]);
        return res;
    }
}
