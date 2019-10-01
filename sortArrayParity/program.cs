public class Solution {
    public int[] SortArrayByParity(int[] A) {
        for (int i = 0, j = 0; j < A.Length; ++j) {
            if (A[j] % 2 == 0) swap(A, i++, j);
        }
        return A;
    }
    void swap(int[] a, int i, int j) {
        int t = a[i];
        a[i] = a[j];
        a[j] = t;
    }
}
