using System;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
	public class Reader : IReader
	{
	    public string ReadLine()
	    {
	        return Console.ReadLine();
	    }
	}
}