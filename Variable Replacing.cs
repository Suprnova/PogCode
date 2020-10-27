using static PogCode_Interpreter.Globals;

namespace PogCode_Interpreter
{
    class Variable_Replacing
    {
        Program p = new Program();

        public string Replace(string line)
        {
            if (line.Contains('{') && line.Contains('}'))
            {
                if (line.IndexOf('{') > line.IndexOf('}'))
                {
                    p.ExceptionHandler(7, LineN, Line);
                }
                else
                {
                    do
                    {
                        string var = line.Remove(line.IndexOf('}'));
                        var = var.Substring(var.IndexOf('{') + 1);
                        if (AllVars.ContainsKey(var))
                        {
                            if (AllVars[var] == null)
                            {
                                p.ExceptionHandler(9, LineN, Line);
                            }
                            else
                            {
                                line = line.Replace($"{{{var}}}", AllVars[var][var]);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (line.Contains('{'));
                }
            }
            return line;
        }
    }
}
