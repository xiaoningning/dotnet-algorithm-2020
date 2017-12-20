using System;
using System.Collections.Generic;

namespace prefixSuffixSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input: {0}", args[0]);
            string[] words = args[0].Split(',');
            WordFilter wf = new WordFilter(words);
            
            Console.WriteLine("input prefix, suffix");
            string fix = Console.ReadLine();
            string prefix = fix.Split(',')[0];
            string suffix = fix.Split(',')[1];
            Console.WriteLine("weight: {0}", wf.F(prefix, suffix));
            
            // Console.WriteLine("weight: {0}", wf.F("apple", ""));
        }
    }
    public class WordFilter
    {
        Dictionary<string, int> wordDict = new Dictionary<string, int>();
        public WordFilter(string[] words)
        {
            for (int w = 0; w < words.Length; w++)
            {
                string word = words[w];
                for (int i = 0; i <= word.Length && i <= 10; i++)
                {
                    for (int j = 0; j <= word.Length && j <= 10; j++){
                        // c# substring is start_index and length, not the end index
                        string key = word.Substring(0, i) + "#" + word.Substring(word.Length - j);
                        // [] if duplicated, then update
                        // add if duplicated, then throw exception                         
                        wordDict[key] = w; 
                    }                    
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            return wordDict.ContainsKey(prefix + "#" + suffix) ? wordDict[prefix + "#" + suffix] : -1;            
        }
    }
}
