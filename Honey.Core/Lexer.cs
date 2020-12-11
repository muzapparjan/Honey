/**
 * HUST-CS1801-Muzappar
 * 2020-12-11
 * ----------------------------------------------------------------------------------------------------
 * Agreement Block / 协议区
 * 
 * 1.You can do any legal things you want with this software.
 * 1.你可以用这个软件做任何合法的事情。
 * 
 * 2.I'm not responsible for anything.
 * 2.我不负任何责任。
 * 
 * 3.You have to pay me 6.66 China Yuan to use all of this software.My AliPay account is 17625860648.
 * 3.你得付给我6.66元人民币才能使用整个软件。我的支付宝账户为17625860648。
 * ----------------------------------------------------------------------------------------------------
 */

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
                            exceptions.Add(new Exception("Unexpected symbol in file " + filePath + " at line " + i + " | position " + j + " | value " + value));
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
                            exceptions.Add(new Exception("Unexpected symbol in file " + filePath + " at line " + i + " | position " + j + " | value " + value));
                        else
                            result.Add(new Token(type, value));
                    }
                }
            }
            return result;
        }
    }
}