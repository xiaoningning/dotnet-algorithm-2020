/* The Read4 API is defined in the parent class Reader4.
      int Read4(char[] buf); */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Maximum number of characters to read
     * @return    The number of characters read
     */
    public int Read(char[] buf, int n) {
        char[] tBuf = new char[4];
        int res = 0;
        while(true){
            int cnt = Read4(tBuf);
            for(int i = 0; i < cnt; i++){
                // n could be 0
                if (res == n) return res;                
                buf[res] = tBuf[i];
                res++;                
            }
            if (cnt < 4) return res;
        }
    }
}
