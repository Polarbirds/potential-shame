using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muncher.Shared
{
    class Game
    {
        private Dictionary<string, User> users;

        public Game(Preset preset)
        {
            users = new Dictionary<string, User>();
        }
    }
}
