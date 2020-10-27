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
                    do
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
                        else
                        {
                            break;
                        }
                    }
                    while (output.Contains('{'));
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
                    do
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
                        else
                        {
                            break;
                        }
                    }
                    while (output.Contains('{'));
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
            if (parameter.Contains('{') && parameter.Contains('}'))
            {
                if (parameter.IndexOf('{') > parameter.IndexOf('}'))
                {
                    p.ExceptionHandler(7, LineN, Line);
                }
                else
                {
                    string var = parameter.Remove(parameter.IndexOf('}'));
                    var = var.Substring(var.IndexOf('{') + 1);
                    if (AllVars.ContainsKey(var))
                    {
                        if (AllVars[var] == null)
                        {
                            p.ExceptionHandler(9, LineN, Line);
                        }
                        else
                        {
                            parameter = parameter.Replace($"{{{var}}}", AllVars[var][var]);
                        }
                    }
                }
            }
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
}
