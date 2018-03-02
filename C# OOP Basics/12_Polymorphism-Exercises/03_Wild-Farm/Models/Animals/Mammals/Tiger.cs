using System;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;

        if (foodType.Equals("Meat"))
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 1 * food.Quantity;
        }
        else throw new CantEatThatFoodException("Tiger", foodType);
    }

    public override void ProduceSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}
