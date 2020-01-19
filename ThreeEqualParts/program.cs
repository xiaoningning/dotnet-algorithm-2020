public class Solution {
    public int[] ThreeEqualParts(int[] A) {
        int cntOne = 0, n = A.Length;
        foreach (var a in A)  if (a == 1) cntOne++;
        if (cntOne == 0) return new int[]{0, n - 1};
        if (cntOne % 3 != 0) return new int[]{-1, -1};
        // the smae binary, only care of position of 1
        int k = cntOne / 3, idx1 = 0, idx2 = 0, idx3 = 0, cnt = 0;
        for (int i = 0; i < n; i++) {
            if (A[i] == 0) continue;
            cnt++;
            if (cnt == 1) idx1 = i;
            if (cnt == k + 1) idx2 = i;
            if (cnt == 2*k + 1) idx3 = i;
        }
        while (idx3 < n && A[idx1] == A[idx2] && A[idx2] == A[idx3]) {
            idx1++; idx2++; idx3++;
        }
        if (idx3 == n) return new int[]{idx1-1,idx2};
        return new int[]{-1,-1};
    }
}
