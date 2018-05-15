using System;
using System.Collections.Generic;
using System.Linq;

namespace wordLadder2
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            List<string> words = new List<string>(){"hot","dot","dog","lot","log","cog"};
            Console.WriteLine("word ladder");
            var res = obj.FindLadders("hit", "cog", words);
            foreach(var r in res){
                Console.WriteLine(string.Join(",", r));
            }                 
        }
    }
    public class Solution {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
            HashSet<string> dict = new HashSet<string>(wordList);
            List<IList<string>> res = new List<IList<string>>();
            Queue<List<string>> q = new Queue<List<string>>();
            List<string> path = new List<string>();
            HashSet<string> visited = new HashSet<string>();            
            path.Add(beginWord);
            q.Enqueue(path);
            int level = 1, minLevel = Int32.MaxValue;
            
            while(q.Count != 0){
                List<string> p = q.Dequeue();
                if(p.Count > level){
                    foreach(string w in visited) dict.Remove(w);
                    visited.Clear();
                    level = p.Count;    
                } 
                if(level > minLevel) break;
                string last = p.Last();
                for (int i = 0; i < last.Length; ++i) {
                    char[] newChars = last.ToCharArray();
                    for (char ch = 'a'; ch <= 'z'; ++ch) {
                        newChars[i] = ch;
                        string newLast = new string(newChars);
                        if(!dict.Contains(newLast)){
                            continue;
                        }
                        else {
                            // remove visited word from dict later
                            visited.Add(newLast);
                            // need a new path obj
                            List<string> nextPath = new List<string>(p);
                            nextPath.Add(newLast);
                            if (newLast == endWord) {
                                res.Add(nextPath);
                                minLevel = level;
                            }
                            else{
                                q.Enqueue(nextPath);     
                            }
                        }
                    }                
                }
            }
            return res;
        }
    }
}
