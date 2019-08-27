public class Solution {
    public int[][] SpiralMatrixIII2(int R, int C, int r0, int c0) {
        int[][] res = new int[R * C][];
        int dx = 0, dy = 1, len = 0, tmp;
        for (int j = 0; j < R * C; ++len) {
            for (int i = 0; i < len / 2 + 1; ++i) {
                if (0 <= r0 && r0 < R && 0 <= c0 && c0 < C)
                    res[j++] = new int[] {r0, c0};
                r0 += dx;
                c0 += dy;
            }
            tmp = dx;
            dx = dy;
            dy = -tmp;
        }
        return res;
    }
    public int[][] SpiralMatrixIII(int R, int C, int r0, int c0) {
        int[][] res = new int[R * C][];
        int[][] dirt = new int[4][];
        // east, south, west, north
        dirt[0] = new int[] {0,1};
        dirt[1] = new int[] {1,0};
        dirt[2] = new int[] {0,-1};
        dirt[3] = new int[] {-1,0};
        // move <len> steps in the <d> direction
        int len = 0, d = 0; 
        //int dx = 0, dy = 1, n = 0, tmp;
        for (int j = 0; j < R * C;) {
            // when move east or west, the length of path need plus 1 
            if (d == 0 || d == 2) len++; 
            for (int i = 0; i < len ; ++i) {
                if (0 <= r0 && r0 < R && 0 <= c0 && c0 < C)
                    res[j++] = new int[] {r0, c0};
                r0 += dirt[d][0];
                c0 += dirt[d][1];
            }
            d = (d + 1) % 4; // turn to next direction
        }
        return res;
    }
}
