using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willy.res;
using Willy.Network;

namespace Willy.Core
{
    public class Handler
    {
        public static Handler Inst { get; set; }

        

        public int MaxAttempts = 5;

        public string AnnomTitle = "|...|";
        public string WillsTitle = "| William |";

        public Dictionary<string, WilliamsAspects> Williams_Aspects = new Dictionary<string, WilliamsAspects>()
        {
            {"my reference", new MyReference() },
            {"startup", new StartUp() },
            {"core", new Core() }
        };

        public Dictionary<string, Objective> Williams_Objects = new Dictionary<string, Objective>()
        {
            {"greeting", new Settings() },
            {"greetings", new Settings() },
            {"message", new Usage() },
            {"william", new WilliamsPersona() }
        };

        public Dictionary<string, WilliamsFunctions> Williams_Functions = new Dictionary<string, WilliamsFunctions>()
        {
            {"add greeting", new Settings() },
            {"send message", new Usage() }
        };

        public Handler()
        {
            Inst = this;
        }

        public void WilliamsOutput(string Output)
        {
            Console.WriteLine(WillsTitle + " > " + Output + "\n");
        }
    }
}
