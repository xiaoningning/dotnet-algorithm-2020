/* The Read4 API is defined in the parent class Reader4.
      int Read4(char[] buf); */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Maximum number of characters to read
     * @return    The number of characters read
     */
    
    private int tmpBuffPtr = 0;
    private int tmpBuffCnt = 0;
    private char[] tmpBuff = new char[4];
    
    public int Read(char[] buf, int n) {
        int ptr = 0;
        while (ptr < n) {
            if (tmpBuffPtr == 0) {
                tmpBuffCnt = Read4(tmpBuff);
            }
            if (tmpBuffCnt == 0) break;
            while (ptr < n && tmpBuffPtr < tmpBuffCnt) {
                buf[ptr++] = tmpBuff[tmpBuffPtr++];
            }
            if (tmpBuffPtr >= tmpBuffCnt) tmpBuffPtr = 0;
        }
        return ptr;        
    }
}


