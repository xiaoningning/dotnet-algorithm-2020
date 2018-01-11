using System;

namespace taskScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input task: {0}", args[0]);
            char[] tasks = args[0].Replace(",", "").ToCharArray();
            int n = Int32.Parse(args[1]);
            Console.WriteLine("Interval: {0}", n);
            Console.WriteLine("Total CPU intervals: {0}", LeastInterval(tasks, n));
        }

        static int LeastInterval(char[] tasks, int n) {
            int[] cntMap = new int[26];
            foreach (char c in tasks)
            {   
                cntMap[c - 'A']++;
            }
            Array.Sort(cntMap);
            int maxCnt = cntMap[25] - 1, idleSlot = maxCnt * n;
            for(int i = 24; i >= 0; i--){
                idleSlot -= Math.Min(cntMap[i], maxCnt);
            }
            return idleSlot > 0 ? tasks.Length + idleSlot : tasks.Length;
        }
    }
}
