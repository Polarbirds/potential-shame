using System;

namespace Muncher.Shared
{
	public class Game {

		public readonly string adminId;
		public int winningLevel;
		public string id;

		public Dictionary<string, Player> players = new Dictionary<string, Player>();

		public Game(string adminConId, string adminName, int winningLevel, string id) {
			adminId = adminConId;
			players.Add(adminId, new Player(adminName));
			this.winningLevel = winningLevel;
			this.id = id;
		}
	}
}

