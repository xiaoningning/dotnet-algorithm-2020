public class Solution {
    public bool IsIdealPermutation1(int[] A) {
        // If the # of global inversions == the # of local inversions,
        // => all global inversions in permutations are local inversions.
        // to place number i, only place i at A[i-1],A[i] or A[i+1]
        for (int i = 0; i < A.Length; i++) {
            if (Math.Abs(A[i] - i) > 1) return false;
        }
        return true;
    }
    int[] tmp;
    public bool IsIdealPermutation(int[] A) {
        int localInv = 0, n = A.Length;
        tmp = new int[n];
        for (int i = 0; i < n -1; i++) if (A[i] > A[i+1]) localInv++;
        int globalInv = MergeSort(A, 0, n - 1);
        return globalInv == localInv;
    }
    int MergeSort(int[] A, int l, int r) { 
        if (l >= r) return 0;
        int m = l + (r - l) / 2;
        int inv = MergeSort(A, l, m) + MergeSort(A, m+1, r);
        int i = l;
        int j = m + 1;
        int k = 0;
        while (i <= m && j <= r) {
            if (A[i] <= A[j]) tmp[k++] = A[i++];
            else {
                inv += m - i + 1;
                tmp[k++] = A[j++];
            }
        }
        while (i <= m) tmp[k++] = A[i++];
        while (j <= r) tmp[k++] = A[j++];
        Array.Copy(tmp, 0, A, l, k);
        return inv;
    }
}
