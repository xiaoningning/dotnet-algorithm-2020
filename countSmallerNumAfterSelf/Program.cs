public class Solution {
    public IList<int> CountSmaller(int[] nums) {
        int[] res = new int[nums.Length];
	List<int> t = new List<int>();
	// smaller after self, count from the last
	for (int i = nums.Length -1; i >= 0; --i){
		int left = 0, right = t.Count;
		while(left < right){
			int mid = left + (right - left) / 2;
			// find smaller than nums[i]
			if (t[mid] < nums[i]) left = mid + 1;
			else right = mid;
		}
		t.Insert(right, nums[i]);
		res[i] = right;			
	}	
	// time: O(nlogn)
	return res;
    }
}
