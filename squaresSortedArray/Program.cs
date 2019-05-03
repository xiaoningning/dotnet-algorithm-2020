Using System;

public class Solution {
    public int[] SortedSquares(int[] A) {
        int n = A.Length;
        int[] res = new int[n];
        int i = 0, j = n-1;
        for (int p = n-1; p >= 0; p--) {
            if (Math.Abs(A[i]) > Math.Abs(A[j])) {
                res[p] = A[i] * A[i];
                i++;
            }
            else {
                res[p] = A[j] * A[j];
                j--; 
            }
        }
        return res;
    }
}
