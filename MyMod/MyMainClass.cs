using MyMod.CommandServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MyMod
{
	public class MyMainClass : Mod
	{
		static MyMainClass()
		{

		}

		public MyMainClass(ModContentPack content) : base(content)
		{
			var host = "localhost";
			var port = 26044;
			var server = new ModServer($"http://{host}:{port}/");
			server.Start();
			server.OnCommand += (sender, args) => DebugLogger.Log(args.Message);
		}

		public override void DoSettingsWindowContents(global::UnityEngine.Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string SettingsCategory()
		{
			return base.SettingsCategory();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void WriteSettings()
		{
			base.WriteSettings();
		}
	}
}
