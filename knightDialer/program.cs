public class Solution {
    static int MOD = (Int32)Math.Pow(10, 9) + 7;
    public int KnightDialer(int N) {
        int[][] graph = new int[10][];
        graph[0] = new int[]{4,6};
        graph[1] = new int[]{6,8};
        graph[2] = new int[]{7,9};
        graph[3] = new int[]{4,8};
        graph[4] = new int[]{3,9,0};
        graph[5] = new int[]{};
        graph[6] = new int[]{1,7,0};
        graph[7] = new int[]{2,6};
        graph[8] = new int[]{1,3};
        graph[9] = new int[]{2,4};
        int cnt = 0;
        int[,] memo = new int[N+1,10];
        for (int j = 0; j <= N; j++)
            for (int i = 0; i <= 9; i++)
                memo[j,i]  = -1;
        for (int i = 0; i <= 9; i++)
            cnt = (cnt + helper(N - 1, i, graph, memo)) % MOD;
        return cnt;
    }
    int helper(int n, int cur, int[][] graph, int[,] memo) {
        if (n == 0)
            return 1;
        if (memo[n,cur] != -1)
            return memo[n,cur];
        int cnt = 0;
        foreach (var nei in graph[cur])
            cnt = (cnt + helper(n-1, nei, graph, memo)) % MOD;
        memo[n,cur] = cnt;
        return cnt;
    }
}
