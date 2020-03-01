public class Solution {
    // no extra space, like cycled linked list
    public bool IsHappy(int n) {
        int slow = n, fast = n;
        while (true) {
            slow = findNext(slow);
            // fast move twice
            fast = findNext(fast);
            fast = findNext(fast);
            // detect cycled
            if (slow == fast) break;
        }
        return slow == 1;
    }
    int findNext(int n) {
        int sum = 0;
        while (n > 0) {
            sum += (n % 10) * (n % 10);
            n /= 10;
        }
        return sum;
    }
    public bool IsHappy1(int n) {
        var st = new HashSet<int>();
        while (n != 1) {
            int sum = 0;
            while (n > 0) {
                sum += (n % 10) * (n % 10);
                n /= 10;
            }
            n = sum;
            if (st.Contains(sum)) break;
            st.Add(sum);
        }
        return n == 1;
    }
}
