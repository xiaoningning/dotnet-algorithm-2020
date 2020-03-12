public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Array.Sort(products);
        var res = new List<IList<string>>();
        var root = new Trie();
        // Initialization: Sum(len(products[i]))
        foreach (var p in products) root.Insert(root, p);
        // Query: O(len(searchWord))
        return root.GetWords(root, searchWord);
    }
        // c# does not have lower / upper bound
    public IList<IList<string>> SuggestedProducts1(string[] products, string searchWord) {
        Array.Sort(products);
        var res = new List<IList<string>>();
        string cur = "";
        int lower = 0, upper = 0, n = searchWord.Length;
        foreach (var c in searchWord) {
            cur += c;
            var t = new List<string>();
            res.Add(t);
            int idx = Array.BinarySearch(products, cur);
            if (idx >= 0) lower = idx;
            else {
                Console.WriteLine(~idx);
                //if (~idx == 0 || ~idx == n) break;
                lower = ~idx == 0 ? 0 : ~idx - 1;
                upper = ~idx == n ? n - 1: ~idx;
            }
            for (int i = lower; i <= Math.Min(lower + 2, n - 1); i++) res.Last().Add(products[i]);
        }
        while (res.Count < searchWord.Length) res.Add(new List<string>());
        return res;
    }
}
public class Trie {
    public HashSet<string> words = new HashSet<string>();
    public Trie[] next = new Trie[26];
    public void Insert(Trie root, string w) {
        var node = root;
        foreach (var c in w) {
            if (node.next[c - 'a'] == null) node.next[c - 'a'] = new Trie();
            node = node.next[c - 'a'];
            if (node.words.Count < 3) node.words.Add(w);   
        }
    }
    public List<IList<string>> GetWords(Trie node, string prefix) {
        var res = new List<IList<string>>();
        int size = prefix.Length;
        while (size-- > 0) res.Add(new List<string>());
        for(int i = 0; i < prefix.Length; i++) {
            node = node.next[prefix[i] - 'a'];
            if (node == null) break;
            foreach (var w in node.words) res[i].Add(w);
        }
        return res;
    }
} 
