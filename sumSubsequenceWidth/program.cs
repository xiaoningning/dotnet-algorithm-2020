public class Solution {
    public int SumSubseqWidths(int[] A) {
        Array.Sort(A);
        long res = 0;
        long mod = (long)(Math.Pow(10,9)) + 7, c = 1; 
        for (int i = 0; i < A.Length; ++i, c = (c << 1) % mod)
            res = (res + A[i] * c - A[A.Length - i - 1] * c) % mod;
        return (int)(res % mod);
    }
}
