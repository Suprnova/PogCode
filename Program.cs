using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PogCode_Interpreter
{
    class Globals
    {
        public static int LineN;
        public static string Line;
        public static Dictionary<string, Dictionary<string, string>> AllVars = new Dictionary<string, Dictionary<string, string>>();
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();
        public static Dictionary<string, string> VariablesInt = new Dictionary<string, string>();
        public static Dictionary<string, string> VariablesFloat = new Dictionary<string, string>();
    }

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
            Program p = new Program();
            Commands c = new Commands();
            Variable_Replacing v = new Variable_Replacing();
            Dictionary<string, string> variables = new Dictionary<string, string>();
            var lines = File.ReadAllLines(file);
            int i = 0;
            foreach (var lineF in lines)
            {
                string command;
                string line;
                string parameter;
                string parameter2;
                string parameter3;
                try
                {
                    command = lineF.Substring(0, lineF.IndexOf(' '));
                }
                catch
                {
                    command = lineF;
                }
                if (lineF.Contains('{') && lineF.Contains('}'))
                {
                    line = v.Replace(lineF);
                }
                else
                {
                    line = lineF;
                }
                i++;
                Globals.Line = lineF;
                Globals.LineN = i;
                switch (command)
                {
                    // Kappa - Comment
                    case "Kappa":
                        break;
                    // PogChamp - WriteLine
                    case "PogChamp":
                        if (!line.Contains(' '))
                        {
                            c.PogChamp();
                        }
                        else
                        {
                            parameter = line.Substring(line.IndexOf(' '));
                            c.PogChamp(parameter);
                        }
                        break;
                    case "Pog":
                        if (!line.Contains(' '))
                        {
                            //no arg
                            p.ExceptionHandler(1, i, line);
                        }
                        else
                        {
                            parameter = line.Substring(line.IndexOf(' '));
                            c.Pog(parameter);
                        }
                        break;
                    // PogChap - ReadLine
                    case "PogChap":
                        if (line.Contains(' '))
                        {
                            // unexpected arg
                            p.ExceptionHandler(2, i, line);
                        }
                        else
                        {
                            c.PogChap();
                        }
                        break;
                    // PogU - Variable
                    case "PogU":
                        int valueU = line.Count(x => x == ' ');
                        switch(valueU)
                        {
                            case var expression when valueU <= 1:
                                p.ExceptionHandler(3, i, line);
                                break;
                            case 2:
                                parameter = line[line.IndexOf(' ')..line.IndexOf(' ', line.IndexOf(' ') + 1)].Trim();
                                parameter2 = line.Substring(line.IndexOf(' ', line.IndexOf(' ') + 1)).Trim();
                                c.PogU(parameter, parameter2);
                                break;
                            case var expression when valueU >= 2:
                                parameter = line[line.IndexOf(' ')..line.IndexOf(' ', line.IndexOf(' ') + 1)].Trim();
                                parameter2 = line[(line.IndexOf(' ', line.IndexOf(' ') + 1))..line.IndexOf(' ', line.IndexOf(' ', line.IndexOf(' ') + 1) + 1)].Trim();
                                parameter3 = line.Substring(line.IndexOf(' ', line.IndexOf(' ', line.IndexOf(' ') + 1) + 1)).Trim();
                                c.PogU(parameter, parameter2, parameter3);
                                break;
                        }
                        break;
                    // WeirdChamp - ReadLine + Variable
                    case "WeirdChamp":
                        int valueW = line.Count(x => x == ' ');
                        switch (valueW)
                        {
                            case var expression when valueW <= 1:
                                p.ExceptionHandler(3, i, line);
                                break;
                            case 2:
                                parameter = line[line.IndexOf(' ')..line.IndexOf(' ', line.IndexOf(' ') + 1)].Trim();
                                parameter2 = line.Substring(line.IndexOf(' ', line.IndexOf(' ') + 1)).Trim();
                                c.WeirdChamp(parameter, parameter2);
                                break;
                            case var expression when valueW >= 3:
                                p.ExceptionHandler(4, i, line);
                                break;
                        }
                        break;
                    case "PauseChamp":
                        if (!line.Contains(' '))
                        {
                            //no arg
                            p.ExceptionHandler(1, i, line);
                        }
                        else
                        {
                            parameter = line.Substring(line.IndexOf(' '));
                            c.PauseChamp(parameter);
                        }
                        break;
                    case "BrainChamp":
                        if (!line.Contains(' '))
                        {
                            p.ExceptionHandler(1, i, line);
                        }
                        else
                        {
                            parameter = line.Substring(line.IndexOf(' '));
                            c.BrainChamp(parameter);
                        }
                        break;
                    case "PogO":
                        Debugger.Break();
                        break;
                    default:
                        p.ExceptionHandler(0, i, line);
                        break;
                }
            }
            Console.WriteLine("\nScript completed all commands. Press Enter to exit.");
            Console.ReadLine();
        }

        public void ExceptionHandler(int exCode, int lineNumber, string line)
        {
            Console.WriteLine();
            Console.WriteLine($"Exception code {exCode} occurred at line {lineNumber}: {line}");
            switch (exCode)
            {
                case 0:
                    Console.WriteLine("Unrecognized command");
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
                    Console.WriteLine("Variable already exists in another type.");
                    break;
                case 7:
                    Console.WriteLine("Improper variable formatting.");
                    break;
                case 8:
                    Console.WriteLine("Invalid output to console.");
                    break;
                case 9:
                    Console.WriteLine("Usage of a null variable.");
                    break;
                case 10:
                    Console.WriteLine("Error parsing user inputted value.");
                    break;
                case 11:
                    Console.WriteLine("Invalid variable type.");
                    break;
                case 12:
                    Console.WriteLine("Invalid math operation.");
                    break;
            }
            Console.WriteLine("Press Enter to close window.");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
