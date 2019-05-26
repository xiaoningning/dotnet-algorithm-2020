public class Solution {
    public bool CanThreePartsEqualSum(int[] A) {
        int sum = A.Sum();
        if (sum % 3 != 0) return false;
        int part = 0, cnt = 0;
        foreach (int i in A) {
            part += i;
            if (part == sum / 3) {
                cnt++;
                part = 0; // reset part 
            }
        }
        // it can have negative
        // target sum can be 0
        return cnt == (sum == 0 ? 2 : 3);
    }
}
