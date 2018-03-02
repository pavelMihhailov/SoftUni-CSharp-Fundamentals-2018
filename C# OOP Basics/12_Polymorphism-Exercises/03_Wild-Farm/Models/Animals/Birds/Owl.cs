using System;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;

        if (foodType.Equals("Meat"))
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.25 * food.Quantity;
        }
        else throw new CantEatThatFoodException("Owl", foodType);
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}
