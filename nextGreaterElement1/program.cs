public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        int[] res = new int[nums1.Length];
        var st = new Stack<int>();
        var m = new Dictionary<int, int>();
        foreach (var n in nums2) {
            while (st.Count != 0 && st.Peek() < n)
                m[st.Pop()] = n;
            st.Push(n);
        }
        for (int i = 0; i < nums1.Length; i++) {
            res[i] = !m.ContainsKey(nums1[i]) ? -1 : m[nums1[i]];
        }
        return res;
    }
}
