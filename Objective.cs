using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willy.Core
{
    public abstract class Objective : WilliamsFunctions
    {
        public abstract Dictionary<string, Action> GetActions();

        public string name;

        public Objective(string _name)
        {
            name = _name;
        }

        public interface Accessable
        {
            void Use();
        }
    }
}
