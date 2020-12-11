/**
 * HUST-CS1801-Muzappar
 * 2020-12-07
 * ----------------------------------------------------------------------------------------------------
 * Terms of use / 使用条款
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
    public sealed class CharacterSet
    {
        public static List<string> Numbers()
        {
            return new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", };
        }
        public static List<string> LowerLetters()
        {
            return new List<string>() { "a", "b", "c", "d", "e", "f", "g",
                                        "h", "i", "j", "k", "l", "m", "n",
                                        "o", "p", "q", "r", "s", "t",
                                        "u", "v", "w", "x", "y", "z" };
        }
        public static List<string> UpperLetters()
        {
            return new List<string>() { "A", "B", "C", "D", "E", "F", "G",
                                        "H", "I", "J", "K", "L", "M", "N",
                                        "O", "P", "Q", "R", "S", "T",
                                        "U", "V", "W", "X", "Y", "Z" };
        }
        public static List<string> Letters()
        {
            return new List<string>() { "a", "b", "c", "d", "e", "f", "g",
                                        "h", "i", "j", "k", "l", "m", "n",
                                        "o", "p", "q", "r", "s", "t",
                                        "u", "v", "w", "x", "y", "z",
                                        "A", "B", "C", "D", "E", "F", "G",
                                        "H", "I", "J", "K", "L", "M", "N",
                                        "O", "P", "Q", "R", "S", "T",
                                        "U", "V", "W", "X", "Y", "Z"};
        }
        public static List<string> NumbersAndLetters()
        {
            return new List<string>() { "a", "b", "c", "d", "e", "f", "g",
                                        "h", "i", "j", "k", "l", "m", "n",
                                        "o", "p", "q", "r", "s", "t",
                                        "u", "v", "w", "x", "y", "z",
                                        "A", "B", "C", "D", "E", "F", "G",
                                        "H", "I", "J", "K", "L", "M", "N",
                                        "O", "P", "Q", "R", "S", "T",
                                        "U", "V", "W", "X", "Y", "Z",
                                        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        }
        public static List<string> Combine(List<string> A, List<string> B)
        {
            var result = new List<string>(A);
            foreach (var element in B)
                if (!result.Contains(element))
                    result.Add(element);
            return result;
        }
        public static List<string> Combine(List<string> L, params string[] S)
        {
            var result = new List<string>(L);
            foreach (var s in S)
                if (!result.Contains(s))
                    result.Add(s);
            return result;
        }
    }
    public sealed class NFA
    {
        public class State
        {
            public readonly string type;
            public readonly int priority;
            public readonly List<Transition> transitions = new List<Transition>();

            public State(string type, int priority = 0) { this.type = type; this.priority = priority; }
            public List<State> Input(string param)
            {
                List<State> result = new List<State>();
                foreach (var transition in transitions)
                {
                    State acceptedState = transition.TryTransit(param);
                    if (acceptedState == null || result.Contains(acceptedState))
                        continue;
                    result.Add(acceptedState);
                }
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public class Transition
        {
            public delegate bool ConditionDelegate(string input);

            public readonly ConditionDelegate condition;
            public readonly State targetState;

            public Transition(ConditionDelegate condition, State targetState) { this.condition = condition; this.targetState = targetState; }

            public State TryTransit(string param)
            {
                if (condition(param)) return targetState;
                return null;
            }
        }

        public static class TransitionFactory
        {
            public static Transition Any(State targetState)
            {
                return new Transition((string input) => { return true; }, targetState);
            }
            public static Transition Number(State targetState)
            {
                return new Transition((string input) =>
                {
                    return input == "0" || input == "1" || input == "2" || input == "3" || input == "4"
                        || input == "5" || input == "6" || input == "7" || input == "8" || input == "9";
                }, targetState);
            }
            public static Transition LowerLetter(State targetState)
            {
                return new Transition((string input) =>
                {
                    return input == "a" || input == "b" || input == "c" || input == "d" || input == "e"
                        || input == "f" || input == "g" || input == "h" || input == "i" || input == "j"
                        || input == "k" || input == "l" || input == "m" || input == "n" || input == "o"
                        || input == "p" || input == "q" || input == "r" || input == "s" || input == "t"
                        || input == "u" || input == "v" || input == "w" || input == "x" || input == "y" || input == "z";
                }, targetState);
            }
            public static Transition UpperLetter(State targetState)
            {
                return new Transition((string input) =>
                {
                    return input == "A" || input == "B" || input == "C" || input == "D" || input == "E"
                        || input == "F" || input == "G" || input == "H" || input == "I" || input == "J"
                        || input == "K" || input == "L" || input == "M" || input == "N" || input == "O"
                        || input == "P" || input == "Q" || input == "R" || input == "S" || input == "T"
                        || input == "U" || input == "V" || input == "W" || input == "X" || input == "Y" || input == "Z";
                }, targetState);
            }
            public static Transition Letter(State targetState)
            {
                return new Transition((string input) =>
                {
                    return input == "a" || input == "b" || input == "c" || input == "d" || input == "e"
                        || input == "f" || input == "g" || input == "h" || input == "i" || input == "j"
                        || input == "k" || input == "l" || input == "m" || input == "n" || input == "o"
                        || input == "p" || input == "q" || input == "r" || input == "s" || input == "t"
                        || input == "u" || input == "v" || input == "w" || input == "x" || input == "y" || input == "z"
                        || input == "A" || input == "B" || input == "C" || input == "D" || input == "E"
                        || input == "F" || input == "G" || input == "H" || input == "I" || input == "J"
                        || input == "K" || input == "L" || input == "M" || input == "N" || input == "O"
                        || input == "P" || input == "Q" || input == "R" || input == "S" || input == "T"
                        || input == "U" || input == "V" || input == "W" || input == "X" || input == "Y" || input == "Z";
                }, targetState);
            }
            public static Transition NumberAndLetter(State targetState)
            {
                return new Transition((string input) =>
                {
                    return input == "0" || input == "1" || input == "2" || input == "3" || input == "4"
                        || input == "5" || input == "6" || input == "7" || input == "8" || input == "9"
                        || input == "a" || input == "b" || input == "c" || input == "d" || input == "e"
                        || input == "f" || input == "g" || input == "h" || input == "i" || input == "j"
                        || input == "k" || input == "l" || input == "m" || input == "n" || input == "o"
                        || input == "p" || input == "q" || input == "r" || input == "s" || input == "t"
                        || input == "u" || input == "v" || input == "w" || input == "x" || input == "y" || input == "z"
                        || input == "A" || input == "B" || input == "C" || input == "D" || input == "E"
                        || input == "F" || input == "G" || input == "H" || input == "I" || input == "J"
                        || input == "K" || input == "L" || input == "M" || input == "N" || input == "O"
                        || input == "P" || input == "Q" || input == "R" || input == "S" || input == "T"
                        || input == "U" || input == "V" || input == "W" || input == "X" || input == "Y" || input == "Z";
                }, targetState);
            }
            public static Transition EqualTo(string param, State targetState)
            {
                return new Transition((string input) =>
                {
                    return param == input;
                }, targetState);
            }
            public static Transition ElementOf(List<string> paramList, State targetState)
            {
                return new Transition((string input) =>
                {
                    foreach (string param in paramList)
                        if (input == param)
                            return true;
                    return false;
                }, targetState);
            }
            public static Transition ElementOf(State targetState, params string[] paramList)
            {
                return new Transition((string input) =>
                {
                    foreach (string param in paramList)
                        if (input == param)
                            return true;
                    return false;
                }, targetState);
            }
        }

        private struct Record
        {
            public readonly string value;
            public readonly List<State> states;

            public Record(string value, List<State> states) { this.value = value; this.states = states; }
        }

        private List<State> states = new List<State>();
        private Stack<Record> records = new Stack<Record>();

        private string value = "";
        private bool changed = false;

        public NFA(State startState)
        {
            states.Add(startState);
        }

        public void Input(string param)
        {
            List<State> nextStates = new List<State>();
            foreach (State currentState in states)
            {
                List<State> acceptedStates = currentState.Input(param);
                if (acceptedStates == null)
                    continue;
                foreach (State acceptedState in acceptedStates)
                {
                    if (nextStates.Contains(acceptedState))
                        continue;
                    nextStates.Add(acceptedState);
                }
            }
            records.Push(new Record(value, states));
            states = nextStates;
            value += param;
            changed = true;
        }
        public string GetValue(out string type)
        {
            if (states.Count == 0)
            {
                type = null;
                return null;
            }
            if (changed)
            {
                states.Sort((State a, State b) =>
                {
                    return b.priority - a.priority;
                });
                changed = false;
            }
            type = states[0].type;
            return value;
        }
        public int GetCurrentStateCount()
        {
            return states.Count;
        }
        public int GetRecordCount()
        {
            return records.Count;
        }
        public void Return()
        {
            if (records.Count == 0)
                return;
            var record = records.Pop();
            value = record.value;
            states = record.states;
            changed = true;
        }
    }
}