using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override void Eat(Food food)
    {
        string foodType = food.GetType().Name;

        if (foodType.Equals("Meat"))
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.40 * food.Quantity;
        }
        else throw new CantEatThatFoodException("Dog", foodType);
    }

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }
}
