public class Vector2D {

    public Vector2D(int[][] v) {
        x = 0; y = 0;
        data = v;
    }
    
    public int Next() {
        var res = data[x][y++];
        HasNext(); // set the next pointer
        // assume next call is always valid
        return res;
    }
    
    public bool HasNext() {
        while (x < data.GetLength(0) && y == data[x].GetLength(0)) {
            y = 0; x++;
        }
        return x < data.GetLength(0);
    }
    int x, y;
    int[][] data;
}

/**
 * Your Vector2D object will be instantiated and called as such:
 * Vector2D obj = new Vector2D(v);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
