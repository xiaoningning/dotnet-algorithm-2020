public class Solution {
    public int MinSwap(int[] A, int[] B) {
        int n = A.Length;
        int[] swap = new int[n];
        int[] no_swap = new int[n];
        // make sure it is not higher than max possible swap
        Array.Fill(swap, n);
        Array.Fill(no_swap, n);
        swap[0] = 1;
        no_swap[0] = 0;
        for(int i = 1; i < n; i++){
            if(A[i] > A[i-1] && B[i] > B[i-1]){
                swap[i] = swap[i-1] + 1;
                no_swap[i] = no_swap[i-1];
            }
            if(B[i] > A[i-1] && A[i] > B[i-1]){
                swap[i] = Math.Min(swap[i], no_swap[i-1] + 1);
                no_swap[i] = Math.Min(no_swap[i], swap[i-1]);
            }
        }
        return Math.Min(swap[n-1], no_swap[n-1]); 
    }
}
