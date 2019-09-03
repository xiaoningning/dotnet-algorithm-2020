public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) res[i] = -1;
        var st = new Stack<int>();
        // a circular array
        for (int i = 0; i < n*2; i++) {
            int t = nums[i % n];
            while (st.Count != 0 && nums[st.Peek()] < t) {
                res[st.Pop()] = t;
            }
            if (i < n) st.Push(i);
        }
        return res;
    }
}
