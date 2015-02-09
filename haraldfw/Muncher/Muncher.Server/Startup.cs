using System;
using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Muncher.Server.Startup))]

namespace Muncher.Server
{
	public class Startup 
	{
		public void Configuration(IAppBuilder app) {
			app.MapSignalR ();
		}
	}
}

