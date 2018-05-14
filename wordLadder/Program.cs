using System;
using System.Collections.Generic;

namespace wordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            List<string> words = new List<string>(){"hot","dot","dog","lot","log","cog"};
            Console.WriteLine("word ladder");
            Console.WriteLine("{0}", obj.LadderLength("hit", "cog", words));            
        }
    }
    public class Solution {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
            HashSet<string> dict = new HashSet<string>(wordList);
            // foreach(string s in workdList) dict.Add(s);
            Dictionary<string, int> m = new Dictionary<string, int>();
            m.Add(beginWord, 1);
            Queue<string> q = new Queue<string>();
            q.Enqueue(beginWord);
            while(q.Count != 0){
                string word = q.Dequeue();
                for (int i = 0; i < word.Length; ++i) {
                    char[] newChars = word.ToCharArray();
                    for (char ch = 'a'; ch <= 'z'; ++ch) {
                        newChars[i] = ch;
                        string newWord = new string(newChars);
                        if(dict.Contains(newWord) && newWord == endWord) return m[word]+1;
                        if(dict.Contains(newWord) && !m.ContainsKey(newWord)) {
                            m.Add(newWord, m[word] + 1);
                            q.Enqueue(newWord);
                        }
                    }
                }
            }
            return 0;
        }
    }
}
