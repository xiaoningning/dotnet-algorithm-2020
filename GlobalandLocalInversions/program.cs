public class Solution {
    public bool IsIdealPermutation(int[] A) {
        // If the # of global inversions == the # of local inversions,
        // => all global inversions in permutations are local inversions.
        // to place number i, only place i at A[i-1],A[i] or A[i+1]
        for (int i = 0; i < A.Length; i++) {
            if (Math.Abs(A[i] - i) > 1) return false;
        }
        return true;
    }
}
