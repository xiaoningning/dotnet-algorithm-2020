public class Solution {
    public int TwoSumLessThanK(int[] A, int K) {
        Array.Sort(A);
        int i = 0, j = A.Length -1, S = -1;
        while (i < j) {
            if (A[i] + A[j] < K) S = Math.Max(S, A[i++] + A[j]);
            else j--;
        }
        return S;
    }
}
