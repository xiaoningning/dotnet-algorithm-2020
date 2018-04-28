using System;
using System.Collections.Generic;

namespace alienDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string[] words = new string[]{"wrt", "wrf", "er", "ett", "rftt"};
            Console.WriteLine("Alien Dict Order: {0}", obj.AlienOrder(words));
        }
    }
    public class Solution {
        public string AlienOrder(string[] words) {
            int[] degree = new int[256];
            List<List<char>> pairs = new List<List<char>>();
            HashSet<char> chars = new HashSet<char>();
            Queue<char> q = new Queue<char>();
            string res = "";
            
            foreach(string w in words){
                foreach(char c in w){
                    chars.Add(c);
                }    
            }
            
            for (int i = 0; i < words.Length - 1; ++i) {
                int minLen = Math.Min(words[i].Length, words[i + 1].Length);
                for (int j = 0; j < minLen; ++j) {
                    if (words[i][j] != words[i + 1][j]) {
                        pairs.Add(new List<char>(){words[i][j], words[i + 1][j]});
                        break;
                    }
                }            
            }
            
            foreach(var p in pairs) degree[p[1]]++;
            foreach (var c in chars) {
                if (degree[c] == 0) {
                    q.Enqueue(c);
                    res += c;
                } 
            }
            while (q.Count != 0) {
                char c = q.Dequeue();
                foreach (var a in pairs) {
                    if (a[0] == c) {
                        --degree[a[1]];
                        if (degree[a[1]] == 0) {
                            q.Enqueue(a[1]);
                            res += a[1];
                        }
                    }
                }
            }
            return res.Length == chars.Count ? res : "";
        }
    }
}
