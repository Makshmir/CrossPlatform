using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        string inputFileName = "input.txt";
        string outputFileName = "output.txt";

        if (File.Exists(inputFileName))
        {
            string inputContents = File.ReadAllText(inputFileName);

            if (int.TryParse(inputContents, out int maxDots))
            {
                int diamontsAmount = 0;
                Console.WriteLine("Максимальна кількість крапок на дощечці: " + maxDots);

                for (int i = maxDots; i >= 0; i--)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        diamontsAmount += i + j;
                    }
                }
                Console.WriteLine("Необхідно діамантів: " + diamontsAmount);

                File.WriteAllText(outputFileName, diamontsAmount.ToString());
            }
            else
            {
                Console.WriteLine("Некоректний формат вмісту файлу input.txt. Вміст повинен бути цілим числом.");
            }
        }
        else
        {
            Console.WriteLine("Файл input.txt не знайдено.");
        }

        Console.ReadKey();
    }
}
