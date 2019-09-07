using System;
using System.Collections.Generic;

namespace flattedNestedList
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<NestedInteger> nl = new List<NestedInteger>();
            Console.WriteLine("input list or int or x (exit input):");
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

            var ni = new NestedIterator(nl);
            Console.WriteLine("output: ");
            while(ni.HasNext()){
                Console.Write("{0} ", ni.Next());
            }
        }
    }
    public class NestedIterator {

        Stack<NestedInteger> stack = new Stack<NestedInteger>();
        public NestedIterator(IList<NestedInteger> nestedList){            
            for(int i = nestedList.Count - 1; i >= 0; i--){
                stack.Push(nestedList[i]);                
            }
        }
        public bool HasNext(){
            while(stack.Count != 0){
                NestedInteger curr = stack.Peek();

                if(curr.IsInteger()) return true;
                else {
                    stack.Pop();
                    var currList = curr.GetList();
                    for(int i = currList.Count - 1; i >= 0; i--){
                        stack.Push(currList[i]);                
                    }
                }
            }
            return false;
        }

        public int Next(){            
            return HasNext() ? stack.Pop().GetInteger() : -999;
        }

    }

    public interface NestedInteger {

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();
        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();
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

        public NestedIntList (int element){
            x = element;
            isInt = true;
            list = null;
        }

        public IList<NestedInteger> GetList(){
            if (isInt) return null;            
            else return list;
        }

        public int GetInteger() {
            if (isInt) return x;
            else return -999;           
        }

        public bool IsInteger() {
            return isInt;
        }
    }

}
