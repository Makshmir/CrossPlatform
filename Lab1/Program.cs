internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;


        string inputFileName = "input.txt";
        string outputFileName = "output.txt";

        int maxDots = Convert.ToInt32(File.ReadAllText(inputFileName));
        int diamontsAmount = 0;
        Console.WriteLine("Максимальна кількість крапок на дощечці: "+maxDots);


       //Console.WriteLine("Пари на дощечках:");
        for (int i = maxDots; i >= 0; i--)
        {
            for (int j = i; j >= 0; j--)
            {
                //Console.WriteLine(i + "  " + j);
                diamontsAmount += i + j;
            }
        }
        Console.WriteLine("Необхідно діамантів: "+diamontsAmount);

        File.WriteAllText(outputFileName, diamontsAmount.ToString());
        Console.ReadKey();
    }
}