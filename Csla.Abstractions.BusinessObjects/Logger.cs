using System;
using Csla.Abstractions.BusinessObjects.Contracts;

namespace Csla.Abstractions.BusinessObjects
{
	public sealed class Logger
		: ILogger
	{
		public void Log(string message)
		{
			Console.Out.WriteLine(message);
		}
	}
}
