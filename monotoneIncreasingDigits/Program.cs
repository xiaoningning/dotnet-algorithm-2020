using System;
using System.Text;

namespace monotoneIncreasingDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input number: {0}", args[0]);
            int n = Int32.Parse(args[0]);
            Console.WriteLine("monotone digits: {0}", monotoneIncreasingDigits(n));
        }

        static int monotoneIncreasingDigits(int N) {
            
            // use StringBuilder for changing char value
            StringBuilder sb = new StringBuilder(N.ToString());
            int n = sb.Length, j = n;
            for (int i = n - 1; i > 0; i--) {
                if (sb[i - 1] <= sb[i]) continue;
                else {
                    sb[i -1]--;
                    j = i;
                }
            }        
            for (int i = j; i < n; ++i) {
                sb[i] = '9';
            }
            return Int32.Parse(sb.ToString());
        }
    }
}
