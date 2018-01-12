using System;
using System.Collections.Generic;

namespace ExclusiveTimeFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            n = 2
            logs = 
            ["0:start:0",
            "1:start:2",
            "1:end:5",
            "0:end:6"]
            Output:[3, 4]
             */
            Console.WriteLine("function list: {0}", args[0]);
            // function logs is sorted on the time
            List<string> logs = new List<string>(args[0].Split(','));
            int n = Int32.Parse(args[1]);
            Console.WriteLine("# of functions: {0}", n);
            Console.WriteLine("exclusive time: {0}", string.Join(",", ExclusiveTime(n, logs)));
        }

        static int[] ExclusiveTime(int n, IList<string> logs) {
            int[] res = new int[n];
            // function id 
            Stack<int> stk = new Stack<int>();
            int presTime = 0;
            foreach (string log in logs)
            {
                string[] f = log.Split(':');
                int fId = Int32.Parse(f[0]);
                string type = f[1];
                int time = Int32.Parse(f[2]);
                if (stk.Count !=0 ){
                    res[stk.Peek()] += time - presTime;
                }
                presTime = time;
                if (type == "start") stk.Push(fId);
                else{
                    res[stk.Peek()]++;
                    presTime++;
                    stk.Pop();
                }
            }

            return res;
        }
    }
}
