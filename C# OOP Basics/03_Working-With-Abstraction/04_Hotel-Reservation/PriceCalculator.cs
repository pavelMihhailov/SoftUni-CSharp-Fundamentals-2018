using System;

public class PriceCalculator
{
    public decimal TotalPrice { get; set; }
    public decimal PricePerDay { get; set; }
    public int Nights { get; set; }
    public Season SeasonType { get; set; }
    public Discount DiscountType { get; set; }

    public decimal Calculate(string[] args)
    {
        decimal pricePerDay = decimal.Parse(args[0]);
        int nights = int.Parse(args[1]);
        Season season = Enum.Parse<Season>(args[2]);
        Discount discount = Discount.None;

        if (args.Length == 4) discount = Enum.Parse<Discount>(args[3]);

        return pricePerDay * nights * (int) season * (decimal) discount/100;
    }
}