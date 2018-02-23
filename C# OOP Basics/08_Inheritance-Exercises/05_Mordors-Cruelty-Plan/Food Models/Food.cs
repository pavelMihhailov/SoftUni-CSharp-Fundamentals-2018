using System;

public class Food
{
    private int happinessPoints;

    protected Food(int happinessPoints)
    {
        this.happinessPoints = happinessPoints;
    }

    public virtual int HappinessPoints
    {
        get => this.happinessPoints;
        set => this.happinessPoints = value;
    }
}
