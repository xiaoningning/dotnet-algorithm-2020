public class Solution {
    public IList<IList<string>> WordSquares(string[] words) {
        var res = new List<IList<string>>();
        // key:prefix, value:word
        var m = new Dictionary<string, List<string>>();
        int n = words[0].Length;
        foreach (string word in words) {
            for (int i = 0; i < n; ++i) {
                string key = word.Substring(0, i);
                if (!m.ContainsKey(key)) m.Add(key, new List<string>());
                m[key].Add(word);
            }
        }
        var mat = new char[n,n];
        Helper(0, n, mat, m, res);
        return res;
    }
    void Helper(int i, int n, char[,] mat, Dictionary<string, List<string>> m, List<IList<string>> res) {
        if ( i == n) {
            List<string> t = new List<string>();
            for (int k = 0; k < mat.GetLength(0); k++) {
                string tstr = "";
                for (int j = 0; j < mat.GetLength(1); j++) {
                    tstr += mat[k,j];
                }
                t.Add(tstr); 
            } 
            res.Add(t);
            return;
        }
        string key = "";
        for (int k = 0; k < i; k++) key += mat[i,k];
        foreach (string str in m[key]) { 
            // mat[i].Add(new List<char>());
            mat[i,i]= str[i];
            int j = i + 1;
            for (; j < n; ++j) {
                mat[i,j] = str[j];
                mat[j,i] = str[j];
                var t = "";
                for (int k = 0; k < i+1; k++) t += mat[j,k];
                if (!m.ContainsKey(t.ToString())) break;
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
            node.prefix.Add(word);
            node = node.children[c - 'a'];
        }
        node.word = true;
    }
    
    public List<string> FindPrefix(string pre) {
        var res = new List<string>();
        TrieNode node = root;
        foreach (var c in pre.ToCharArray()) {
            if (node.children[c] == null) return res;
            node = node.children[c];
        }
        res.AddRange(node.prefix);
        return res;
    }
}
