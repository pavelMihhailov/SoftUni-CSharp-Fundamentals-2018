using System;

public class CantEatThatFoodException : Exception
{
    public CantEatThatFoodException(string animal, string food)
    {
        throw new ArgumentException($"{animal} does not eat {food}!");
    }
}
