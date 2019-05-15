public class Solution {
    public int MaxProduct(string[] words) {
        int[] masks = new int[words.Length];
        int res = 0;
        for (int i = 0; i < words.Length; i++) {
            // bit 1 -> c-'a' in the word
            foreach (char c in words[i]) masks[i] |= 1 << c - 'a';
            for (int j = 0; j < i; j++) {
                // no over lapping bit
                if ((masks[i] & masks[j]) == 0)
                    res = Math.Max(res, words[i].Length * words[j].Length);
            }
        }
        return res;
    }
}
