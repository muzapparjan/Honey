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

using System.Collections.Generic;

namespace Honey.Core
{
    public static class Honey
    {
        private static readonly List<string> characterSet_Identifier = CharacterSet.Combine(CharacterSet.NumbersAndLetters(), "_", "@", "#", "$");
        private static readonly List<string> characterSet_HexNumber = CharacterSet.Combine(CharacterSet.Numbers(), "a", "A", "b", "B", "c", "C", "d", "D", "e", "E", "f", "F");

        public static NFA CreateNFA()
        {
            NFA.State state_Start = new NFA.State("Start");
            NFA.State state_End = new NFA.State("End");

            state_Start.transitions.Add(NFA.TransitionFactory.Any(state_End));
            state_End.transitions.Add(NFA.TransitionFactory.Any(state_End));

            /* 数字识别 */

            NFA.State state_Integer = new NFA.State("Integer", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.Number(state_Integer));
            state_Integer.transitions.Add(NFA.TransitionFactory.Number(state_Integer));

            NFA.State state_MayBeFloat = new NFA.State("MayBeFloat", -1);
            NFA.State state_Float = new NFA.State("Float", 10);
            NFA.State state_Float32 = new NFA.State("Float32", 15);
            NFA.State state_Float64 = new NFA.State("Float64", 15);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeFloat));
            state_Integer.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeFloat));
            state_Integer.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float32, "f", "F"));
            state_Integer.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float64, "d", "D"));
            state_MayBeFloat.transitions.Add(NFA.TransitionFactory.Number(state_Float));
            state_Float.transitions.Add(NFA.TransitionFactory.Number(state_Float));
            state_Float.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float32, "f", "F"));
            state_Float.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float64, "d", "D"));

            NFA.State state_MayBeBinary = new NFA.State("MayBeBinary", -1);
            NFA.State state_MayBeBinaryFloat = new NFA.State("MayBeBinaryFloat", -1);
            NFA.State state_AlmostBinaryFloat = new NFA.State("AlmostBinaryFloat", -1);
            NFA.State state_Binary = new NFA.State("Binary", 15);

            state_Start.transitions.Add(NFA.TransitionFactory.ElementOf(state_MayBeBinary, "0", "1"));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeBinaryFloat));
            state_MayBeBinary.transitions.Add(NFA.TransitionFactory.ElementOf(state_MayBeBinary, "0", "1"));
            state_MayBeBinary.transitions.Add(NFA.TransitionFactory.ElementOf(state_Binary, "b", "B"));
            state_MayBeBinary.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeBinaryFloat));
            state_MayBeBinaryFloat.transitions.Add(NFA.TransitionFactory.ElementOf(state_AlmostBinaryFloat, "0", "1"));
            state_AlmostBinaryFloat.transitions.Add(NFA.TransitionFactory.ElementOf(state_AlmostBinaryFloat, "0", "1"));
            state_AlmostBinaryFloat.transitions.Add(NFA.TransitionFactory.ElementOf(state_Binary, "b", "B"));

            NFA.State state_MayBeHex_0 = new NFA.State("MayBeHex_0", -1);
            NFA.State state_MayBeHex = new NFA.State("MayBeHex", -1);
            NFA.State state_Hex = new NFA.State("Hex", 15);
            NFA.State state_MayBeHexFloat = new NFA.State("MayBeHexFloat", -1);
            NFA.State state_HexFloat = new NFA.State("Hex", 15);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("0", state_MayBeHex_0));
            state_MayBeHex_0.transitions.Add(NFA.TransitionFactory.ElementOf(state_MayBeHex, "x", "X"));
            state_MayBeHex.transitions.Add(NFA.TransitionFactory.ElementOf(characterSet_HexNumber, state_Hex));
            state_MayBeHex.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeHexFloat));
            state_Hex.transitions.Add(NFA.TransitionFactory.ElementOf(characterSet_HexNumber, state_Hex));
            state_Hex.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeHexFloat));
            state_MayBeHexFloat.transitions.Add(NFA.TransitionFactory.ElementOf(characterSet_HexNumber, state_HexFloat));
            state_HexFloat.transitions.Add(NFA.TransitionFactory.ElementOf(characterSet_HexNumber, state_HexFloat));

            /* 标识符识别 */

            NFA.State state_Identifier = new NFA.State("Identifier", 5);

            state_Start.transitions.Add(NFA.TransitionFactory.ElementOf(characterSet_Identifier, state_Identifier));
            state_Identifier.transitions.Add(NFA.TransitionFactory.ElementOf(characterSet_Identifier, state_Identifier));

            /* and/or/not识别 */

            NFA.State state_and_a = new NFA.State("and_a", -1);
            NFA.State state_and_A = new NFA.State("and_A", -1);
            NFA.State state_and_n = new NFA.State("and_n", -1);
            NFA.State state_and_N = new NFA.State("and_N", -1);
            NFA.State state_and = new NFA.State("and", 50);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("a", state_and_a));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("A", state_and_A));
            state_and_a.transitions.Add(NFA.TransitionFactory.EqualTo("n", state_and_n));
            state_and_A.transitions.Add(NFA.TransitionFactory.EqualTo("n", state_and_n));
            state_and_A.transitions.Add(NFA.TransitionFactory.EqualTo("N", state_and_N));
            state_and_n.transitions.Add(NFA.TransitionFactory.EqualTo("d", state_and));
            state_and_N.transitions.Add(NFA.TransitionFactory.EqualTo("D", state_and));

            NFA.State state_or_o = new NFA.State("or_o", -1);
            NFA.State state_or_O = new NFA.State("or_O", -1);
            NFA.State state_or = new NFA.State("or", 50);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("o", state_or_o));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("O", state_or_O));
            state_or_o.transitions.Add(NFA.TransitionFactory.EqualTo("r", state_or));
            state_or_O.transitions.Add(NFA.TransitionFactory.ElementOf(state_or, "r", "R"));

            NFA.State state_not_n = new NFA.State("not_n", -1);
            NFA.State state_not_N = new NFA.State("not_N", -1);
            NFA.State state_not_o = new NFA.State("not_o", -1);
            NFA.State state_not_O = new NFA.State("not_O", -1);
            NFA.State state_not = new NFA.State("not", 50);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("n", state_not_n));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("N", state_not_N));
            state_not_n.transitions.Add(NFA.TransitionFactory.EqualTo("o", state_not_o));
            state_not_N.transitions.Add(NFA.TransitionFactory.EqualTo("o", state_not_o));
            state_not_N.transitions.Add(NFA.TransitionFactory.EqualTo("O", state_not_O));
            state_not_o.transitions.Add(NFA.TransitionFactory.EqualTo("t", state_not));
            state_not_O.transitions.Add(NFA.TransitionFactory.EqualTo("T", state_not));

            /****************************************************/

            return new NFA(state_Start);
        }
    }
}