public class Solution {
    public string ReplaceWords(IList<string> dict, string sentence) {
        string res = "";
        TrieNode r = new TrieNode();
        foreach (var w in dict) Insert(r, w);
        foreach (var w in sentence.Split()) {
            if (res != "") res += " ";
            res += Find(r, w);
        }
        return res;
    }
    void Insert(TrieNode r, string w) {
        if (r == null) return;
        var node = r;
        foreach (var c in w) {
            if (node.children[c - 'a'] == null) node.children[c - 'a'] = new TrieNode();
            node = node.children[c - 'a'];
        }
        node.IsWord = true;
    }
    string Find(TrieNode n, string w) {
        string res = "";
        foreach (var c in w) {
            if (n.children[c - 'a'] == null) break;
            res += c;
            n = n.children[c - 'a'];
            if (n.IsWord) return res;
        }
        return w;
    }
}
public class TrieNode {
    public bool IsWord;
    public TrieNode[] children = new TrieNode[26];
    public TrieNode(){}
}
