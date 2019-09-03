public class Solution {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        int sum1 = (C - A) * (D - B), sum2 = (H - F) * (G - E);
        if (E >= C || F >= D || B >= H || A >= G) return sum1 + sum2;
        return sum1 - ((Math.Min(G, C) - Math.Max(A, E)) * (Math.Min(D, H) - Math.Max(B, F))) + sum2;
    }
}
