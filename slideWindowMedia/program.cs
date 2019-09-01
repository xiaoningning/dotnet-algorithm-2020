public class Solution {
    public double[] MedianSlidingWindow(int[] nums, int k) {
        var res = new List<double>();
        
        for (int i = 0; i + k <= nums.Length; ++i) {
            var win = new List<int>();
            for (int j = i; j - i < k; j++) win.Add(nums[j]);
            win = win.OrderBy(x=>x).ToList();
            if (k % 2 != 0) res.Add(win[k/2]);
            else res.Add(((double)win[k/2-1] + win[k/2]) / 2);
        }
        return res.ToArray();
    }
    public double[] MedianSlidingWindow1(int[] nums, int k) {
        var res = new List<double>();
        var small = new List<int>();
        var large = new List<int>();
        for (int i = 0; i < nums.Length; ++i) {
            if (i >= k) {
                if (small.Contains(nums[i - k]))
                    RemoveSortedList(ref small, nums[i - k]);
                else if (large.Contains(nums[i - k]))
                    RemoveSortedList(ref large, nums[i - k]);
            }
            if (small.Count <= large.Count) {
                if (!large.Any() || nums[i] <= large.First() ) 
                    AddSortedList(ref small, nums[i]);
                else {
                    AddSortedList(ref small, large.First());
                    RemoveSortedList(ref large, large.First());
                    AddSortedList(ref large, nums[i]);
                }
            }
            else {
                if (nums[i] > small.Last() ) AddSortedList(ref large, nums[i]);
                else {
                    AddSortedList(ref large, small.Last());
                    RemoveSortedList(ref small, small.Last());
                    AddSortedList(ref small, nums[i]);
                }
            }
            if (i >= (k - 1)) {
                if (k % 2 != 0) res.Add(small.Last());
                else res.Add(((double)small.Last() + large.First()) / 2);
            }
        }
        return res.ToArray();
    }
    
    void AddSortedList(ref List<int> l, int n) {
        l.Add(n);
        SortedList(ref l);
    }
    void RemoveSortedList(ref List<int> l, int n) {
        l.Remove(n);
        SortedList(ref l);
    }
    void SortedList(ref List<int> l) {
        l = l.OrderBy(x=>x).ToList();
    }
}
