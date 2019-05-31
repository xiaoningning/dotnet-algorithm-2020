public class Solution {
    public int[][] IntervalIntersection(int[][] A, int[][] B) {
        int n = A.GetLength(0);
        int m = B.GetLength(0);
        var res = new List<List<int>>();
        for (int i = 0, j = 0; i < n && j < m;) {
            if (A[i][1] < B[j][0]) i++;
            else if (B[j][1] < A[i][0]) j++;
            else {
                res.Add(new List<int>(){Math.Max(A[i][0],B[j][0]), Math.Min(A[i][1],B[j][1])});
                if (A[i][1] < B[j][1]) i++;
                else j++;
            }
        }
        int[][] arr = new int[res.Count][];
        for (int i = 0;  i < res.Count; i++) {
            arr[i] = new int[]{res[i][0], res[i][1]};
        }
        return arr;
    }
}
