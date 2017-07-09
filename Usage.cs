using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Willy.Core;

namespace Willy.Network
{
    class Usage : Objective
    {
        public Usage() : base("Usage")
        {

        }

        public class Usage_SUB : Accessable
        {
            public void Use()
            {
                Handler.Inst.WilliamsOutput("IP of receiver");
                Console.Write(" > ");
                string Ip = Console.ReadLine();
                Handler.Inst.WilliamsOutput("Port of IP");
                Console.Write(" > ");
                string _Port = Console.ReadLine();
                int Port;
                int.TryParse(_Port, out Port);
                Handler.Inst.WilliamsOutput("Message to Receiver");
                Console.Write(" > ");
                string mssg = Console.ReadLine();
                SendMessage(Ip, Port, mssg);
            }

            public void SendMessage(string _ip, int port, string message)
            {
                IPAddress Ip;
                IPAddress.TryParse(_ip, out Ip);
                EndPoint Ep = new IPEndPoint(Ip, port);
                Socket me = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                me.Connect(Ep);
                StreamWriter Sw = new StreamWriter(new NetworkStream(me));
                Sw.WriteLine(message);
                Sw.Flush();
                return;
            }
        }

        public Dictionary<string, Action> Actions = new Dictionary<string, Action>()
        {
            {"send", new Usage_SUB().Use }
        };

        public override Dictionary<string, Action> GetActions()
        {
            return Actions;
        }

        
    }
}
