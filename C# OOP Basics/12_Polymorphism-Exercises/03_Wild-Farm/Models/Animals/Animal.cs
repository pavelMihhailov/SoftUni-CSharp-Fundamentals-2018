public abstract class Animal
{
    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name { get; set; }

    public double Weight { get; set; }

    public int FoodEaten { get; set; }

    public abstract void Eat(Food food);

    public virtual void ProduceSound()
    {
    }
}
