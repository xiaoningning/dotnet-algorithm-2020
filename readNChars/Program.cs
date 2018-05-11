using System;

namespace readNChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            string s = "abcde";
            int n = obj.Read(s.ToCharArray(), 5);
            Console.WriteLine("Read N chars: {0}", s.Substring(0,n));
        }
    }
    public class Solution {
        /**
        * @param buf Destination buffer
        * @param n   Maximum number of characters to read
        * @return    The number of characters read
        */
        public int Read(char[] buf, int n) {
            int t = Read4(buf);
            if (t >=n) return n;
            else if (t < 4) return t;
            else{
                char[] tmp = new char[buf.Length-4];
                Array.Copy(buf, 4, tmp, 0, buf.Length-4);            
                return 4 + Read(tmp, n-4);
            }
        }
        int Read4(char[] buf){
            int n = buf.Length;
            if(n >= 4) return 4;
            else return n;
        }
    }
}
