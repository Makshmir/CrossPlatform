using NugetPackageForLab3;
internal class Program
{
    static void Main()
    {
        var mazeSolver = new NugetPackageForLab3.Class1();
        int count = mazeSolver.SolveMaze("input.txt", "output.txt");
        //int count = mazeSolver.SolveMaze("C:\\Users\\user\\source\\repos\\Lab3CrossPlatfUsage\\Lab3CrossPlatfUsage\\bin\\Debug\\net7.0\\input.txt", "C:\\Users\\user\\source\\repos\\Lab3CrossPlatfUsage\\Lab3CrossPlatfUsage\\bin\\Debug\\net7.0\\output.txt");
        Console.WriteLine($"Number of areas in the maze: {count}");
    }
}