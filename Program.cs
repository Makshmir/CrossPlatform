internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
  

        Console.WriteLine("Уведіть максимальну кількість крапок");

        int maxDots = 0;
        int diamontsAmount = 0;

        maxDots = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Пари на дощечках:");
        for (int i = maxDots; i >= 0; i--)
        {
            for (int j = i; j >= 0; j--)
            {
                //Console.WriteLine(i + "  " + j);
                diamontsAmount += i + j;
            }
        }
        Console.WriteLine("Необхідно діамантів: "+diamontsAmount);
    }
}