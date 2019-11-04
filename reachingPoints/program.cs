public class Solution {
    public bool ReachingPoints(int sx, int sy, int tx, int ty) {
        // backward from t to s.
        // backward to root is only one way
        // from start to target, many possibility to count
        // using % mod => ty -= tx, tx -= ty
        while (sx < tx && sy < ty)
            if (tx < ty) ty %= tx;
            else tx %= ty;
        // O(logN) where N = max(tx,ty)
        return sx == tx && sy <= ty && (ty - sy) % sx == 0 ||
               sy == ty && sx <= tx && (tx - sx) % sy == 0;
    }
}
