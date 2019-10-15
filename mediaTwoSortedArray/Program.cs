public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        if (m < n) return FindMedianSortedArrays(nums2, nums1);
        if (n == 0) return (nums1[(m - 1) / 2] + nums1[m / 2]) / 2.0;
        int left = 0, right = 2 * n;
        while (left <= right) {
            int mid2 = (left + right) / 2;
            int mid1 = m + n - mid2;
            double L1 = mid1 == 0 ? Int64.MinValue : nums1[(mid1 - 1) / 2];
            double L2 = mid2 == 0 ? Int64.MinValue : nums2[(mid2 - 1) / 2];
            double R1 = mid1 == m * 2 ? Int64.MaxValue : nums1[mid1 / 2];
            double R2 = mid2 == n * 2 ? Int64.MaxValue : nums2[mid2 / 2];
            if (L1 > R2) left = mid2 + 1;
            else if (L2 > R1) right = mid2 - 1;
            else return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2;
        }
        return -1;
    }

    public double FindMedianSortedArrays1(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length, left = (m + n + 1) / 2, right = (m + n + 2) / 2;
        return (FindKth(nums1, 0, nums2, 0, left) + FindKth(nums1, 0, nums2, 0, right)) / 2.0;
    }
    double FindKth(int[] nums1, int i, int[] nums2, int j, int k) {
        if (i >= nums1.Length) return nums2[j + k -1];
        if (j >= nums2.Length) return nums1[i + k -1];
        if (k == 1) return Math.Min(nums1[i], nums2[j]);
        int mid1 = (i + k / 2 - 1 < nums1.Length) ? nums1[i + k / 2 - 1] : Int32.MaxValue;
        int mid2 = (j + k / 2 - 1 < nums2.Length) ? nums2[j + k / 2 - 1] : Int32.MaxValue;
        if (mid1 < mid2) return FindKth(nums1, i + k/2, nums2, j, k - k/2);
        else return FindKth(nums1, i, nums2, j + k/2, k - k/2);
    }
}
