public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var res = new List<IList<int>>();
        // assume no duplication
        dfs(nums, 0, new List<int>(), res);
        return res;
    }
    void dfs(int[] nums, int start, List<int> tmp, List<IList<int>> res){
        res.Add(new List<int>(tmp));
        for (int i = start; i < nums.Length; ++i) {
            tmp.Add(nums[i]);
            dfs(nums, i+1, tmp, res);
            tmp.RemoveAt(tmp.Count -1);  
        }
    }
}
