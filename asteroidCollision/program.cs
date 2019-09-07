public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        var res = new List<int>();
        for (int i = 0; i < asteroids.Length; i++) {
            if (asteroids[i] > 0) res.Add(asteroids[i]);
            else if (!res.Any() || res.Last() < 0) res.Add(asteroids[i]);
            // asteroids[i] < 0 
            else if (res.Last() <= -asteroids[i]) {
                // keep asteroids[i]
                if (res.Last() < -asteroids[i]) i--;
                res.RemoveAt(res.Count - 1);
            }
            // if res.Last() > --asteroids[i], move next
        }
        return res.ToArray();
    }
}
