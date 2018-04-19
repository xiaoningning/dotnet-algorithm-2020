using System;

namespace CountCornerRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[,]{
                                    {1, 0, 0, 1, 0},
                                    {0, 0, 1, 0, 1},
                                    {0, 0, 0, 1, 0},
                                    {1, 0, 1, 0, 1}
                                    };
            Console.WriteLine("count of corner rectangles: {0}", CountCornerRectangles(grid));
        }
        
        static int CountCornerRectangles(int[,] grid) {
            int res = 0;
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);

            for(int i = 0; i < m; i++){
                for(int j = i+1; j < m; j++){
                    for(int k = 0; k < n; k++){
                        if(grid[i,k] == 0 || grid[j, k] == 0) continue;
                        for(int p = k+1; p < n; p++){
                            res += grid[i,p] & grid[j,p];
                        }
                    }                    
                }
            } 

            return res;        
        }
    }
}
