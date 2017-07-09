using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Willy.Core;

namespace Willy.res
{
    public class MyReference : WilliamsAspects
    {
        public string SavePath = @"C:\Users\Public\WilliamsMemory\Greetings.wlm";

        /*public override string[] Actions = new string[]
        {

        };*/

        public MyReference()
        {
            if (!File.Exists(SavePath))
                if (!Directory.Exists(@"C:\Users\Public\WilliamsMemory"))
                {
                    DirectoryInfo dir = Directory.CreateDirectory(@"C:\Users\Public\WilliamsMemory");
                    dir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                } else
                    Save();
            Load();
            //Console.WriteLine("Done Bitch");

            //Handler.Inst.WilliamsOutput("greetings loaded");
        }

        public string[] AcceptedGreetings = new string[]
        {
            "good morning",
            "hello",
            "wake up",
            "william",
            "good morning william",
            "evening",
            "good evening",
            "good evening william",
            "good afternoon",
            "good afternoon william",
            "hola",
            "helu",
            "hellu",
            "hiya",
        };

        public bool isGreetingAccepted(string greeting)
        {
            foreach (string a in AcceptedGreetings)
            {
                if (greeting.ToLower() == a.ToLower())
                    return true;
            }

            return false;
        }

        public void Load()
        {
            BinaryFormatter bin = new BinaryFormatter();
            FileStream s = File.OpenRead(SavePath);
            ReferenceUpdate ru = (ReferenceUpdate)bin.Deserialize(s);
            s.Close();
            AcceptedGreetings = ru.MoreGreetings;
        }

        public void Save()
        {
            BinaryFormatter bin = new BinaryFormatter();
            FileStream s = File.Create(SavePath);
            ReferenceUpdate ru = new ReferenceUpdate();
            ru.MoreGreetings = AcceptedGreetings;
            bin.Serialize(s, ru);
            s.Close();
        }
    }

    [Serializable]
    class ReferenceUpdate {
        public string[] MoreGreetings;
    }
}
