using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;

        if (foodType.Equals("Vegetable") || foodType.Equals("Fruit"))
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.10 * food.Quantity;
        }
        else throw new CantEatThatFoodException("Mouse", foodType);
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }
}
