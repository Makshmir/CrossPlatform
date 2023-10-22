using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    internal class Lab1
    {

        public static void Run(string inputString, string outputString)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            //string inputString = "input.txt";
            //string outputString = "output.txt";

            int maxDots = Convert.ToInt32(File.ReadAllText(inputString));
            int diamontsAmount = 0;
            Console.WriteLine("Максимальна кількість крапок на дощечці: " + maxDots);


            //Console.WriteLine("Пари на дощечках:");
            for (int i = maxDots; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    //Console.WriteLine(i + "  " + j);
                    diamontsAmount += i + j;
                }
            }
            Console.WriteLine("Необхідно діамантів: " + diamontsAmount);

            File.WriteAllText(outputString, diamontsAmount.ToString());
            Console.ReadKey();
        }
    }
}
