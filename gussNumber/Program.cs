public class Solution {
  // Guess(n) return -1 if my number is lower, 1 if my number is higher, otherwise return 0
  public int GuessNumber(n) {
    if (Guess(n) == 0) return n;
   
    int left = 1, right = n;
    while (left < right) {
        int mid = left + (right - left) / 2, t = Guess(mid);
        if (t == 0) return mid;
        else if (t == 1) left = mid;
        else right = mid;
    }
    return left;
  }
}
