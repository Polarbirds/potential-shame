using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR.Core;

namespace Muncher.Server
{
	public class MuncherHub : Hub
	{
		Dictionary<string, Game> gamesByConId = new Dictionary<string, Game>();

		public MuncherHub ()
		{

		}

		/**
		 * Adds the context-connection to the specified group. Groups are: "players" and "watchers"
		 */
		public void JoinGroup(string groupName)  {
			Groups.Add (Context.ConnectionId, groupName);
		}

		public string CreateGame(string name, int winningLevel) {
			Game game = new Game (Context.ConnectionId, name, winningLevel, GetUniqueId ());
			return game.id;
		}

		private string GetUniqueId() {
			var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
			var random = new Random();
			var result = new string(
				Enumerable.Repeat(chars, 4)
				.Select(s => s[random.Next(s.Length)])
				.ToArray());
			if(GetGameWithId(result) == null) return result;
			return GetUniqueId();
		}

		private Game GetGameWithId(string id) {
			foreach(var pair in gamesByConId) {
				if (pair.Value.id == id)
					return pair.Value;
			}
			return null;
		}

		/**
		 * Adds the given amount to the level of the player in the context. Caps between 1 and winningLevel
		 */
		public void EditLevel(int amount) {
			Game g = gamesByConId [Context.ConnectionId];
			Player p = g.players [Context.ConnectionId];
			p.level += amount;
			if (p.level > g.winningLevel)
				p.level = g.winningLevel;
			else if (p.level < 1)
				p.level = 1;
		}

		public void EditBonus(int amount) {
			Game g = gamesByConId [Context.ConnectionId];
			Player p = g.players [Context.ConnectionId];
			p.bonus += amount;
		}

		public void EditOneShot(int amount) {
			Game g = gamesByConId [Context.ConnectionId];
			Player p = g.players [Context.ConnectionId];
			p.oneShot += amount;
		}
	}
}

