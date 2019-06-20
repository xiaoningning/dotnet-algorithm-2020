public class Solution {
    public int PeakIndexInMountainArray(int[] A) {
        // right must be A.Length - 1
        // otherwise mid+1 will out of index
        int n = A.Length, left = 0, right = n - 1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (A[mid] < A[mid + 1]) left = mid + 1;
            else right = mid;
        }
        // O(logn) binary search
        return right;
    }
}
