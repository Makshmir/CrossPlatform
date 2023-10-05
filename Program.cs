using System;


//Лабораторна #3 
//Варіант 1
class Program
{
    static int N, M;
    static char[,] Lines;

    static void Recursive(int i, int j)
    {

        Lines[i, j] = '1';
        if ((j < M - 1) && (Lines[i, j + 1] == '0')) Recursive(i, j + 1);
        if ((j > 1) && (Lines[i, j - 1] == '0')) Recursive(i, j - 1);
        if ((i < N - 1) && (Lines[i + 1, j] == '0')) Recursive(i + 1, j);
        if ((i > 1) && (Lines[i - 1, j] == '0')) Recursive(i - 1, j);


    }

    static void Main()
    {
        StreamReader sr = new StreamReader("input.txt");
        StreamWriter sw = new StreamWriter("output.txt");
        string[] input = sr.ReadLine().Split();

        N = int.Parse(input[0]);
        M = int.Parse(input[1]);

        Lines = new char[N, M];

        for (int i = 0; i < N; i++)
        {
            string[] row = sr.ReadLine().Split();
            for (int j = 0; j < M; j++)
            {
                Lines[i, j] = char.Parse(row[j]);
            }
        }

        int Count = 0;
        for (int i = 0; i <= N - 1; i++)
        {
            for (int j = 0; j <= M - 1; j++)
            {
                if (Lines[i, j] == '0')
                {
                    Count++;
                    Recursive(i, j);
                }
            }
        }

        sw.WriteLine(Convert.ToString(Count));
        sr.Close();
        sw.Close();
    }
}