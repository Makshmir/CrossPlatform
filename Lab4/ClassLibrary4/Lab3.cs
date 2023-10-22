using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    internal class Lab3
    {
        public static void Run(string inputString, string outputString)
        {
            var mazeSolver = new Lab3();
            int count = mazeSolver.SolveMaze(inputString, outputString);
            Console.WriteLine(count);
        }
        public int SolveMaze(string inputString, string outputString)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            StreamReader sr = new StreamReader(inputString);
            string[] input = sr.ReadLine().Split();

            if (input.Length != 2 || !int.TryParse(input[0], out int N) || !int.TryParse(input[1], out int M))
            {
                Console.WriteLine("Некоректні вхідні дані.");
                sr.Close();
                return -1;
            }

            char[,] Lines = new char[N, M];

            for (int i = 0; i < N; i++)
            {
                string[] row = sr.ReadLine().Split();

                if (row.Length != M)
                {

                    Console.WriteLine($"Некоректна кількість стовпців у рядку {i + 1}");
                    sr.Close();
                    return -1;
                }

                for (int j = 0; j < M; j++)
                {
                    if (char.TryParse(row[j], out char cellValue) && (cellValue == '0' || cellValue == '1'))
                    {
                        Lines[i, j] = cellValue;
                    }
                    else
                    {

                        Console.WriteLine($"Некоректне значення комірки в рядку {i + 1}, стовпці {j + 1}");
                        sr.Close();
                        return -1;
                    }
                }
            }

            int count = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (Lines[i, j] == '0')
                    {
                        count++;
                        Recursive(i, j, Lines, N, M);
                    }
                }
            }

            StreamWriter sw = new StreamWriter(outputString);
            sw.WriteLine(Convert.ToString(count));
            sr.Close();
            sw.Close();
            return count;
        }

        public void Recursive(int i, int j, char[,] Lines, int N, int M)
        {
            Lines[i, j] = '1';
            if ((j < M - 1) && (Lines[i, j + 1] == '0')) Recursive(i, j + 1, Lines, N, M);
            if ((j > 0) && (Lines[i, j - 1] == '0')) Recursive(i, j - 1, Lines, N, M);
            if ((i < N - 1) && (Lines[i + 1, j] == '0')) Recursive(i + 1, j, Lines, N, M);
            if ((i > 0) && (Lines[i - 1, j] == '0')) Recursive(i - 1, j, Lines, N, M);
        }
    }
}
