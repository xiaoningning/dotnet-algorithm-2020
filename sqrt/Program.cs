public class Solution {
    public int MySqrt(int x) {
        if (x <= 1) return x;
        int right = x, left = 0;
        while (left <= right){
            int mid = left + (right - left) / 2;
            // use divide otherwise, it could be overflow int.
            if (x / mid >= mid) left = mid + 1;
            else right = mid - 1;
        }
        return left - 1;
    }
}
