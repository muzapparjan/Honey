using System;
using System.Collections.Generic;
using System.IO;

namespace Honey.Core
{
    public static class Lexer
    {
        public static List<Token> Scan(string filePath, out List<Exception> exceptions)
        {
            List<Token> result = new List<Token>();
            exceptions = new List<Exception>();

            string script;
            try
            {
                script = File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                exceptions.Add(e);
                return null;
            }

            string[] lines = script.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string value, type;
                NFA nfa = Honey.CreateNFA();
                for (int j = 0; j < line.Length; j++)
                {
                    nfa.Input(line[j].ToString());
                    value = nfa.GetValue(out type);
                    if (type == "End" && nfa.GetCurrentStateCount() == 1)
                    {
                        do
                        {
                            nfa.Return();
                            value = nfa.GetValue(out type);
                            j--;
                        } while (nfa.GetRecordCount() > 0 && type == "End");
                        if (type == "End" || type == "Start")
                        {
                            exceptions.Add(new Exception("bacvccasdf"));
                            j++;
                        }
                        else
                            result.Add(new Token(type, value));
                        nfa = Honey.CreateNFA();
                        continue;
                    }
                    if (j == line.Length - 1)
                    {
                        if (type == "End")
                            exceptions.Add(new Exception("sjdfklljasdlf0"));
                        else
                            result.Add(new Token(type, value));
                    }
                }
            }
            return result;
        }
    }
}