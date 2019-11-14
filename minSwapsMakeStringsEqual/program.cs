public class Solution {
    public int MinimumSwap(string s1, string s2) {
        int x1 = 0, y1 = 0;      
        for (int i = 0; i < s1.Length; i++) {
            if (s1[i] != s2[i] && s1[i] == 'x') x1 += 1;
            if (s1[i] != s2[i] && s1[i] == 'y') y1 += 1;
        }
        
        if ((x1 + y1) % 2 != 0) return -1;
            
        // xx, yy needs one swap, and xy yx needs two swaps, 
        // so find the pair of x and the number of redundant x
        return x1 / 2 + y1 / 2 + 2 * (x1 % 2);
    }
}
