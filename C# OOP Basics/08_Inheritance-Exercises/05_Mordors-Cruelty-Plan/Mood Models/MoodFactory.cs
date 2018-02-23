using System.Collections.Generic;
using System.Linq;

public class MoodFactory
{
    public static Mood GetMood(List<Food> foodList)
    {
        int totalHappiness = foodList.Sum(x => x.HappinessPoints);

        if (totalHappiness < -5) return new Angry();
        if (totalHappiness >= -5 && totalHappiness <= 0) return new Sad();
        if (totalHappiness >= 1 && totalHappiness <= 15) return new Happy();
        return new JavaScript();
    }
}
