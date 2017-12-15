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
            Console.WriteLine("output: {0}", DepthSum(nl));

        }

        public static int DepthSum(IList<NestedInteger> nestedList) {
            return DepthSum(nestedList, 1);
        }  

        public static int DepthSum(IList<NestedInteger> nestedList, int level) {
            int sum = 0;            
            foreach(var ni in nestedList){
                sum += ni.IsInteger() ? ni.GetInteger() * level : DepthSum(ni.GetList(), level + 1);                
            }            
            return sum;
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
