/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node(){}
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
}
*/
public class Solution {
    public Node Construct(int[][] grid) {
        return Build(grid, 0, 0, grid.GetLength(0));
    }
    Node Build(int[][] grid, int x, int y, int len) {
        if (len <= 0) return null;
        for (int i = x; i < x + len; i++) {
            for (int j = y; j < y + len; j++) {
                if (grid[i][j] != grid[x][y]) {
                    return new Node(true, false,
                           Build(grid, x, y, len / 2),
                           Build(grid, x, y + len / 2, len / 2),
                           Build(grid, x + len/ 2, y, len / 2),
                           Build(grid, x + len / 2, y + len / 2, len / 2));
                }
            }
        }
        return new Node (grid[x][y] == 1, true, null, null, null, null);
    }
}
