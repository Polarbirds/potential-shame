﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muncher.Shared
{
    public class Player : User
    {

        private Dictionary<string, double> stats;

        public Player(string conId, string username)
            // call baseclass constructor with given conId and username
            : base(conId, username)
        {
            // initiate stats
            stats = new Dictionary<string,double>();
        }

        public override void updateStat(string username, string statId, int value)
        {
            // if this is not the player the server thinks, do nothing
            if (base.username != username) return;
            stats[statId] = value;
        }
    }
}
