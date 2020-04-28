public class Solution {
    public int ShortestDistance(string[] words, string word1, string word2) {
        int i1 = -1, i2 = -1, res = Int32.MaxValue;
        for (int i = 0; i < words.Length; i++) {
            if (words[i] == word1) i1 = i;
            else if (words[i] == word2) i2 = i;
            if (i1 != -1 && i2 != -1) res = Math.Min(res, Math.Abs(i2 - i1));
        }
        return res;
    }
}
