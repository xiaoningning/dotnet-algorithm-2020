using System;
using System.Collections.Generic;

namespace removeInvalidParanth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"example: (a)())() -> [(a)()(), (a())()]");
            Console.WriteLine("Input string of parenthesis: {0}", args[0]);
            Console.WriteLine("Reselt: ");
            var res = RemoveInvalidParentheses(args[0]);
            foreach (var s in res)
            {
                Console.WriteLine(s);
            }
        }

        public static IList<string> RemoveInvalidParentheses(string s)
        {
            List<string> res = new List<string>();
            HashSet<string> visited = new HashSet<string>();
            Queue<string> q = new Queue<string>();
            q.Enqueue(s);
            bool found = false;
            while (q.Count > 0)
            {
                string str = q.Dequeue();
                if (isValid(str))
                {
                    res.Add(str);
                    found = true;
                }

                if (found) continue;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != ')' && str[i] != '(') continue;
                    string t = str.Substring(0, i) + str.Substring(i + 1);
                    if (!visited.Contains(t))
                    {
                        visited.Add(t);
                        q.Enqueue(t);
                    }

                }
            }

            return res;
        }

        static bool isValid(string t)
        {
            int cnt = 0;
            for (int i = 0; i < t.Length; ++i)
            {
                if (t[i] == '(') ++cnt;
                else if (t[i] == ')' && --cnt < 0) return false;
            }
            return cnt == 0;
        }
    }
}
