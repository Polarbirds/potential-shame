using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Muncher.Shared;


namespace Muncher.Droid
{
	[Activity (Label = "Muncher.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

			var client = new MuncherClient("Android");

			var input = FindViewById<EditText>(Resource.Id.Input);
			var messages = FindViewById<ListView>(Resource.Id.Messages);

			var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
			var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, new List<string>());

			messages.Adapter = adapter;

			await client.Connect();

			input.EditorAction +=
				delegate
			{
				inputManager.HideSoftInputFromWindow(input.WindowToken, HideSoftInputFlags.None);

				if (string.IsNullOrEmpty(input.Text))
					return;

				client.Send(input.Text);

				input.Text = "";
			};

			client.OnMessageReceived +=
				(sender, message) => RunOnUiThread(() =>
					adapter.Add(message));

		}
	}
}
