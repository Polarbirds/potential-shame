using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muncher.Shared
{

    public abstract class User
    {
        protected readonly string conId;
        protected readonly string username;

        public User(string conId, string username)
        {
            this.conId = conId;
            this.username = username;
        }

        public abstract void updateStat(string username, string statId, int value);
    }
}
