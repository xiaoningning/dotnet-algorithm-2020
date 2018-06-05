using System;
using System.Text;
using System.Collections.Generic;

namespace textJustification
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string[] words = new string[]{"This", "is", "an", "example", "of", "text", "justification."};
            int l = 16;
            Console.WriteLine("Text Justification");
            var res = obj.FullJustify(words, l);
            foreach (var r in res)
            {
                Console.WriteLine(string.Join(',', r));
            }
        }
    }
    public class Solution {
        public IList<string> FullJustify(string[] words, int maxWidth) {
            List<string> res = new List<string>();
            int i = 0;
            while (i < words.Length){
                int cnt = words[i].Length;
                int last = i + 1;
                while (last < words.Length){
                    if (words[last].Length + cnt + 1 > maxWidth) break;
                    cnt += words[last].Length + 1;
                    last++;
                }
                
                StringBuilder sb = new StringBuilder();
                int diff = last - i - 1;
                // if last line or number of words in the line is 1, left-justified
                if (last == words.Length || diff == 0) {
                    for (int s = i; s < last; s++) {
                        sb.Append(words[s] + " ");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    for (int s = sb.Length; s < maxWidth; s++) {
                        sb.Append(" ");
                    }
                } 
                else {
                    // middle justified
                    int spaces = (maxWidth - cnt) / diff;
                    int r = (maxWidth - cnt) % diff;
                    for (int s = i; s < last; s++) {
                        sb.Append(words[s]);
                        if (s < last - 1) {
                            for (int j = 0; j <= (spaces + ((s - i) < r ? 1 : 0)); j++) {
                                sb.Append(" ");
                            }
                        }
                    }
                }
                res.Add(sb.ToString());
                i = last;            
            }
            return res;
        }
    }
}
