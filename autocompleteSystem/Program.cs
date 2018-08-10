using System;
using System.Collections.Generic;
using System.Linq;

namespace autocompleteSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sentences = new string[] {
                "abc",
                "abbc",
                "a"
            };
            int[] times = new int[]{3,3,3};
            /*
            string[] sentences = new string[] {
                "i love you",
                "island",
                "ironman",
                "i love leetcode"
            };
            int[] times = new int[]{5,3,2,2};
            AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
            IList<string> param_1 = obj.Input('i');
            Console.WriteLine("AutocompleteSystem: {0}", string.Join(";", param_1));
            IList<string> param_0 = obj.Input(' ');
            Console.WriteLine("AutocompleteSystem: {0}", string.Join(";", param_0));
            IList<string> param_2 = obj.Input('a');
            Console.WriteLine("AutocompleteSystem: {0}", string.Join(";", param_2));
            IList<string> param_3 = obj.Input('#');
            Console.WriteLine("AutocompleteSystem: {0}", string.Join(";", param_3));
             */
            AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
            IList<string> param_1 = obj.Input('a');
            Console.WriteLine("AutocompleteSystem: {0}", string.Join(";", param_1));
            IList<string> param_0 = obj.Input('b');
            Console.WriteLine("AutocompleteSystem: {0}", string.Join(";", param_0));
            IList<string> param_2 = obj.Input('c');
            Console.WriteLine("AutocompleteSystem: {0}", string.Join(";", param_2));
            IList<string> param_3 = obj.Input('#');
            Console.WriteLine("AutocompleteSystem: {0}", string.Join(";", param_3));
            
        }
    }

    public class AutocompleteSystem {
        Dictionary<string, int> freq = new Dictionary<string, int>();
        string data = string.Empty;
        public AutocompleteSystem(string[] sentences, int[] times) {
            for (int i = 0; i < sentences.Length; ++i) {
                freq.Add(sentences[i], times[i]); 
            }            
        }
        
        public IList<string> Input(char c) {
            List<string> res = new List<string>();
            if (c == '#'){
                if (!freq.ContainsKey(data)) freq.Add(data, 0);
                freq[data]++;
                data = string.Empty;
                return res;
            }
            data += c;
            List<KeyValuePair<string, int>> sd = new List<KeyValuePair<string, int>>();
            foreach(var f in freq){
                bool matched = true;                
                for (int i = 0; i < data.Length; ++i) {
                    // sentence is shorter than input data
                    if (i >= f.Key.Length) matched = false;                    
                    else if (data[i] != f.Key[i]) {
                        matched = false;
                        break;
                    }
                }
                if (matched){
                    sd.Add(f);                    
                }
            }
            sd.Sort((a,b) => {
                int result = -a.Value.CompareTo(b.Value);
                if (result == 0) result = a.Key.CompareTo(b.Key);
                return result;
                });
            for (int i = 0; i < sd.Count && i < 3; i++ ){
                res.Add(sd[i].Key);
            }
            return res;
        }
    }
}
