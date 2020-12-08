/**
 * HUST-CS1801-Muzappar
 * 2020-12-07
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

using Honey.Core;
using System;

namespace Honey.Test
{
    class Entry
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Honey!");

            Console.WriteLine("Please input string to parse:");
            Console.Write(">>");
            string rawInput = Console.ReadLine();
            string[] inputs = rawInput.Split(" ");
            foreach (var input in inputs)
            {
                Console.WriteLine("Input : " + input);
                NFA nfa = Honey.Core.Honey.CreateNFA();
                foreach (var character in input)
                    nfa.Input(character.ToString());
                string type;
                string value = nfa.GetValue(out type);
                Console.WriteLine("NFA Value : " + value);
                Console.WriteLine("NFA Type  : " + type);
            }

            //List<string> outputs = new List<string>();
        }
    }
}