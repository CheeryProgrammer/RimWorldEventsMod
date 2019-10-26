using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MyMod
{
	class DebugLogger
	{
		public static void Log(string message)
		{
			Verse.Log.TryOpenLogWindow();
			Verse.Log.Message(message);
		}
	}
}
