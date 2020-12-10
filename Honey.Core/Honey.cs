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

        private static readonly Dictionary<string, int> keywords = new Dictionary<string, int>()
        {
            {   "and"       ,   50  },
            {   "as"        ,   50  },
            {   "case"      ,   50  },
            {   "default"   ,   50  },
            {   "elif"      ,   50  },
            {   "else"      ,   50  },
            {   "equal"     ,   50  },
            {   "equals"    ,   50  },
            {   "if"        ,   50  },
            {   "import"    ,   50  },
            {   "include"   ,   50  },
            {   "is"        ,   50  },
            {   "let"       ,   50  },
            {   "not"       ,   50  },
            {   "or"        ,   50  },
            {   "switch"    ,   50  },
            {   "using"     ,   50  },
            {   "var"       ,   50  }
        };

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

            /* 关键字识别 */

            foreach (KeyValuePair<string, int> keyword in keywords)
                AddKeywordToNFA(state_Start, keyword.Key, keyword.Value);

            /****************************************************/

            return new NFA(state_Start);
        }
        private static void AddKeywordToNFA(NFA.State state_Start, string keyword, int priority = 50)
        {
            string lowerKeyword = keyword.ToLower();
            string upperKeyword = keyword.ToUpper();
            string firstChar_Lower = lowerKeyword[0].ToString();
            string firstChar_Upper = upperKeyword[0].ToString();

            NFA.State state_Keyword = new NFA.State(lowerKeyword, priority);

            NFA.State state_FirstChar_Lower = new NFA.State(lowerKeyword + "_" + firstChar_Lower, -1);
            NFA.State state_FirstChar_Upper = new NFA.State(lowerKeyword + "_" + firstChar_Upper, -1);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(firstChar_Lower, state_FirstChar_Lower));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(firstChar_Upper, state_FirstChar_Upper));

            if (keyword.Length == 2)
            {
                state_FirstChar_Lower.transitions.Add(NFA.TransitionFactory.EqualTo(lowerKeyword[1].ToString(), state_Keyword));
                state_FirstChar_Upper.transitions.Add(NFA.TransitionFactory.ElementOf(state_Keyword, lowerKeyword[1].ToString(), upperKeyword[1].ToString()));
                return;
            }

            NFA.State state_SecondChar_Lower = new NFA.State(lowerKeyword + "_" + lowerKeyword[1], -1);

            state_FirstChar_Lower.transitions.Add(NFA.TransitionFactory.EqualTo(lowerKeyword[1].ToString(), state_SecondChar_Lower));
            state_FirstChar_Upper.transitions.Add(NFA.TransitionFactory.EqualTo(lowerKeyword[1].ToString(), state_SecondChar_Lower));

            NFA.State lastState = state_SecondChar_Lower;
            for (int i = 2; i < lowerKeyword.Length - 1; i++)
            {
                NFA.State nextState = new NFA.State(lowerKeyword + "_" + lowerKeyword[i], -1);
                lastState.transitions.Add(NFA.TransitionFactory.EqualTo(lowerKeyword[i].ToString(), nextState));
                lastState = nextState;
            }
            lastState.transitions.Add(NFA.TransitionFactory.EqualTo(lowerKeyword[lowerKeyword.Length - 1].ToString(), state_Keyword));

            lastState = state_FirstChar_Upper;
            for (int i = 1; i < upperKeyword.Length - 1; i++)
            {
                NFA.State nextState = new NFA.State(lowerKeyword + "_" + upperKeyword[i], -1);
                lastState.transitions.Add(NFA.TransitionFactory.EqualTo(upperKeyword[i].ToString(), nextState));
                lastState = nextState;
            }
            lastState.transitions.Add(NFA.TransitionFactory.EqualTo(upperKeyword[upperKeyword.Length - 1].ToString(), state_Keyword));
        }
    }
}