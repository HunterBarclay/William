using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willy.Core
{
    class Core : WilliamsAspects
    {
        public Handler handler;

        public bool isRunning = false;

        public void Start()
        {
            if (isRunning)
                return;
            isRunning = true;

            Running();
        }

        public void Init()
        {
            handler = Handler.Inst;
        }

        public void Running()
        {
            Init();

            while (isRunning)
            {
                Console.Write(" > ");

                string Command = Console.ReadLine();
                if (Command.ToLower() == "stop")
                {
                    break;
                }
                try
                {
                    DiscoveryRequest(Command.ToLower());
                } catch (Exception e)
                {
                    handler.WilliamsOutput("Exception(s) Where Unfortunately Thrown:\n" + e.StackTrace);
                }
            }

            Stop();
        }

        public void Stop()
        {
            if (!isRunning)
                return;
            isRunning = false;

            Console.WriteLine("---Application Abort Requested---");
        }

        public void DiscoveryRequest(string Line)
        {
            //1: Break down the sentence by each word [Declare the Action (Exception Avoidence Purposes)]
            Action Request;
            string[] words = SystemUse.BreakDownSentence(Line);

            /*foreach (string a in words)
            {
                Console.WriteLine("." + a + ".");           Just Incase Things Fuck Up. Because that is always possible when I'm coding
            }*/
            //2: Figure out the Objective referenced in the sentence
            string objective = SystemUse.FindObjective(words);
            Objective wa;
            handler.Williams_Objects.TryGetValue(objective, out wa);
            //3: Test if you even got one
            if (wa == null)
            {
                handler.WilliamsOutput("Sorry, I couldn't find what you were trying to access.");
                return;
            }
            //4: Now that you have found the users objective, figure out what Action of that objective the user wants to use
            Request = SystemUse.FindAction(words, wa.GetActions());
            //5: Test if you found an Action
            if (Request == null)
            {
                handler.WilliamsOutput("Sorry, I couldn't find the action you wanted to use in that objective");
                return;
            }
            //6: Last but not least, execute the action and hope something doesn't fuck it self
            Request();
        }
    }
}
