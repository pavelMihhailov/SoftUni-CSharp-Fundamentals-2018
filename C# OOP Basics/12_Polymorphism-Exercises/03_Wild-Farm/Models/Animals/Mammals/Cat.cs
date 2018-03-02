using System;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;

        if (foodType.Equals("Vegetable") || foodType.Equals("Meat"))
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.30 * food.Quantity;
        }
        else throw new CantEatThatFoodException("Cat", foodType);
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}
