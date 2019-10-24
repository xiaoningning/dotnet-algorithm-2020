public class Solution {
    public double MinmaxGasDist(int[] stations, int K) {
        int cnt, N = stations.Length;
        double l = 0, r = stations[N - 1] - stations[0];
        double mid;
        while (l + (1e-6) < r) {
            mid = l + (r - l) / 2;
            cnt = 0;
            for (int i = 0; i < N - 1; ++i) {
                // calculate cnt of more gas station after distance is mid
                cnt += (int)Math.Ceiling((stations[i + 1] - stations[i]) / mid) - 1;
            }
            // mid is double, no need of +1 to move left side
            if (cnt > K) l = mid; 
            // r is possibe, but want bigger => search more
            else r = mid;
        }
        return r;
    }
}
