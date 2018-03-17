using System;
public class StartUp
{
    public static void Main()
    {
        RaceTower raceTower = new RaceTower();

        Engine.StartRace(raceTower);

        raceTower.PrintWinner();
    }
}
