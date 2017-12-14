using System;
using System.Collections.Generic;

namespace nestedListWeightSum2
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<NestedInteger> nl = new List<NestedInteger>();
            Console.WriteLine("input list x,y,z or int or x (exit input):");
            
            while(true){
                var l = Console.ReadLine();
                if (l.Equals("x")) break;
                else {
                    if (l.Split(',').Length == 1){
                        nl.Add(new NestedIntList(Int32.Parse(l)));
                    }
                    else {
                        var tlist = new List<int>();
                        foreach(var s in l.Split(',')){
                            tlist.Add(Int32.Parse(s));
                        }
                        nl.Add(new NestedIntList(tlist)); 
                    }
                }            
            }
            
            // nl.Add(new NestedIntList(2));
            // nl.Add(new NestedIntList(new List<int>(new int[]{ 2, 3, 7 })));
            Console.WriteLine("output: {0}", DepthSumInverse2(nl));

        }

        public static int DepthSumInverse2(IList<NestedInteger> nestedList) {
            int weighted = 0, unweighted = 0;
            while (nestedList.Count != 0){
                List<NestedInteger> nextLevel = new List<NestedInteger>();
                foreach(var ni in nestedList){
                    if (ni.IsInteger()){
                        unweighted += ni.GetInteger();
                    }
                    else {
                        nextLevel.AddRange(ni.GetList());
                    }
                }
                weighted += unweighted;
                nestedList = nextLevel;
            }
            return weighted;
        }

        public static int DepthSumInverse(IList<NestedInteger> nestedList) {
            Queue<List<int>> q = FlattedQueue(nestedList, new Queue<List<int>>());
            int sum = 0;
            while(q.Count != 0){
                int levelWeight = q.Count;
                var list = q.Dequeue();
                int levelSum = 0;
                foreach(int n in list){
                    levelSum += n;
                }
                sum += levelSum * levelWeight;
            }
            return sum;
        }

        public static Queue<List<int>> FlattedQueue(IList<NestedInteger> nestedList, Queue<List<int>> q){            
            var t = new List<int>();
            List<NestedInteger> tnl = new List<NestedInteger>();
            foreach(var ni in nestedList){
                if(ni.IsInteger()){
                    t.Add(ni.GetInteger());  
                } 
                else {
                    tnl.AddRange(ni.GetList());
                }
            }
            q.Enqueue(t);
            if (tnl.Count > 0) FlattedQueue(tnl, q);
            return q;
        }
    }

    public interface NestedInteger {
 
       // @return true if this NestedInteger holds a single integer, rather than a nested list.
       bool IsInteger();
  
       // @return the single integer that this NestedInteger holds, if it holds a single integer
       // Return null if this NestedInteger holds a nested list
       int GetInteger();
  
       // Set this NestedInteger to hold a single integer.
       // public void SetInteger(int value);
  
       // Set this NestedInteger to hold a nested list and adds a nested integer to it.
       // public void Add(NestedInteger ni);
  
       // @return the nested list that this NestedInteger holds, if it holds a nested list
       // Return null if this NestedInteger holds a single integer
       IList<NestedInteger> GetList();
    }

    public class NestedIntList : NestedInteger {
        IList<NestedInteger> list;
        int x;
        bool isInt; 

        public NestedIntList (List<int> nestedIntList){
            list = new List<NestedInteger>();
            foreach( int i in nestedIntList){
                list.Add(new NestedIntList(i));
            }            
            isInt = false;
        }
        
        public NestedIntList(){
            // list = new List<NestedInteger>();    
        }

        public NestedIntList(int element){
            x = element;
            isInt = true;
            list = null;
        }

        public IList<NestedInteger> GetList(){
            if (isInt) return null;            
            else return list;
        }
        public void SetInteger(int value) {
            x = value;
            isInt = true;
        }
        public int GetInteger() {
            if (isInt) return x;
            else return -999;           
        }
        public void Add(NestedInteger ni) {
            list.Add(ni);
        }
        public bool IsInteger() {
            return isInt;
        }
    }
}
