public class SnakeGame {
    List<int[]> snake;
    List<int[]> foods;
    int width, height, score;
    /** Initialize your data structure here.
        @param width - screen width
        @param height - screen height 
        @param food - A list of food positions
        E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
    public SnakeGame(int width, int height, int[][] food) {
        this.width = width; this.height = height; this.score = 0;
        snake = new List<int[]>(){new int[]{0,0}};
        foods = new List<int[]>();
        foreach (var f in food) foods.Add(new int[]{f[0],f[1]});
    }
    
    /** Moves the snake.
        @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
        @return The game's score after the move. Return -1 if game over. 
        Game over when snake crosses the screen boundary or bites its body. */
    public int Move(string direction) {
        var head = new int[]{snake.First()[0], snake.First()[1]};  
        var tail = snake.Last(); snake.RemoveAt(snake.Count - 1);
        if (direction == "U") --head[0];
        else if (direction == "L") --head[1];
        else if (direction == "R") ++head[1];
        else if (direction == "D") ++head[0];
        if (snake.Where(x => x[0] == head[0] && x[1] == head[1]).Any() || head[0] < 0 || head[0] >= height || head[1] < 0 || head[1] >= width) {
            return -1;
        }
        snake.Insert(0, head);
        if (foods.Any() && head[0] == foods.First()[0] && head[1] == foods.First()[1]) {
            foods.RemoveAt(0);
            snake.Add(tail);
            ++score;
        }
        return score;
    }
}

/**
 * Your SnakeGame object will be instantiated and called as such:
 * SnakeGame obj = new SnakeGame(width, height, food);
 * int param_1 = obj.Move(direction);
 */
