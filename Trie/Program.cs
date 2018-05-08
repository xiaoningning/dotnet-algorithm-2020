using System;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie obj = new Trie();
            obj.Insert("word");
            bool param_2 = obj.Search("word");
            Console.WriteLine("Trie {0}", param_2);
            bool param_3 = obj.StartsWith("prefix");
            Console.WriteLine("Trie {0}", param_3);
            bool param_4 = obj.StartsWith("wor");
            Console.WriteLine("Trie {0}", param_4);
        }
    }
    public class Trie {
        public class TrieNode {
            // only a-z
            public TrieNode[] children = new TrieNode[26];
            public bool word = false; 
            public TrieNode(){}
        }

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
            }
            node.word = true;
        }
        
        /** Returns if the word is in the trie. */
        public bool Search(string word) {
            return StartsWith(word.ToCharArray(), true);    
        }
        
        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix) {
            return StartsWith(prefix.ToCharArray(), false);    
        }
        
        private bool StartsWith(char[] chars, bool isWord){
            TrieNode p = root;
            foreach(char c in chars){
                if (p.children[c - 'a'] == null) return false;
                else p = p.children[c - 'a'];    
            }
            return isWord ? p.word :true;
        }    
    }
}
