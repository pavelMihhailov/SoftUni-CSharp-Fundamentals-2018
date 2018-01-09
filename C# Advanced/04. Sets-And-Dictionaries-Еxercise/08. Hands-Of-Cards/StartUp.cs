using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, HashSet<string>> personDeck = new Dictionary<string, HashSet<string>>();
        Dictionary<string, int> personValue = new Dictionary<string, int>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "JOKER") break;
            string[] tokens = input.Split(':');
            string name = tokens[0];
            string[] cards = tokens[1].TrimStart().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            AddCardsToDeck(personDeck, name, cards);
        }
        foreach (var person in personDeck)
        {
            string[] personCards = new string[person.Value.Count];
            person.Value.CopyTo(personCards);

            int result = 0;

            for (int i = 0; i < personCards.Length; i++)
            {
                int powerValue = 0;
                int typeValue = 0;
                string card = personCards[i];
                char power = card.First();
                char type = card.Last();

                powerValue = GetPower(powerValue, power);
                typeValue = GetType(typeValue, type);
                result += powerValue * typeValue;
            }
            personValue.Add(person.Key, result);
        }
        foreach (var person in personValue)
        {
            Console.WriteLine($"{person.Key}: {person.Value}");
        }
    }

    private static int GetType(int typeValue, char type)
    {
        switch (type)
        {
            case 'S':
                typeValue = 4;
                break;
            case 'H':
                typeValue = 3;
                break;
            case 'D':
                typeValue = 2;
                break;
            case 'C':
                typeValue = 1;
                break;
        }
        return typeValue;
    }

    private static int GetPower(int powerValue, char power)
    {
        switch (power)
        {
            case '2':
                powerValue = 2;
                break;
            case '3':
                powerValue = 3;
                break;
            case '4':
                powerValue = 4;
                break;
            case '5':
                powerValue = 5;
                break;
            case '6':
                powerValue = 6;
                break;
            case '7':
                powerValue = 7;
                break;
            case '8':
                powerValue = 8;
                break;
            case '9':
                powerValue = 9;
                break;
            case '1':
                powerValue = 10;
                break;
            case 'J':
                powerValue = 11;
                break;
            case 'Q':
                powerValue = 12;
                break;
            case 'K':
                powerValue = 13;
                break;
            case 'A':
                powerValue = 14;
                break;
        }
        return powerValue;
    }

    private static void AddCardsToDeck(Dictionary<string, HashSet<string>> personDeck, string name, string[] cards)
    {
        if (!personDeck.ContainsKey(name)) personDeck.Add(name, new HashSet<string>());
        for (int i = 0; i < cards.Length; i++)
        {
            personDeck[name].Add(cards[i]);
        }
    }
}
