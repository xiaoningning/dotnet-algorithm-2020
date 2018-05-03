using System;

namespace addSearchWord
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDictionary obj = new WordDictionary();
            obj.AddWord("bad");
            obj.AddWord("dad");
            Console.WriteLine("search word pad {0}", obj.Search("pad"));
            Console.WriteLine("search word bad {0}", obj.Search("bad"));
            Console.WriteLine("search word .ad {0}", obj.Search(".ad"));
            Console.WriteLine("search word b.. {0}", obj.Search("b.."));
        }
    }

    public class WordDictionary {
        public class TrieNode {
            public TrieNode[] children = new TrieNode[26];
            public bool word = false; 
            public TrieNode(){}
        }
        
        private TrieNode root;
        
        /** Initialize your data structure here. */
        public WordDictionary() {
            root = new TrieNode();
        }
        
        /** Adds a word into the data structure. */
        public void AddWord(string word) {
            TrieNode node = root;
            foreach (char c in word.ToCharArray()) {
                if (node.children[c - 'a'] == null) {
                    node.children[c - 'a'] = new TrieNode();
                }
                node = node.children[c - 'a'];
            }
            node.word = true;
        }
        
        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word) {
            return Match(word.ToCharArray(), 0, root);
        }
        
        private bool Match(char[] word, int k, TrieNode node){
            if(k == word.Length) return node.word;
            if(word[k] != '.'){
                return node.children[word[k] - 'a'] != null && Match(word, k+1, node.children[word[k] - 'a']);
            }
            else{
                for (int i = 0; i < node.children.Length; i++) {
                    if (node.children[i] != null){
                        if(Match(word, k + 1, node.children[i])){
                            return true;
                        }   
                    }
                }
            }
            return false;
        }
    }
}
