using System;
using System.Collections.Generic;

namespace ipToCIDR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input IP: {0}", args[0]);
            Console.WriteLine("# of Ips Coverage: {0}", args[1]);
            Console.WriteLine("output IP: {0}", string.Join(",", IpToCIDR(args[0], Int32.Parse(args[1]))));
        }
        
        static IList<string> IpToCIDR(string ip, int n) {
            List<string> ans = new List<string>();
            long startIp = IpToLong(ip);
            while (n > 0) {
                int mask = Math.Max(33 - BitLength(startIp & -startIp),
                                    33 - BitLength(n));
                ans.Add(LongToIP(startIp) + "/" + mask);
                startIp += 1 << (32 - mask);
                n -= 1 << (32 - mask);
            }
            return ans;
        }

        static long IpToLong(string ip) {
            long ans = 0;
            foreach (string x in ip.Split('.')) {
                ans = 256 * ans + Int32.Parse(x);
            }
            return ans;
        }

        static string LongToIP(long x) {
            return string.Format("{0}.{1}.{2}.{3}",
                x >> 24, (x >> 16) & 255, (x >> 8) & 255, x & 255);
        }

        static int BitLength(long x) {
            if (x == 0) return 1;
            int ans = 0;
            while (x > 0) {
                x >>= 1;
                ans++;
            }
            return ans;
        }
    }
}
