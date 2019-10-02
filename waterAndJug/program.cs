public class Solution {
    public bool CanMeasureWater(int x, int y, int z) {
        return z == 0 || (x + y >= z && z % gcd(x, y) == 0);
    }
    
    int gcd(int a, int b) {
        return a == 0 ? b : gcd(b % a, a);
    }
}
