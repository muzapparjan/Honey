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
        public static NFA CreateNFA()
        {
            NFA.State state_Start = new NFA.State("Start");
            NFA.State state_End = new NFA.State("End");

            state_Start.transitions.Add(NFA.TransitionFactory.Any(state_End));
            state_End.transitions.Add(NFA.TransitionFactory.Any(state_End));

            /* 数字识别 */

            NFA.State state_Integer = new NFA.State("Integer", 10);
            NFA.State state_MayBeFloat = new NFA.State("MayBeInteger", -1);
            NFA.State state_Float = new NFA.State("Float", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.Number(state_Integer));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeFloat));
            state_Integer.transitions.Add(NFA.TransitionFactory.Number(state_Integer));
            state_Integer.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeFloat));
            state_MayBeFloat.transitions.Add(NFA.TransitionFactory.Number(state_Float));
            state_Float.transitions.Add(NFA.TransitionFactory.Number(state_Float));

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

            /****************************************************/

            return new NFA(state_Start);
        }
    }
}