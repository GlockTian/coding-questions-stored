public class Solution
{

    // a more Common method
    // reverse then take the symmetry
    // 1 2 3     7 8 9     7 4 1
    // 4 5 6  => 4 5 6  => 8 5 2
    // 7 8 9     1 2 3     9 6 3
    public void Rotate(int[][] matrix)
    {
        Array.Reverse(matrix, 0, matrix.Length);
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = i + 1; j < matrix[i].Length; j++)
                swap(matrix, i, j, j, i);
        }
    }

    // find the start indexes for all rotating
    // then compute the corresponding indexes for these start indexes
    public void RotateFindStartIndex(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = i; j < n - 1 - i; j++)
            {
                // i and j are the starting index for rotation
                // there are four position we need to swap
                int i1 = j;
                int j1 = n - i - 1;

                int i2 = n - i - 1;
                int j2 = n - j - 1;

                int i3 = n - j - 1;
                int j3 = i;
                
                swap(matrix, i, j, i1, j1);
                swap(matrix, i, j, i3, j3);
                swap(matrix, i3, j3, i2, j2);

            }
        }
    }

    public void swap(int[][] matrix, int i1, int j1, int i2, int j2)
    {
        int temp = matrix[i1][j1];
        matrix[i1][j1] = matrix[i2][j2];
        matrix[i2][j2] = temp;
    }
}