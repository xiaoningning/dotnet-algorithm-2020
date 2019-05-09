public class Solution {
    public int[] PlusOne(int[] digits) {
        int carry = 0;
        int n = digits.Length;
        for (int i = n -1; i >= 0; i--) {
            int t = digits[i] + carry + ((i == n-1) ? 1 : 0);
            digits[i] = t % 10;
            carry = t / 10;
        }
        int[] res = new int[n+1];
        res[0] = 1;
        return carry == 0 ? digits : res;
    }
}
