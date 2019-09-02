public class Solution {
    public int[][] KClosest1(int[][] points, int K) {
        Array.Sort(points, (p1,p2) => (p1[0]*p1[0] + p1[1]*p1[1]) - (p2[0]*p2[0] + p2[1]*p2[1]));
        int[][] res = new int[K][];
        Array.Copy(points, 0, res, 0, K);
        return res;
    }
    // quick select like quick sort
    public int[][] KClosest(int[][] points, int K) {
        int len =  points.GetLength(0), l = 0, r = len - 1;
        while (l <= r) {
            int mid = helper(points, l, r);
            if (mid == K) break;
            if (mid < K) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        int[][] res = new int[K][];
        Array.Copy(points, 0, res, 0, K);
        return res;
    }
    private int helper(int[][] A, int l, int r) {
        int[] pivot = A[l];
        while (l < r) {
            while (l < r && compare(A[r], pivot) >= 0) r--;
            A[l] = A[r];
            while (l < r && compare(A[l], pivot) <= 0) l++;
            A[r] = A[l];
        }
        A[l] = pivot;
        return l;
    }

    private int compare(int[] p1, int[] p2) {
        return p1[0] * p1[0] + p1[1] * p1[1] - p2[0] * p2[0] - p2[1] * p2[1];
    }
}
