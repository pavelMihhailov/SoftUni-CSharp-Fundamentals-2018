using System;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
        this.Weight += 0.35 * food.Quantity;
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}
