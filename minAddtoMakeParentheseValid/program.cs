public class Solution {
    public int MinAddToMakeValid(string S) {
        int left = 0, right = 0;
        for (int i = 0; i < S.Length; ++i) {
            if (S[i] == '(') right++;
            // s[i] == ")" and has "(" already
            else if (right > 0) right--;
            // if valid ")" right--
            // invalid ")" with no "(" in front 
            else left++;
        }
        return left + right;
    }
}
