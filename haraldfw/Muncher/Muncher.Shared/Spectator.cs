using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muncher.Shared
{
    class Spectator : User
    {
        private Dictionary<string, Dictionary<string, double>> stats;

        public Spectator(string conId, string username)
            // call baseclass constructor with given conId and username
            : base(conId, username)
        {
            stats = new Dictionary<string, Dictionary<string, double>>();
        }

        public override void updateStat(string username, string statId, int value)
        {
            // update given stat of given username to given value
            stats[username][statId] = value;
        }
    }
}
