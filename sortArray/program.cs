public class Solution {
    public int[] SortArray(int[] nums) {
        // time: O(nlogn)
        // space: O(n)
        MergeSort(nums, 0, nums.Length - 1);
        return nums;
    }
    void MergeSort(int[] nums, int start, int end) {
        if (start >= end) return;
        int mid = start + (end - start) / 2;
        MergeSort(nums, start, mid);
        MergeSort(nums, mid + 1, end);
        Merge(nums, start, mid, end);
    }
    void Merge(int[] nums, int start, int mid, int end) {
        var tmp = new int[end - start + 1];
        int i = start, j = mid + 1, k = 0;
        while (i <= mid && j <= end) {
            if (nums[i] < nums[j]) tmp[k++] = nums[i++];
            else tmp[k++] = nums[j++];       
        }
        while (i <= mid) tmp[k++] = nums[i++];
        while (j <= end) tmp[k++] = nums[j++];
        for (int idx = 0; idx < tmp.Length; idx++) {
            nums[idx + start] = tmp[idx];
        }
    }
    
    public int[] SortArray2(int[] nums) {
        // time: O(nlogn)
        // space: O(logn)
        QuickSort(nums, 0, nums.Length - 1);
        return nums;
    }
    void QuickSort(int[] nums, int start, int end) {
        if (start >= end) return;
        int pivot = nums[start], i = start + 1, j = end;
        while (i <= j) {
            if (nums[i] > pivot && nums[j] < pivot) {
                Swap(nums, i, j);
                i++; j--;
            }
            if (nums[i] <= pivot) i++;
            if (nums[j] >= pivot) j--;
        }
        Swap(nums, start, j);
        QuickSort(nums, start, j - 1);
        QuickSort(nums, j + 1, end);
    }
    void Swap(int[] nums, int i, int j) {
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
    
    public int[] SortArray1(int[] nums) {
        // -50000 <= A[i] <= 50000
        int[] cnt = new int[100001];
        var res = new List<int>();
        // 5000 offset negative
        foreach (var n in nums) cnt[50000 + n]++;
        for (int i = 0; i < cnt.Length; i++) {
            while (cnt[i]-- > 0)
                res.Add(i - 50000);
        }
        // time: O(n)
        // space: O(n)
        return res.ToArray();
    }
}
