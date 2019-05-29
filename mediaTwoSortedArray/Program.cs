public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
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
