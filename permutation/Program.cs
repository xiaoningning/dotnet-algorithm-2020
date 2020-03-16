public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        if (!nums.Any()) return new List<IList<int>>(){new List<int>()};
        List<IList<int>> res = new List<IList<int>>();
        var arr = new List<int>(nums);
        int first = arr.First();
        arr.RemoveAt(0);
        var nres = Permute(arr.ToArray());
        foreach (var l in nres) {
            for (int i = 0; i <= l.Count; i++) {
                l.Insert(i, first);
                res.Add(new List<int>(l));
                l.RemoveAt(i);
            }
        }
        return res;
    }
    public IList<IList<int>> Permute2(int[] nums) {
        List<IList<int>> res = new List<IList<int>>();
        dfs(nums, 0, res);
        return res;
    }
    void dfs(int[] nums, int start, List<IList<int>> res) {
        if (start == nums.Length) res.Add(new List<int>(nums));
        else {
            for (int i = start; i < nums.Length; i++){
                swap(nums, start, i);
                dfs(nums, start + 1, res);
                swap(nums, start, i);
            }
        }
    }
    void swap(int[] nums, int x, int y) {
        var t = nums[x]; nums[x] = nums[y]; nums[y] = t;
    }
    public IList<IList<int>> Permute1(int[] nums) {
        List<IList<int>> res = new List<IList<int>>();
        dfs(nums, new List<int>(), res);
        return res;
    }
    void dfs(int[] nums, List<int> tmp, List<IList<int>> res){
        if (tmp.Count == nums.Length) res.Add(new List<int>(tmp));
        else {
            for (int i = 0; i < nums.Length; ++i) {
                // check if it is used
                if (tmp.Contains(nums[i])) continue;
                tmp.Add(nums[i]);
                // permutation, no i change
                dfs(nums, tmp, res);
                tmp.RemoveAt(tmp.Count - 1);
            }
        }
    }
}
