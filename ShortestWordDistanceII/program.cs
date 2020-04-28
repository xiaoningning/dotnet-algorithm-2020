public class WordDistance {
    Dictionary<string, List<int>> m = new Dictionary<string, List<int>>();
    public WordDistance(string[] words) {
        for (int i = 0; i < words.Length; i++) {
            if (!m.ContainsKey(words[i])) m.Add(words[i], new List<int>());
            m[words[i]].Add(i);
        }
    }
    
    public int Shortest(string word1, string word2) {
        int i = 0, j = 0, res = Int32.MaxValue;
        while (i < m[word1].Count && j < m[word2].Count) {
            res = Math.Min(res, Math.Abs(m[word1][i] - m[word2][j]));
            if (m[word1][i] < m[word2][j]) i++;
            else j++;
        }
        // O(m+n)
        return res;
    }
}

/**
 * Your WordDistance object will be instantiated and called as such:
 * WordDistance obj = new WordDistance(words);
 * int param_1 = obj.Shortest(word1,word2);
 */
