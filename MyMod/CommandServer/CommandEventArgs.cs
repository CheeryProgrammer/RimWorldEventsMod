using System;

namespace MyMod.CommandServer
{
	public class CommandEventArgs: EventArgs
	{
		public string Message { get; private set; }
		public CommandEventArgs(string message) : base()
		{
			Message = message;
		}
	}
}
