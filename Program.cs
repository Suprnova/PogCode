using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PogCode_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                string fileName = args[0];
                //Check file exists
                if (File.Exists(fileName) && fileName.ToLower().EndsWith(".pog"))
                    Interpreter(fileName);
                else
                    AskFile();
            }
            else
                AskFile();
        }

        private static void AskFile()
        {
            Console.WriteLine("Enter the file path to the .pog file.");
            string filePath = Console.ReadLine();
            if (File.Exists(filePath) && filePath.ToLower().EndsWith(".pog"))
            {
                Interpreter(filePath);
            }
            else
            {
                Console.WriteLine("This is not a valid .pog file.");
                AskFile();
            }
        }

        private static void Interpreter(string file)
        {
            Console.Clear();
            Dictionary<string, string> variables = new Dictionary<string, string>();
            var lines = File.ReadAllLines(file);
            int i = 0;
            foreach (var line in lines)
            {
                string command;
                try
                {
                    command = line.Substring(0, line.IndexOf(' '));
                }
                catch
                {
                    command = line;
                }
                i++;
                switch (command)
                {
                    // Kappa - Comment
                    case "Kappa":
                        break;
                    // PogChamp - WriteLine
                    case "PogChamp":
                        if (!line.StartsWith("PogChamp ") || string.IsNullOrWhiteSpace(line.Replace("PogChamp ", "")))
                        {
                            Console.WriteLine();
                            break;
                        }
                        string argPogC = line.Replace("PogChamp ", "");
                        if (argPogC.Contains('{') && argPogC.Contains('}'))
                        {
                            if (argPogC.IndexOf('{') > argPogC.IndexOf('}'))
                            {
                                ExceptionHandler(7, i, line);
                            }
                            else
                            {
                                string var = argPogC.Remove(argPogC.IndexOf('}'));
                                var = var.Substring(var.IndexOf('{') + 1);
                                if (variables.ContainsKey(var))
                                {
                                    argPogC = argPogC.Replace($"{{{var}}}", variables[var]);
                                }
                            }
                        }
                        Console.WriteLine(argPogC);
                        break;
                    case "Pog":
                        if (!line.StartsWith("Pog ") || string.IsNullOrWhiteSpace(line.Replace("Pog ", "")))
                        {
                            //no arg
                            ExceptionHandler(1, i, line);
                        }
                        string argPog = line.Replace("Pog ", "");
                        if (argPog.Contains('{') && argPog.Contains('}'))
                        {
                            if (argPog.IndexOf('{') > argPog.IndexOf('}'))
                            {
                                ExceptionHandler(7, i, line);
                            }
                            else
                            {
                                string var = argPog.Remove(argPog.IndexOf('}'));
                                var = var.Substring(var.IndexOf('{') + 1);
                                if (variables.ContainsKey(var))
                                {
                                    argPog = argPog.Replace($"{{{var}}}", variables[var]);
                                }
                            }
                        }
                        Console.Write(argPog);
                        break;
                    // PauseChamp - ReadLine
                    case "PauseChamp":
                        if (!string.IsNullOrWhiteSpace(line.Replace("PauseChamp", "")))
                        {
                            //unexpected arg
                            ExceptionHandler(2, i, line);
                        }
                        Console.ReadLine();
                        break;
                    // PogU - Variable
                    case "PogU":
                        if (line.Count(x => x == ' ') < 2)
                        {
                            //not enough args
                            ExceptionHandler(3, i, line);
                        }
                        else if (line.Count(x => x == ' ') > 2)
                        {
                            //too many args
                            ExceptionHandler(4, i, line);
                        }
                        string varPU = line[line.IndexOf(' ')..line.LastIndexOf(' ')].Trim();
                        string valuePU = line.Substring(line.LastIndexOf(' ')).Trim();
                        if (string.IsNullOrWhiteSpace(varPU) || string.IsNullOrWhiteSpace(valuePU))
                        {
                            //invalid arg
                            ExceptionHandler(5, i, line);
                        }
                        if (variables.ContainsKey(varPU))
                        {
                            //var exists
                            ExceptionHandler(6, i, line);
                        }
                        variables.Add(varPU, valuePU);
                        break;
                    // WeirdChamp - ReadLine + Variable
                    case "WeirdChamp":
                        if (line.Count(x => x == ' ') < 1)
                        {
                            //not enough args
                            ExceptionHandler(3, i, line);
                        }
                        else if (line.Count(x => x == ' ') > 1)
                        {
                            //too many args
                            ExceptionHandler(4, i, line);
                        }
                        string varWC = line.Substring(line.IndexOf(' ')).Trim();
                        if (string.IsNullOrWhiteSpace(varWC))
                        {
                            //invalid arg
                            ExceptionHandler(5, i, line);
                        }
                        if (variables.ContainsKey(varWC))
                        {
                            //var exists
                            ExceptionHandler(6, i, line);
                        }
                        string valueWC = Console.ReadLine();
                        variables.Add(varWC, valueWC);
                        break;
                    default:
                        ExceptionHandler(0, i, line);
                        break;
                }
            }
            Console.WriteLine("Script completed all commands. Press Enter to exit.");
            Console.ReadLine();
        }

        private static void ExceptionHandler(int exCode, int lineNumber, string line)
        {
            Console.WriteLine();
            Console.WriteLine($"Exception code {exCode} occurred at line {lineNumber}: {line}");
            switch (exCode)
            {
                case 0:
                    if (!line.Contains(' '))
                    {
                        Console.WriteLine("Unrecognized command.");
                    }
                    Console.WriteLine("Unrecognized command: " + line.Substring(0, line.IndexOf(' ')));
                    break;
                case 1:
                    Console.WriteLine("No arguments provided.");
                    break;
                case 2:
                    Console.WriteLine("Unexpected argument.");
                    break;
                case 3:
                    Console.WriteLine("Not enough arguments.");
                    break;
                case 4:
                    Console.WriteLine("Too many arguments.");
                    break;
                case 5:
                    Console.WriteLine("Invalid argument.");
                    break;
                case 6:
                    Console.WriteLine("Variable already exists.");
                    break;
                case 7:
                    Console.WriteLine("Improper variable formatting.");
                    break;
            }
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
