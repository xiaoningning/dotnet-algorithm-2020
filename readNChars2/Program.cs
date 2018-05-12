using System;

namespace readNChars2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("read n chars 2 does nothing here");
            Console.WriteLine("read n chars 2 in OJ works");
        }
    }
    /* The Read4 API is defined in the parent class Reader4.
        int Read4(char[] buf); */

    public class Solution {
        /**
            * @param buf Destination buffer
            * @param n   Maximum number of characters to read
            * @return    The number of characters read
            */
        public int Read(char[] buf, int n) {
            for(int i = 0; i < n; i++){
                if(readPos == writePos){
                    // each writePos <= 4
                    writePos = Read4(tmp);
                    // reset read
                    readPos = 0;
                    // all source buf is read out. no more
                    if(writePos == 0) return i;
                }
                buf[i] = tmp[readPos++];
            }
            return n;
        }
        // once read4, source is gone into tmp from the file
        // keep it for next Read
        private char[] tmp = new char[4];
        private int readPos = 0, writePos = 0;

        int Read4(char[] buf){
            int n = buf.Length;
            if(n >= 4) return 4;
            else return n;
        }
    }
}
