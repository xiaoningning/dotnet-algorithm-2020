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
        int p = l;
        l++;
        while (l <= r) {
            if (compare(A[l], pivot) > 0 && compare(A[r], pivot) < 0) {
                swap(A, l, r);
                l++; r--;
            }
            if (compare(A[l], pivot) <= 0) l++;
            if (compare(A[r], pivot) >= 0) r--;
        }
        swap(A, p, r);
        return r;
    }

    private int compare(int[] p1, int[] p2) {
        return p1[0] * p1[0] + p1[1] * p1[1] - p2[0] * p2[0] - p2[1] * p2[1];
    }
    private void swap(int[][] A, int l, int r) {
        var t = A[l];
        A[l] = A[r];
        A[r] = t;
    }
}
