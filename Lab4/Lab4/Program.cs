using System;
using System.ComponentModel.Design;
using ClassLibrary4;

internal class Program
{
    public static void Help()
    {
        Console.WriteLine("" +
            "version\n" +
            "run lab(обов'язково) i(необов'язково) o(необов'язково)\n" +
            "set-path -p(обов'язково)" +
            "");
    }
    public static string ReadArgumets(string[] arguments, string smallArgument, string bigArgument)
    {
        for (int i = 1; i < arguments.Length - 1; i++)
        {
            if ((arguments[i] == smallArgument || arguments[i] == bigArgument) && !string.IsNullOrEmpty(arguments[i + 1]))
            {
                return arguments[i + 1];
            }
        }
        return null;
    }
    public static void SetPaths(ref string inputPath, ref string outputPath)
    {
        if (string.IsNullOrEmpty(inputPath))
        {
            inputPath = Environment.GetEnvironmentVariable("LAB_PATH") ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        if (string.IsNullOrEmpty(outputPath))
        {
            outputPath = inputPath;
        }
    }
    static void Main(string[] args)
    {
        
        while (true){
            Console.Write("Enter Command ->");
            string input = Console.ReadLine();
            string[] consoleInput = input.Split();

            try
            {
                if (consoleInput.Length < 1)
                {
                    Console.WriteLine("Error");
                    Help();
                    continue;
                }
                string command = consoleInput[0];
                switch (command)
                {
                    case "version":
                        Console.WriteLine("Author: Khmirov Maksym, Version: 1.0.0");
                        break;
                    case "run":
                        if (consoleInput.Length < 2)
                        {
                            Console.WriteLine("You must enter lab name like: run lab1");
                            continue;
                        }
                        string labName = consoleInput[1];
                        if (labName != "lab1" && labName != "lab2" && labName != "lab3")
                        {
                            Console.WriteLine("Error lab name");
                            continue;
                        }
                        string inputString = ReadArgumets(consoleInput, "-i", "--input");
                        string outputString = ReadArgumets(consoleInput, "-o", "--output");
                        SetPaths(ref inputString, ref outputString);
                        if (string.IsNullOrEmpty(inputString))
                        {
                            Console.WriteLine("Input file not found");
                            continue;
                        }

                        string labNumberString = labName.Substring(3);
                        int labNumber = int.Parse(labNumberString);
                        LabRunner.Run(labNumber, inputString, outputString);

                        break;



                    case "set-path":
                        string path = ReadArgumets(consoleInput, "-p", "--path");
                        if (string.IsNullOrEmpty(path))
                        {
                            Console.WriteLine("Path error");
                            continue;
                        }
                        Environment.SetEnvironmentVariable("LAB_PATH", path, EnvironmentVariableTarget.User);
                        Console.WriteLine("The path to the folder with input and output files is set to:"+ path);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command:" + consoleInput);
                        Help();
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}