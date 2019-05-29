public class Solution {
    public int PeakIndexInMountainArray(int[] A) {
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
