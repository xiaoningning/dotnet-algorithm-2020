using System;
using System.Collections.Generic;

namespace LRU
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache obj = new LRUCache(2);
            obj.Put(1,1);
            obj.Put(2,2);
            int param_1 = obj.Get(1);
            Console.WriteLine("LRU {0}", param_1);
            obj.Put(3,3);            
            param_1 = obj.Get(3);
            Console.WriteLine("LRU {0}", param_1);
        }
    }
    public class LRUCache {
        private int capacity = 0;
        private List<int> orderKey = new List<int>();
        private Dictionary<int, int> cache = new Dictionary<int, int>();
        public LRUCache(int capacity) {
            this.capacity = capacity;    
        }
        
        public int Get(int key) {
            if (!cache.ContainsKey(key)) return -1;
            else {
                orderKey.Remove(key);
                orderKey.Insert(0,key);
                return cache[key];        
            }        
        }
        
        public void Put(int key, int value) {
            if (capacity <= 0) return;
            if (Get(key) != -1){
                cache[key] = value;
                return;
            }
            else {
                if (cache.Count == capacity){
                    cache.Remove(orderKey[orderKey.Count-1]);
                    orderKey.RemoveAt(orderKey.Count-1);
                }
                cache.Add(key, value);
                orderKey.Insert(0,key);            
            }        
        }
    }
}
