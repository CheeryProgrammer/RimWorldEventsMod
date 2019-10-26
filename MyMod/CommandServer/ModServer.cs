using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace MyMod.CommandServer
{
	public class ModServer
	{
		private readonly HttpListener _server;
		private bool _isRunning;

		public event EventHandler<CommandEventArgs> OnCommand;

		public ModServer(string prefix)
		{
			_server = new HttpListener();
			_server.Prefixes.Add(prefix);
		}

		public void Start()
		{
			_isRunning = true;
			_server.Start();
			Listen();
		}

		public void Stop()
		{
			_isRunning = false;
			_server.Stop();
		}

		private void Listen()
		{
			new Thread(() =>
			{
				while (_isRunning)
				{
					try
					{
						var context = _server.GetContext();
						ProcessRequestAsync(context);
					}
					catch { }
				}
			})
				.Start();
		}

		private void ProcessRequestAsync(HttpListenerContext context)
		{
			new Thread(() => {
				var req = context.Request;

				if(req.HttpMethod.Equals("get", StringComparison.OrdinalIgnoreCase))
				{
					if (!req.QueryString.HasKeys())
					{
						using (var sw = new StreamWriter(context.Response.OutputStream, Encoding.UTF8))
						{
							context.Response.StatusCode = 200;
							context.Response.ContentType = " text/html; charset=utf-8";
							var filePath = Path.Combine(Directory.GetCurrentDirectory(), "CommandServer\\StaticContent\\index.html");

							// DebugLogger.Log(filePath);

							if(File.Exists(filePath))
								sw.Write(File.ReadAllText(filePath));
							return;
						}
					}
				}

				if (req.HttpMethod.Equals("post", StringComparison.OrdinalIgnoreCase))
				{
					string content;
					using (var sr = new StreamReader(req.InputStream, Encoding.UTF8))
					{
						content = sr.ReadToEnd();
					}
					using (var sw = new StreamWriter(context.Response.OutputStream, Encoding.UTF8))
					{
						context.Response.StatusCode = 200;
						sw.Write($"Команда принята: {content}");
					}
					OnCommand?.Invoke(this, new CommandEventArgs(content));
					return;
				};
				using (var sw = new StreamWriter(context.Response.OutputStream, Encoding.UTF8))
				{
					context.Response.StatusCode = 404;
					sw.Write($"Че-то не понял");
				}
			})
				.Start();
		}
	}
}
