using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willy.Core
{
    public class StartUp : WilliamsAspects
    {
        public string WilliamsGreeting()
        {
            string GreetingA = "Good ";
            string Greeting = "";
            string GreetingB = " , Mr. Barclay. It is currently " + DateTime.UtcNow.AddHours(-7);
            string ampm = DateTime.UtcNow.AddHours(-7).ToShortTimeString().Substring(DateTime.UtcNow.AddHours(-7).ToShortTimeString().Length - 2, 2);
            int Hour = DateTime.UtcNow.AddHours(-7).Hour;
            if (Hour >= 12 || Hour <= 4)
            {
                if (ampm == "PM")
                {
                    Greeting = "Afternoon";
                } else
                {
                    Greeting = ", 'Technically', Morning";
                }
            } else if (Hour > 4 || Hour < 12)
            {
                if (ampm == "PM")
                {
                    Greeting = "Evening";
                } else
                {
                    Greeting = "Morning";
                }
            }

            return GreetingA + Greeting + GreetingB;
        }

    }
}
