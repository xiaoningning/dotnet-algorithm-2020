public class Solution {
    public IList<IList<string>> WordSquares(string[] words) {
        var res = new List<IList<string>>();
        var m = new Dictionary<string, List<string>>();
        int n = words[0].Length;
        foreach (string word in words) {
            for (int i = 0; i < n; ++i) {
                string key = word.Substring(0, i);
                if (!m.ContainsKey(key)) m.Add(key, new List<string>());
                m[key].Add(word);
            }
        }
        var mat = new List<List<char>>();
        Helper(0, n, mat, m, res);
        return res;
    }
    void Helper(int i, int n, List<List<char>> mat, Dictionary<string, List<string>> m, List<List<string>> res) {
        if ( i == n) {
            foreach (var c in mat) res.Add(new string(c.ToArray()));
            return;
        }
        string key = new string(mat[i].ToArray()).Substring(0,i);
        foreach (string str in m[key]) { 
            mat[i].Add(new List<char>());
            mat[i][i] = str[i];
            int j = i + 1;
            for (; j < n; ++j) {
                mat[i][j] = str[j];
                mat[j][i] = str[j];
                var t = new string(mat[j].ToArray()).Substring(0,i+1);
                if (!m.ContainsKey(t)) break;
            }
            if (j == n) Helper(i + 1, n, mat, m, res);
        }
    }
}

// trie to search
public class TrieNode {
    // only a-z
    public TrieNode[] children = new TrieNode[26];
    public bool word = false; 
    public List<string> prefix = new List<string>();
    public TrieNode(){}
}

public class Trie {
    private TrieNode root;

    /** Initialize your data structure here. */
    public Trie() {
        root = new TrieNode();
    }

    /** Inserts a word into the trie. */
    public void Insert(string word) {
        TrieNode node = root;
        foreach (char c in word.ToCharArray()) {
            if (node.children[c - 'a'] == null) {
                node.children[c - 'a'] = new TrieNode();
            }
            node = node.children[c - 'a'];
            prefix.Add(word);
        }
        node.word = true;
    }
}
