public class Solution {
    public IList<int> FindClosestElements(int[] A, int k, int x) {
        // arr is sorted
        int left = 0, right = A.Length - k;
        while (left < right) {
            int mid = (left + right) / 2;
            // x in between a[mid], a[mid+k]
            if (x - A[mid] > A[mid + k] - x)
                left = mid + 1;
            else
                right = mid;
        }
        var res = new int[k];
        Array.Copy(A, left, res, 0, k);
        return res;
    }
}
