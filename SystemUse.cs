using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willy.Core;

namespace Willy
{
    class SystemUse : WilliamsAspects
    {
        public interface Accessable
        {
            void Use();
        }

        public static string[] Objectives = new string[]
        {
            "greeting",
            "greetings",
            "message",
            "william"
        };

        public static object[] AddArray(object[] current, object addition)
        {
            object[] a = new object[current.Length + 1];
            for (int i = 0; i < current.Length; i++)
            {
                a[i] = current[i];
            }
            a[a.Length - 1] = addition;
            return a;
        }

        public static string[] AddString(string[] current, string addition)
        {
            string[] a = new string[current.Length + 1];
            for (int i = 0; i < current.Length; i++)
            {
                a[i] = current[i];
            }
            a[a.Length - 1] = addition;
            return a;
        }

        public static string FindObjective(string[] words)
        {
            for (int x = 0; x < words.Length; x++)
            {
                for (int y = 0; y < Objectives.Length; y++)
                {
                    if (words[x].ToLower() == Objectives[y].ToLower())
                        return words[x];
                }
            }

            return "error";
        }

        public static Action FindAction(string[] words, Dictionary<string, Action> Actions)
        {
            try
            {
                for (int x = 0; x < words.Length; x++)
                {
                    Action ob;
                    Actions.TryGetValue(words[x], out ob);
                    if (ob != null)
                    {
                        return ob;
                    }
                }

                return null;
            } catch (Exception e)
            {
                Handler.Inst.WilliamsOutput("Exception(s) Where Unfortunately Thrown:\n" + e.StackTrace);
                return null;
            }
        }

        public static string[] BreakDownSentence(string line)
        {
            string[] a = new string[0];
            string current = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '.' || line[i] == ',' || line[i] == '?' || line[i] == '!' || line[i] == ' ')
                {
                    a = AddString(a, current);
                    current = "";
                } else
                {
                    current += line[i];
                }
            }

            a = AddString(a, current);
            current = "";

            return a;
        }
    }
}
