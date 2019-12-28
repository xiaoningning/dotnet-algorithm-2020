public class Solution {
    public double KnightProbability(int N, int K, int r, int c) {
        if (K == 0) return 1;
        double[,] dp0 = new double[N,N];
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                dp0[i,j] = 1.0;
        int[,] dirs = new int[8,2]{{1, 2}, {-1, -2}, {1, -2}, {-1, 2},
                          {2, 1}, {-2, -1}, {2, -1}, {-2, 1}};
        for (int k = 0; k < K; ++k) {
            double[,] dp1 = new double[N,N];
            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j) 
                    for (int m = 0; m < 8; ++m) {
                        int x = j + dirs[m,0], y = i + dirs[m,1];
                        if (x < 0 || y < 0 || x >= N || y >= N) continue;
                        dp1[i,j] += dp0[y,x];
                    }
            // 2D array copy with N*N
            Array.Copy(dp1, 0, dp0, 0, N*N);
        }
        return dp0[r,c] / Math.Pow(8, K);
    }
}
