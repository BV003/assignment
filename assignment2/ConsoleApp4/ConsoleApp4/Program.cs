using System;

public class ConsoleApp4
{
    public static void Main()
    {
        Console.Write("请输入矩阵的行数 M：");
        int M = int.Parse(Console.ReadLine());

        Console.Write("请输入矩阵的列数 N：");
        int N = int.Parse(Console.ReadLine());

        int[,] matrix = new int[M, N];

        Console.WriteLine("请输入矩阵的元素（每行以空格分隔）：");
        for (int i = 0; i < M; i++)
        {
            string[] row = Console.ReadLine().Split(' ');
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = int.Parse(row[j]);
            }
        }

        bool isToeplitz = IsToeplitzMatrix(matrix);
        Console.WriteLine("该矩阵是否为托普利茨矩阵：{0}", isToeplitz);
    }

    public static bool IsToeplitzMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // 检查每一条对角线的元素是否相同
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] != matrix[i - 1, j - 1])
                {
                    return false;
                }
            }
        }

        return true;
    }
}