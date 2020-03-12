public class Solution {
    public bool Find132pattern(int[] nums) {
        int third = Int32.MinValue;
        var st = new Stack<int>(); // track 3rd
        for (int i = nums.Length - 1; i >= 0; i--) {
            if (nums[i] < third) return true; // find 1st
            // find 2nd
            while (st.Any() && st.Peek() < nums[i] ) third = st.Pop();
            st.Push(nums[i]);
        }
        return false;
    }
}
