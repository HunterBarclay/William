using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willy.res;

namespace Willy.Core
{
    class Settings : Objective
    {
        public class Settings_SUB : Accessable
        {
            public void Use()
            {
                AddGreeting();
            }

            public void AddGreeting()
            {
                try
                {
                    WilliamsAspects wa;
                    Handler.Inst.Williams_Aspects.TryGetValue("my reference", out wa);
                    MyReference mr = (MyReference)wa;
                    Handler.Inst.WilliamsOutput("Type in the new greeting:");
                    Console.Write(" > ");
                    string greeting = Console.ReadLine();
                    mr.AcceptedGreetings = SystemUse.AddString(mr.AcceptedGreetings, greeting);
                    mr.Save();
                    Handler.Inst.WilliamsOutput("Greeting Added Successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public Settings() : base("Settings")
        {

        }

        public Dictionary<string, Action> Actions { get; set; } = new Dictionary<string, Action>()
        {
            {"add", new Settings_SUB().Use }
        };

        public override Dictionary<string, Action> GetActions()
        {
            return Actions;
        }
    }
}
