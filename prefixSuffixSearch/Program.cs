public class WordFilter2
{        
    Dictionary<string, List<int>> mp = new Dictionary<string, List<int>>();
    Dictionary<string, List<int>> ms = new Dictionary<string, List<int>>();
    // O(N*L)
    public WordFilter2(string[] words) {
        for (int w = 0; w < words.Length; w++) {
            string word = words[w];
            for (int i = 0; i <= word.Length; i++) {
                string pre = word.Substring(0, i);
                if (!mp.ContainsKey(pre)) mp.Add(pre, new List<int>());
                mp[pre].Add(w);
            }
            for (int i = 0; i <= word.Length; i++) {
                string suf = word.Substring(word.Length - i);
                if (!ms.ContainsKey(suf)) ms.Add(suf, new List<int>());
                ms[suf].Add(w);
            }
        }
    }
    // O(N)
    public int F2(string prefix, string suffix) {
        if (!mp.ContainsKey(prefix) || !ms.ContainsKey(suffix)) return -1;
        List<int> pre = mp[prefix], suf = ms[suffix];
        int i = pre.Count - 1, j = suf.Count - 1;
        while (i >= 0 && j >= 0) {
            if (pre[i] < suf[j]) --j;
            else if (suf[j] < pre[i]) --i;
            return pre[i];
        }
        return -1;
    }
}

public class WordFilter {
    Dictionary<string, int> wordDict = new Dictionary<string, int>();
    // O(N * L^2)
    public WordFilter(string[] words)
    {
        for (int w = 0; w < words.Length; w++)
        {
            string word = words[w];
            for (int i = 0; i <= word.Length; i++)
            {
                for (int j = 0; j <= word.Length; j++){
                    // c# substring is start_index and length, not the end index
                    string key = word.Substring(0, i) + "#" + word.Substring(word.Length - j);

                    // [] if duplicated, then update
                    // add if duplicated, then throw exception                         
                    wordDict[key] = w; 
                }                    
            }
        }
    }
    // O(1)
    public int F(string prefix, string suffix)
    {
        return wordDict.ContainsKey(prefix + "#" + suffix) ? wordDict[prefix + "#" + suffix] : -1;            
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */
