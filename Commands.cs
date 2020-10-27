using System;
using System.Collections.Generic;
using System.Data;
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
