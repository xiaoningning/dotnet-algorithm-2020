public class Solution {
    public int PartitionDisjoint(int[] A) {
        int partitionIdx = 0, curMax = A[0], preMax = curMax;
        for (int i = 1; i < A.Length; i++){
            curMax = Math.Max(curMax, A[i]);
            if (A[i] < preMax) {
                preMax = curMax;
                partitionIdx = i;
            }
        }
        return partitionIdx + 1;
    }
    
    public int PartitionDisjoint1(int[] A) {
        int n = A.Length, curMax = A[0];
        int[] backMin = new int[n];        
        Array.Fill(backMin,A.Last());
        for (int i = n - 2; i >= 0; i--) {
            backMin[i] = Math.Min(backMin[i+1], A[i]);
        }
        for (int i = 0; i < n - 1; i++){
            curMax = Math.Max(curMax, A[i]);
            if (curMax <= backMin[i+1]) return i + 1;
        }
        return -1;
    }
}
