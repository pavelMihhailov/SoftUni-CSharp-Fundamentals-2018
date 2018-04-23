using System;
using System.Linq;
using FestivalManager.Core.IO;

namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
	using IO.Contracts;
    
	public class Engine : IEngine
	{
	    private const string LetsRockCommand = "LetsRock";
	    private const string EndCommand = "END";

        private IReader reader;
	    private IWriter writer;

	    private IFestivalController festivalCоntroller;
	    private ISetController setCоntroller;

	    public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller)
	    {
	        this.festivalCоntroller = festivalCоntroller;
	        this.setCоntroller = setCоntroller;

            reader = new Reader();
            writer = new Writer();
	    }
        
		public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

			    if (input == EndCommand)
					break;

				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}
        
	    public string ProcessCommand(string input)
		{
			var args = input.Split(" ".ToCharArray().First());

			var commandName = args.First();
			var skipedArgs = args.Skip(1).ToArray();

		    if (commandName == LetsRockCommand)
			{
				var sets = this.setCоntroller.PerformSets();
				return sets;
			}

			var festivalcontrolfunction = this.festivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == commandName);

			string a;

			try
			{
				a = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { skipedArgs });
			}
			catch (TargetInvocationException up)
			{
				throw up.InnerException;
			}

			return a;
		}
	}
}