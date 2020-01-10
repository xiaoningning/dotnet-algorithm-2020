public class Solution {
    public bool ValidPalindrome1(string s) {
        int begin = 0, end = s.Length - 1;
        while (begin < end) {
            if (s[begin] != s[end])
                return isValid(s, begin + 1, end) || isValid(s, begin, end - 1);
            else {begin++; end--;}
        }
        return true;
    }
    bool isValid(string s, int begin, int end){
        while(begin < end)
            if (s[begin++] != s[end--]) return false;
        return true;
    }
    public bool ValidPalindrome(string s){
        return isValid2(s, 0, s.Length - 1, 1);
    }
    bool isValid2(string s, int begin, int end, int deleteNumChar) {
        if ( begin >= end ) return true;
        if (s[begin] == s[end])
            return isValid2(s, begin + 1, end - 1, deleteNumChar);
        else 
            return deleteNumChar > 0 
                && (isValid2(s, begin + 1, end, deleteNumChar - 1) 
                || isValid2(s, begin, end - 1, deleteNumChar - 1));
    }
}
