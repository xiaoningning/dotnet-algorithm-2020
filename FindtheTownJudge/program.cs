public class Solution {
    public int FindJudge(int N, int[][] trust) {
        int[] degrees = new int[N+1];
        foreach (var t in trust) {
            degrees[t[0]]--;
            degrees[t[1]]++;
        }
        for (int i = 1; i <= N; i++){
            // in_degree – out_degree) N – 1 is the judge
            if (degrees[i] == N - 1) return i;
        }
        // O(N + T)
        return -1;
    }
}
