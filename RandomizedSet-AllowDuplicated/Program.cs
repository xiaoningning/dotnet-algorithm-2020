using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizedSet_AllowDuplicated
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomizedCollection obj = new RandomizedCollection();
            obj.Insert(5);
            obj.Insert(2);
            obj.Insert(3);
            obj.Insert(2);
            Console.WriteLine("RandomizedSet remove {0}", obj.Remove(3));
            Console.WriteLine("RandomizedSet getRandom {0}", obj.GetRandom());
        }
    }
    public class RandomizedCollection {
        List<int> nums;
        Dictionary<int, SortedDictionary<int, int>> map;
        Random ran;

        /** Initialize your data structure here. */
        public RandomizedCollection() {
            nums = new List<int>();
            map = new Dictionary<int, SortedDictionary<int, int>>();
            ran = new Random();
        }
        
        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. 
        * still insert duplicated val
        */
        public bool Insert(int val) {
           if (!map.ContainsKey(val)) map.Add(val, new SortedDictionary<int, int>());

            nums.Add(val);
            map[val].Add(nums.Count -1, 0); // 0 is dummy
            return map[val].Count == 1;            
        }
        
        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val) {
            if(!map.ContainsKey(val)) return false;
            
            int last = nums[nums.Count - 1];
            int indexVal = map[val].Last().Key;
            map[last].Remove(nums.Count - 1);
            map[last].Add(indexVal, 0);
            nums[indexVal] = last;
            map[val].Remove(indexVal);
            nums.RemoveAt(nums.Count-1);
            return true;
        }
        
        /** Get a random element from the set. */
        public int GetRandom() {            
            return nums[ran.Next(nums.Count)];
        }
    }
}
