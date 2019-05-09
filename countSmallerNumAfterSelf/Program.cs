public class Solution {
    public IList<int> CountSmaller(int[] nums) {
        int[] res = new int[nums.Length];
		List<int> t = new List<int>();
		for (int i = nums.Length -1; i >= 0; --i){
			int left = 0, right = t.Count();
			while(left < right){
				int mid = left + (right - left) / 2;
				// find smaller than nums[i]
				if (t[mid] >= nums[i]) right = mid;
				else left = mid + 1;
			}
			t.Insert(right, nums[i]);
			res[i] = right;			
		}		
		return res;
    }
}
