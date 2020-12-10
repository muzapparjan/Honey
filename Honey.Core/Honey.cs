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
            {   "abstract"      ,   50  },
            {   "add"           ,   50  },
            {   "and"           ,   50  },
            {   "as"            ,   50  },
            {   "asm"           ,   50  },
            {   "assert"        ,   50  },
            {   "async"         ,   50  },
            {   "auto"          ,   50  },
            {   "await"         ,   50  },
            {   "base"          ,   50  },
            {   "bool"          ,   50  },
            {   "boolean"       ,   50  },
            {   "break"         ,   50  },
            {   "byte"          ,   50  },
            {   "case"          ,   50  },
            {   "catch"         ,   50  },
            {   "char"          ,   50  },
            {   "checked"       ,   50  },
            {   "class"         ,   50  },
            {   "const"         ,   50  },
            {   "continue"      ,   50  },
            {   "decimal"       ,   50  },
            {   "default"       ,   50  },
            {   "delegate"      ,   50  },
            {   "delete"        ,   50  },
            {   "do"            ,   50  },
            {   "double"        ,   50  },
            {   "dynamic"       ,   50  },
            {   "elif"          ,   50  },
            {   "else"          ,   50  },
            {   "elseif"        ,   50  },
            {   "enum"          ,   50  },
            {   "equals"        ,   50  },
            {   "event"         ,   50  },
            {   "explicit"      ,   50  },
            {   "export"        ,   50  },
            {   "extends"       ,   50  },
            {   "extern"        ,   50  },
            {   "false"         ,   50  },
            {   "final"         ,   50  },
            {   "finally"       ,   50  },
            {   "fixed"         ,   50  },
            {   "float"         ,   50  },
            {   "for"           ,   50  },
            {   "foreach"       ,   50  },
            {   "function"      ,   50  },
            {   "get"           ,   50  },
            {   "global"        ,   50  },
            {   "goto"          ,   50  },
            {   "if"            ,   50  },
            {   "implements"    ,   50  },
            {   "implicit"      ,   50  },
            {   "import"        ,   50  },
            {   "in"            ,   50  },
            {   "include"       ,   50  },
            {   "inline"        ,   50  },
            {   "instanceof"    ,   50  },
            {   "int"           ,   50  },
            {   "interface"     ,   50  },
            {   "internal"      ,   50  },
            {   "is"            ,   50  },
            {   "let"           ,   50  },
            {   "local"         ,   50  },
            {   "lock"          ,   50  },
            {   "long"          ,   50  },
            {   "nameof"        ,   50  },
            {   "namespace"     ,   50  },
            {   "native"        ,   50  },
            {   "new"           ,   50  },
            {   "nil"           ,   50  },
            {   "not"           ,   50  },
            {   "null"          ,   50  },
            {   "nullptr"       ,   50  },
            {   "object"        ,   50  },
            {   "operator"      ,   50  },
            {   "or"            ,   50  },
            {   "out"           ,   50  },
            {   "override"      ,   50  },
            {   "package"       ,   50  },
            {   "params"        ,   50  },
            {   "partial"       ,   50  },
            {   "private"       ,   50  },
            {   "protected"     ,   50  },
            {   "public"        ,   50  },
            {   "readonly"      ,   50  },
            {   "ref"           ,   50  },
            {   "regiser"       ,   50  },
            {   "remove"        ,   50  },
            {   "repeat"        ,   50  },
            {   "replace"       ,   50  },
            {   "restrict"      ,   50  },
            {   "return"        ,   50  },
            {   "root"          ,   50  },
            {   "sbyte"         ,   50  },
            {   "sealed"        ,   50  },
            {   "set"           ,   50  },
            {   "short"         ,   50  },
            {   "signed"        ,   50  },
            {   "sizeof"        ,   50  },
            {   "static"        ,   50  },
            {   "strictfp"      ,   50  },
            {   "string"        ,   50  },
            {   "struct"        ,   50  },
            {   "super"         ,   50  },
            {   "switch"        ,   50  },
            {   "synchronized"  ,   50  },
            {   "template"      ,   50  },
            {   "then"          ,   50  },
            {   "this"          ,   50  },
            {   "throw"         ,   50  },
            {   "throws"        ,   50  },
            {   "transient"     ,   50  },
            {   "true"          ,   50  },
            {   "try"           ,   50  },
            {   "typedef"       ,   50  },
            {   "typeof"        ,   50  },
            {   "uint"          ,   50  },
            {   "ulong"         ,   50  },
            {   "unchecked"     ,   50  },
            {   "union"         ,   50  },
            {   "unsafe"        ,   50  },
            {   "unsigned"      ,   50  },
            {   "until"         ,   50  },
            {   "ushort"        ,   50  },
            {   "using"         ,   50  },
            {   "value"         ,   50  },
            {   "var"           ,   50  },
            {   "virtual"       ,   50  },
            {   "void"          ,   50  },
            {   "volatile"      ,   50  },
            {   "when"          ,   50  },
            {   "where"         ,   50  },
            {   "while"         ,   50  },
            {   "with"          ,   50  },
            {   "yield"         ,   50  }
        };

        private static NFA.State state_Start = null;

        public static NFA CreateNFA()
        {
            if (Honey.state_Start != null)
                return new NFA(Honey.state_Start);

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
            NFA.State state_Float128 = new NFA.State("Float128", 15);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeFloat));
            state_Integer.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_MayBeFloat));
            state_Integer.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float32, "f", "F"));
            state_Integer.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float64, "d", "D"));
            state_Integer.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float128, "m", "M"));
            state_MayBeFloat.transitions.Add(NFA.TransitionFactory.Number(state_Float));
            state_Float.transitions.Add(NFA.TransitionFactory.Number(state_Float));
            state_Float.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float32, "f", "F"));
            state_Float.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float64, "d", "D"));
            state_Float.transitions.Add(NFA.TransitionFactory.ElementOf(state_Float128, "m", "M"));

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

            /* 运算符识别 */

            NFA.State state_Op_Equal = new NFA.State("=", 10);
            NFA.State state_Op_EqualTo = new NFA.State("==", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_Equal));
            state_Op_Equal.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_EqualTo));

            NFA.State state_Op_Greater = new NFA.State(">", 10);
            NFA.State state_Op_GreaterEqual = new NFA.State(">=", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(">", state_Op_Greater));
            state_Op_Greater.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_GreaterEqual));

            NFA.State state_Op_Less = new NFA.State("<", 10);
            NFA.State state_Op_LessEqual = new NFA.State("<=", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("<", state_Op_Less));
            state_Op_Less.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_LessEqual));

            NFA.State state_Op_Input = new NFA.State(">>", 10);
            NFA.State state_Op_Output = new NFA.State("<<", 10);

            state_Op_Greater.transitions.Add(NFA.TransitionFactory.EqualTo(">", state_Op_Input));
            state_Op_Less.transitions.Add(NFA.TransitionFactory.EqualTo("<", state_Op_Output));

            NFA.State state_Op_BitAnd = new NFA.State("&", 10);
            NFA.State state_Op_And = new NFA.State("&&", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("&", state_Op_BitAnd));
            state_Op_BitAnd.transitions.Add(NFA.TransitionFactory.EqualTo("&", state_Op_And));

            NFA.State state_Op_BitOr = new NFA.State("|", 10);
            NFA.State state_Op_Or = new NFA.State("||", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("|", state_Op_BitOr));
            state_Op_BitOr.transitions.Add(NFA.TransitionFactory.EqualTo("|", state_Op_Or));

            NFA.State state_Op_Not = new NFA.State("!", 10);
            NFA.State state_Op_BitNot = new NFA.State("~", 10);
            NFA.State state_Op_BitXor = new NFA.State("^", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("!", state_Op_Not));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("~", state_Op_BitNot));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("^", state_Op_BitXor));

            NFA.State state_Op_Add = new NFA.State("+", 10);
            NFA.State state_Op_AddOne = new NFA.State("++", 10);
            NFA.State state_Op_AddSelf = new NFA.State("+=", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("+", state_Op_Add));
            state_Op_Add.transitions.Add(NFA.TransitionFactory.EqualTo("+", state_Op_AddOne));
            state_Op_Add.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_AddSelf));

            NFA.State state_Op_Sub = new NFA.State("-", 10);
            NFA.State state_Op_SubOne = new NFA.State("--", 10);
            NFA.State state_Op_SubSelf = new NFA.State("-=", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("-", state_Op_Sub));
            state_Op_Sub.transitions.Add(NFA.TransitionFactory.EqualTo("-", state_Op_SubOne));
            state_Op_Sub.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_SubSelf));

            NFA.State state_Op_Mul = new NFA.State("*", 10);
            NFA.State state_Op_MulSelf = new NFA.State("*=", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("*", state_Op_Mul));
            state_Op_Mul.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_MulSelf));

            NFA.State state_Op_Dev = new NFA.State("/", 10);
            NFA.State state_Op_DevSelf = new NFA.State("/=", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("/", state_Op_Dev));
            state_Op_Dev.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_DevSelf));

            NFA.State state_Op_Rem = new NFA.State("%", 10);
            NFA.State state_Op_RemSelf = new NFA.State("%=", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("%", state_Op_Rem));
            state_Op_Rem.transitions.Add(NFA.TransitionFactory.EqualTo("=", state_Op_RemSelf));

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("(", new NFA.State("(", 50)));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(")", new NFA.State(")", 50)));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("[", new NFA.State("[", 50)));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("]", new NFA.State("]", 50)));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("{", new NFA.State("{", 50)));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("}", new NFA.State("}", 50)));

            NFA.State state_Op_Colon = new NFA.State(":", 10);
            NFA.State state_Op_Namespace = new NFA.State("::", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(":", state_Op_Colon));
            state_Op_Colon.transitions.Add(NFA.TransitionFactory.EqualTo(":", state_Op_Namespace));

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(";", new NFA.State(";", 10)));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(",", new NFA.State(",", 10)));
            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("?", new NFA.State("?", 10)));

            NFA.State state_Op_SQM_S = new NFA.State("'", 10);
            NFA.State state_Op_SQM_D = new NFA.State("''", -1);
            NFA.State state_Op_SQM_T = new NFA.State("'''", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("'", state_Op_SQM_S));
            state_Op_SQM_S.transitions.Add(NFA.TransitionFactory.EqualTo("'", state_Op_SQM_D));
            state_Op_SQM_D.transitions.Add(NFA.TransitionFactory.EqualTo("'", state_Op_SQM_T));

            NFA.State state_Op_DQM_S = new NFA.State("\"", 10);
            NFA.State state_Op_DQM_D = new NFA.State("\"\"", -1);
            NFA.State state_Op_DQM_T = new NFA.State("\"\"\"", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo("\"", state_Op_DQM_S));
            state_Op_DQM_S.transitions.Add(NFA.TransitionFactory.EqualTo("\"", state_Op_DQM_D));
            state_Op_DQM_D.transitions.Add(NFA.TransitionFactory.EqualTo("\"", state_Op_DQM_T));

            NFA.State state_Op_Dot_S = new NFA.State(".", 10);
            NFA.State state_Op_Dot_D = new NFA.State("..", -1);
            NFA.State state_Op_Dot_T = new NFA.State("...", 10);

            state_Start.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_Op_Dot_S));
            state_Op_Dot_S.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_Op_Dot_D));
            state_Op_Dot_D.transitions.Add(NFA.TransitionFactory.EqualTo(".", state_Op_Dot_T));

            Honey.state_Start = state_Start;
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