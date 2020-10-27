using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using static PogCode_Interpreter.Globals;

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

    class Commands
    {
        Program p = new Program();

        public void PogChamp()
        {
            Console.WriteLine();
        }

        public void PogChamp(string output)
        {
            if (output.Contains('{') && output.Contains('}'))
            {
                if (output.IndexOf('{') > output.IndexOf('}'))
                {
                    p.ExceptionHandler(7, LineN, Line);
                }
                else
                {
                    string var = output.Remove(output.IndexOf('}'));
                    var = var.Substring(var.IndexOf('{') + 1);
                    if (AllVars.ContainsKey(var))
                    {
                        if (AllVars[var] == null)
                        {
                            p.ExceptionHandler(9, LineN, Line);
                        }
                        else
                        {
                            output = output.Replace($"{{{var}}}", AllVars[var][var]);
                        }
                    }
                }
            }
            try
            {
                Console.WriteLine(output.Trim());
            }
            catch
            {
                p.ExceptionHandler(8, LineN, Line);
            }
        }

        public void Pog(string output)
        {
            if (output.Contains('{') && output.Contains('}'))
            {
                if (output.IndexOf('{') > output.IndexOf('}'))
                {
                    p.ExceptionHandler(7, LineN, Line);
                }
                else
                {
                    string var = output.Remove(output.IndexOf('}'));
                    var = var.Substring(var.IndexOf('{') + 1);
                    if (AllVars.ContainsKey(var))
                    {
                        if (AllVars[var] == null)
                        {
                            p.ExceptionHandler(9, LineN, Line);
                        }
                        else
                        {
                            output = output.Replace($"{{{var}}}", AllVars[var][var]);
                        }
                    }
                }
            }
            try
            {
                Console.Write(output.Trim());
            }
            catch
            {
                p.ExceptionHandler(8, LineN, Line);
            }
        }

        public void PogChap()
        {
            Console.ReadLine();
        }

        public void PogU(string varName, string type)
        {
            bool contains = false;
            Dictionary<string, string> table = new Dictionary<string, string>();
            if (Variables.ContainsKey(varName) || VariablesInt.ContainsKey(varName) || VariablesFloat.ContainsKey(varName))
            {
                contains = true;
            }
            switch (type)
            {
                case "string":
                    table = Variables;
                    break;
                case "int":
                    table = VariablesInt;
                    break;
                case "float":
                    table = VariablesFloat;
                    break;
                default:
                    p.ExceptionHandler(11, LineN, Line);
                    break;
            }
            if (contains)
            {
                if (!table.ContainsKey(varName))
                {
                    p.ExceptionHandler(6, LineN, Line);
                }
                else
                {
                    table[varName] = null;
                }
            }
            else
            {
                table.Add(varName, null);
                AllVars.Add(varName, table);
            }
        }

        public void PogU(string varName, string type, string value)
        {
            bool contains = false;
            Dictionary<string, string> table = new Dictionary<string, string>();
            if (Variables.ContainsKey(varName) || VariablesInt.ContainsKey(varName) || VariablesFloat.ContainsKey(varName))
            {
                contains = true;
            }
            switch (type)
            {
                case "string":
                    table = Variables;
                    break;
                case "int":
                    table = VariablesInt;
                    break;
                case "float":
                    table = VariablesFloat;
                    break;
                default:
                    p.ExceptionHandler(11, LineN, Line);
                    break;
            }
            if (contains)
            {
                if (!table.ContainsKey(varName))
                {
                    p.ExceptionHandler(6, LineN, Line);
                }
                else
                {
                    table[varName] = value;
                }
            }
            else
            {
                table.Add(varName, value);
                AllVars.Add(varName, table);
            }
        }

        public void WeirdChamp(string varName, string type)
        {
            bool contains = false;
            Dictionary<string, string> table = new Dictionary<string, string>();
            if (Variables.ContainsKey(varName) || VariablesInt.ContainsKey(varName) || VariablesFloat.ContainsKey(varName))
            {
                contains = true;
            }
            switch (type)
            {
                case "string":
                    table = Variables;
                    break;
                case "int":
                    table = VariablesInt;
                    break;
                case "float":
                    table = VariablesFloat;
                    break;
                default:
                    p.ExceptionHandler(11, LineN, Line);
                    break;
            }
            if (contains)
            {
                if (!table.ContainsKey(varName))
                {
                    p.ExceptionHandler(6, LineN, Line);
                }
                else
                {
                    try
                    {
                        table[varName] = Console.ReadLine();
                    }
                    catch
                    {
                        p.ExceptionHandler(10, LineN, Line);
                    }
                }
            }
            else
            {
                try
                {
                    table.Add(varName, Console.ReadLine());
                    AllVars.Add(varName, table);
                }
                catch
                {
                    p.ExceptionHandler(10, LineN, Line);
                }
            }
        }

        public void PauseChamp(string parameter)
        {
            int duration = 0;
            try
            {
                duration = Int32.Parse(parameter);
            }
            catch
            {
                p.ExceptionHandler(5, LineN, Line);
            }
            Thread.Sleep(duration);
        }

        public void BrainChamp(string equation)
        {
            if (equation.Contains('{') && equation.Contains('}'))
            {
                int openBrac = equation.Count(x => x == '{');
                int closeBrac = equation.Count(x => x == '}');
                if (openBrac != closeBrac)
                {
                    p.ExceptionHandler(7, LineN, Line);
                }
                try
                {
                    do
                    {
                        string var = equation.Remove(equation.IndexOf('}'));
                        var = var.Substring(var.IndexOf('{') + 1);
                        if (AllVars.ContainsKey(var))
                        {
                            if (AllVars[var] == null)
                            {
                                p.ExceptionHandler(9, LineN, Line);
                            }
                            else
                            {
                                equation = equation.Replace($"{{{var}}}", AllVars[var][var]);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (equation.Contains('{'));
                }
                catch
                {
                    p.ExceptionHandler(7, LineN, Line);
                }              
            }
            try
            {
                double result = Convert.ToDouble(new DataTable().Compute(equation, null));
                Console.WriteLine(result);
            }
            catch
            {
                p.ExceptionHandler(12, LineN, Line);
            }
        }
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
            Dictionary<string, string> variables = new Dictionary<string, string>();
            var lines = File.ReadAllLines(file);
            int i = 0;
            foreach (var line in lines)
            {
                string command;
                string parameter;
                string parameter2;
                string parameter3;
                try
                {
                    command = line.Substring(0, line.IndexOf(' '));
                }
                catch
                {
                    command = line;
                }
                i++;
                Globals.Line = line;
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
