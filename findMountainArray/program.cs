/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */
 
class Solution {
    public int FindInMountainArray(int target, MountainArray A) {
        int n = A.Length(), l = 0, r = n - 1, m, peak = 0;
        // If I want find the index, I always use while (left < right)
        // If I may return the index during the search, I'll use while (left <= right)
        // find index of peak
        while (peak < r) {
            m = (peak + r) / 2;
            if (A.Get(m) < A.Get(m + 1))
                peak = m + 1;
            else
                r = m;
        }
        // find target in the left of peak
        int i = BinarySearch(A, target, 0, peak, true);
        // find target in the right of peak
        return i != -1 ? i : BinarySearch(A, target, peak + 1, A.Length() - 1, false);
    }
    int BinarySearch(MountainArray A, int target, int l, int r, bool asc) {
      while (l <= r) {
        int m = (l + r) / 2;
        int val = A.Get(m);
        if (val == target) return m;
        if (asc == val < target) l = m + 1;
        else r = m - 1;
      }
      return -1;
    }
}
