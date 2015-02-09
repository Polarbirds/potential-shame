using System;

namespace Muncher.Shared
{
	public class Player {
		public string name;
		public int level  = 1;
		public int bonus = 0;
		public int oneShot = 0;

		public Player(string name) {
			this.name = name;
		}
	}
}

