namespace FestivalManager
{
	using Core;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Entities;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			Stage stage = new Stage();

			IFestivalController festivalController = new FestivalController(stage);
			ISetController setController = new SetController(stage);

			var engine = new Engine(festivalController, setController);

			engine.Run();
		}
	}
}