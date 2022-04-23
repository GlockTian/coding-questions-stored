public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int count = 0;

        Direction current = Direction.RIGHT;

        int i = 0;
        int j = 0;

        int left = -1;
        int right = n;
        int top = -1;
        int bottom = m;

        IList<int> res = new List<int>();

        while (count < m * n)
        {
            res.Add(matrix[i][j]);
            switch (current)
            {
                case Direction.UP:
                    i--;
                    if (i <= top)
                    {
                        // have reach the limit now rotate
                        current = Direction.RIGHT;
                        i++;
                        j++;
                        left++;// because one left layer is finished
                    }
                    break;
                case Direction.LEFT:
                    j--;
                    if (j <= left)
                    {
                        // have reach the limit now rotate
                        current = Direction.UP;
                        j++;
                        i--;
                        bottom--;// because one bottom layer is finished
                    }
                    break;
                case Direction.DOWN:
                    i++;
                    if (i >= bottom)
                    {
                        // have reach the limit now rotate
                        current = Direction.LEFT;
                        i--;
                        j--;
                        right--;// because one right layer is finished
                    }
                    break;
                case Direction.RIGHT:
                    j++;
                    if (j >= right)
                    {
                        // have reach the limit now rotate
                        current = Direction.DOWN;
                        j--;
                        i++;
                        top++;// because one top layer is finished
                    }
                    break;
            }
            count++;
        }
        return res;
    }
}

public enum Direction
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
}