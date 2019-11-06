public class StreamChecker {
    TrieNode root;
    string q;
    int mxLen;
    public StreamChecker(string[] words) {
        root = new TrieNode();
        q = string.Empty;
        foreach (var w in words) {
            Insert(w);
            mxLen = Math.Max(mxLen, w.Length);
        }
    }
    
    // O(N*mxLen)
    public bool Query(char letter) {
        q += letter;
        // trim extra length, otherwise TLE
        while (q.Length > mxLen) q = q.Substring(1);
        TrieNode node = root;
        for (int i = q.Length - 1; i >= 0 && node != null; i--) {
            char c = q[i];
            node = node.next[c - 'a'];
            if (node != null && node.isWord) {
                return true;
            }
        }
        return false;
    }
    
    void Insert(string w) {
        TrieNode node = root;
        int len = w.Length;
        // reverse order
        for (int i = len - 1; i >= 0; i--) {
            char c = w[i];
            if (node.next[c - 'a'] == null) {
                node.next[c - 'a'] = new TrieNode();
            }
            node = node.next[c - 'a'];
        }
        node.isWord = true;
    }
}

public class TrieNode {
    public bool isWord;
    public TrieNode[] next = new TrieNode[26];
}


/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */
