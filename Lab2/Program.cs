﻿using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

        string inputFileName = "input.txt";
        string outputFileName = "output.txt";
        int n, k, g, count;

        string[] tempstring = GetLine(inputFileName, 1).Split(' ');

        if (tempstring.Length != 2 || !int.TryParse(tempstring[0], out n) || !int.TryParse(tempstring[1], out k))
        {
            Console.WriteLine("Помилка: Неправильний формат першого рядка у файлі input.txt");
            return;
        }

        List<List<int>> dp = new List<List<int>>();
        for (int i = 0; i < n + 1; i++)
        {
            dp.Add(new List<int>(new int[] { 0, 0 }));
        }
        int w, nt, s, ch = 1, unid;
        tempstring = GetLine(inputFileName, 2).Split(' ');

        if (tempstring.Length != 3 || !int.TryParse(tempstring[0], out w) || !int.TryParse(tempstring[1], out nt) || !int.TryParse(tempstring[2], out s))
        {
            Console.WriteLine("Помилка: Неправильний формат другого рядка у файлі input.txt");
            return;
        }

        count = s;
        for (int i = 0; i < n; i++)
        {
            dp[i][1] = count;
            if (count == w)
            {
                count = 0;
            }
            count++;
        }
        for (int i = 0; i < nt; i++)
        {
            unid = int.Parse(GetLine(inputFileName, 3 + i));
            for (int z = 0; z < n; z += (int)ch)
            {
                if (dp[z][1] == unid)
                {
                    dp[z][0] = -1;
                    ch = w;
                }
            }
        }
        ch = 1;
        g = int.Parse(GetLine(inputFileName, 4));
        tempstring = GetLine(inputFileName, 5).Split(' ');

        if (tempstring.Length != g)
        {
            Console.WriteLine("Помилка: Кількість чисел у п'ятому рядку не відповідає заданій кількості");
            return;
        }

        for (int i = 0; i < g; i++)
        {
            unid = int.Parse(tempstring[i]);
            dp[(int)(unid - 1)][0] = -1;
        }
        int last = 0;
        for (int i = 0; i < n; i++)
        {
            if (i + k > n)
            {
                break;
            }
            if (dp[i][0] == -1)
            {
                continue;
            }
            if (dp[i + (int)k - 1][0] == -1)
            {
                i = i + (int)k - 1;
                continue;
            }
            dp[i][0] = dp[i][0] + last + 1;
            last = (int)dp[i][0];
        }
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            if (res < dp[i][0])
            {
                res = (int)dp[i][0];
            }
        }
        Console.WriteLine(res);
        File.WriteAllText(outputFileName, res.ToString());
    }
}
