using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willy.Core
{
    class WilliamsPersona : Objective
    {
        public WilliamsPersona() : base("william")
        {

        }

        public Dictionary<string, Action> Actions = new Dictionary<string, Action>()
        {
            {"thank", new WilliamsPersona_SUB().ThankAction },
            {"thanks", new WilliamsPersona_SUB().ThankAction }
        };

        public override Dictionary<string, Action> GetActions()
        {
            return Actions;
        }

        public class WilliamsPersona_SUB : Accessable
        {
            public string[] ThanksMsgs = new string[]
            {
                "No Problem",
                "You're Welcome"
            };

            public void Use()
            {

            }

            public void ThankAction()
            {
                Random rnd = new Random();
                int i = rnd.Next(0, ThanksMsgs.Length - 1);
                Handler.Inst.WilliamsOutput(ThanksMsgs[i]);
            } 
        }
    }
}
