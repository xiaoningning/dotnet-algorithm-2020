using System;
using System.Collections.Generic;

namespace RandomizedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomizedSet obj = new RandomizedSet();
            obj.Insert(5);
            obj.Insert(2);
            Console.WriteLine("RandomizedSet remove {0}", obj.Remove(3));
            Console.WriteLine("RandomizedSet getRandom {0}", obj.GetRandom());
        }
    }
    public class RandomizedSet {
        List<int> nums;
        Dictionary<int, int> map;
        Random ran;

        /** Initialize your data structure here. */
        public RandomizedSet() {
            nums = new List<int>();
            map = new Dictionary<int, int>();
            ran = new Random();
        }
        
        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val) {
            if(map.ContainsKey(val)) return false;
            
            nums.Add(val);
            map[val] = nums.Count -1;
            return true;            
        }
        
        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val) {
            if(!map.ContainsKey(val)) return false;
            
            int last = nums[nums.Count - 1];
            map[last] = map[val];
            nums[map[val]] = last;
            map.Remove(val);
            nums.RemoveAt(nums.Count-1);
            return true;
        }
        
        /** Get a random element from the set. */
        public int GetRandom() {            
            return nums[ran.Next(nums.Count)];
        }
    }
}
