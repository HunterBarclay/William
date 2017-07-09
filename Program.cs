using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willy.Core;
using Willy.res;

namespace Willy
{
    class Program
    {
        //'Logging in' Sort of speak
        static void Main(string[] args)
        {
            Handler hand = new Handler();
            WilliamsAspects _mr;
            hand.Williams_Aspects.TryGetValue("my reference", out _mr);
            MyReference mr = (MyReference)_mr;
            Console.Write(" > ");
            for (int i = 0; i <= hand.MaxAttempts; i++) {
                string a = Console.ReadLine();
                if (mr.isGreetingAccepted(a))
                {
                    break;
                }
                else if (i == hand.MaxAttempts)
                {
                    Console.WriteLine(hand.AnnomTitle + " > I recommend you speak with Mr. Barclay...");
                    Console.WriteLine("---Application Abort Requested---");
                    Console.ReadKey();
                    return;
                } else
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine(hand.AnnomTitle + " > I'm Sorry?");
                            Console.Write(" > ");
                            break;
                        case 1:
                            Console.WriteLine(hand.AnnomTitle + " > Pardon?");
                            Console.Write(" > ");
                            break;
                        case 2:
                            Console.WriteLine(hand.AnnomTitle + " > What?");
                            Console.Write(" > ");
                            break;
                        default:
                            Console.WriteLine(hand.AnnomTitle + " > I don't Understand that.");
                            Console.Write(" > ");
                            break;
                    }
                }
            }
            WilliamsAspects wa;
            hand.Williams_Aspects.TryGetValue("startup", out wa);
            StartUp Su = (StartUp)wa;
            hand.WilliamsOutput(Su.WilliamsGreeting());
            hand.Williams_Aspects.TryGetValue("core", out wa);
            Willy.Core.Core c = (Willy.Core.Core)wa;
            c.Start();
            Console.ReadKey();
        }
    }
}
