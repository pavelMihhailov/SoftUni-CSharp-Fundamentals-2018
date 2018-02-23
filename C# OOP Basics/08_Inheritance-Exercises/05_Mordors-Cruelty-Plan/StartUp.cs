using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Food> foodList = new List<Food>();

        string[] line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
        foreach (var food in line)
        {
            Food currFood = FoodFactory.GetFood(food.ToLower());
            foodList.Add(currFood);
        }

        Mood mood = MoodFactory.GetMood(foodList);

        int allPoints = foodList.Sum(x => x.HappinessPoints);
        Console.WriteLine(allPoints);
        Console.WriteLine(mood);
    }
}
