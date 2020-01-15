public class Solution {
    public int NumPairsDivisibleBy602(int[] time) {
        // (t + x) % 60 = 0 => t%60 = 60 - x%60
        // if t%60 ==0, => (60-t%60)%60 map to [0,59]
        int[] c = new int[60];
        int res = 0;
        // 1 <= time[i] <= 500
        foreach (var t in time) {
            res += c[(60 - t % 60) % 60];
            c[t % 60] += 1;
        }
        return res;
    }
    public int NumPairsDivisibleBy60(int[] time) {
        // (t + x) % 60 = 0 => t%60 = 60 - x%60
        // consider t%60 ==0, => (60-t%60)%60 map to [0,59]
        int[] c = new int[60];
        int res = 0;
        foreach (var t in time) {
            c[t % 60] += 1;
        }
        // count %60 = 0 or 30 case
        // sum of combimation: n * (n-1) / 2
        res += c[0] * (c[0] - 1)/2;
        res += c[30] * (c[30] - 1)/2;
        for(int i = 1; i < 30; i++){
            res += c[i] * c[60 - i];
        }
        return res;
    }
}
