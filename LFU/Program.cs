using System;
using System.Collections.Generic;

namespace LFU
{
    class Program
    {
        static void Main(string[] args)
        {
            LFUCache obj = new LFUCache(2);
            obj.Put(1,1);
            obj.Put(2,2);
            int param_1 = obj.Get(1);
            Console.WriteLine("LFU {0}", param_1);
            obj.Put(3,3);            
            param_1 = obj.Get(3);
            Console.WriteLine("LFU {0}", param_1);
        }
    }
    public class LFUCache {
        private int capacity = 0;
        private Dictionary<int, int> freq;
        private Dictionary<int, int> cache;
        private Dictionary<int, LinkedList<int>> freqMap;
        private int minFreq;
        public LFUCache(int capacity) {
            this.capacity = capacity;
            freq = new Dictionary<int, int>();
            cache = new Dictionary<int, int>();
            freqMap = new Dictionary<int, LinkedList<int>>();
            minFreq = 0;
        }
        
        public int Get(int key) {
            if(!cache.ContainsKey(key)) return -1;
            else {                                                              
                int cnt = freq[key];                
                freqMap[cnt].Remove(key);
                if (cnt == minFreq && freqMap[minFreq].Count == 0) minFreq++;
                cnt++;
                freq[key] = cnt;
                if (!freqMap.ContainsKey(cnt)) freqMap.Add(cnt, new LinkedList<int>());
                if (freqMap[cnt].Contains(key)) freqMap[cnt].Remove(key);
                freqMap[cnt].AddFirst(key);
                return cache[key];        
            }     
        }
        
        public void Put(int key, int value) {
            if (capacity <= 0) return;
            if (Get(key) != -1){
                cache[key] = value;                
            }
            else {
                if (cache.Count == capacity) {
                    int evitKey = freqMap[minFreq].Last.Value;
                    freqMap[minFreq].Remove(evitKey);
                    cache.Remove(evitKey);
                }
                cache.Add(key, value);
                minFreq = 1;
                freq[key] = minFreq;
                if (!freqMap.ContainsKey(minFreq)) freqMap.Add(minFreq, new LinkedList<int>());
                freqMap[minFreq].AddFirst(key);                
            }
        }
    }
}
