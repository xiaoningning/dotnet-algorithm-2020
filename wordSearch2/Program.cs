public class Solution {
    public IList<string> FindWords(char[][] board, string[] words) {
        List<string> res = new List<string>();
        if(words.Length == 0 || board.Length == 0) return res;
        int m = board.GetLength(0);
        int n = board[0].GetLength(0);  
        // n # of keys
        // m len of key
        // serach trie: O(m) 
        // make trie: O(n*m)
        Trie t = new Trie();
        foreach(string s in words) t.Insert(s);
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(t.root.children[board[i][j] - 'a'] != null){
                    WordSearch(board, t.root.children[board[i][j] - 'a'], i, j, res);    
                } 
            }
        }
        res.Sort();
        return res;
    }
    void WordSearch(char[][] board, TrieNode t, int i, int j, List<string> res){
        if(!string.IsNullOrEmpty(t.word)) {
            res.Add(new string(t.word.ToCharArray()));
            // clear this so this trie path has been found
            t.word = string.Empty;
            // no return, continue searching a longer word
        }
        int m = board.GetLength(0);
        int n = board[0].GetLength(0);   
        char c = board[i][j];
        board[i][j] = '#';
        int[,] dirs = new int[,]{{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
        for(int x = 0; x < 4; x++){
            int ni = i + dirs[x,0], nj = j + dirs[x,1];
            if (ni >= 0 && nj >= 0 
                && ni < m && nj < n 
                && board[ni][nj] != '#'
                && t.children[board[ni][nj] - 'a'] != null){
                WordSearch(board, t.children[board[ni][nj] - 'a'], ni, nj, res);    
            }
        }
        board[i][j] = c;                
    }
    
    public class TrieNode {
        // only a-z
        public TrieNode[] children = new TrieNode[26];
        public string word = null; 
        public TrieNode(){}
    }

    public class Trie {
        public TrieNode root;
        
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
            }
            node.word = word;
        }
    }
}
