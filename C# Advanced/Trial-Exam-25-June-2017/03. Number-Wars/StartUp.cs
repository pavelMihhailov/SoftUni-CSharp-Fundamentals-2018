using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Queue<string> firstPlayerDeck = new Queue<string>(Console.ReadLine().Split());
        Queue<string> secondPlayerDeck = new Queue<string>(Console.ReadLine().Split());
        
        int turns = 0;

        while (firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0 && turns < 1000000)
        {
            turns++;
            List<string> winningCards = new List<string>();

            string firstPlayerCard = firstPlayerDeck.Dequeue();
            string secondPlayerCard = secondPlayerDeck.Dequeue();
            winningCards.Add(firstPlayerCard);
            winningCards.Add(secondPlayerCard);

            int firstPlayerHand = PowerOfNumbers(firstPlayerCard);
            int secondPlayerHand = PowerOfNumbers(secondPlayerCard);

            if (firstPlayerHand == secondPlayerHand)
            {
                War(firstPlayerDeck, secondPlayerDeck, winningCards);
            }
            else if (firstPlayerHand > secondPlayerHand)
            {
                firstPlayerDeck.Enqueue(firstPlayerCard);
                firstPlayerDeck.Enqueue(secondPlayerCard);
            }
            else
            {
                secondPlayerDeck.Enqueue(secondPlayerCard);
                secondPlayerDeck.Enqueue(firstPlayerCard);
            }
        }
        if (firstPlayerDeck.Count < secondPlayerDeck.Count) Console.WriteLine($"Second player wins after {turns} turns");
        else if (secondPlayerDeck.Count < firstPlayerDeck.Count) Console.WriteLine($"First player wins after {turns} turns");
        else Console.WriteLine($"Draw after {turns} turns");
    }

    private static void PutCardsInDeck(Queue<string> firstPlayerDeck, List<string> winningCards)
    {
        foreach (var card in winningCards.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1))).ThenByDescending(x => x[x.Length - 1]))
        {
            firstPlayerDeck.Enqueue(card);
        }
    }

    private static void War(Queue<string> firstPlayerDeck, Queue<string> secondPlayerDeck, List<string> winningCards)
    {
        int startCount = 2;
        while (true)
        {
            int firstPlayerSum3Cards = 0;
            int secondPlayerSum3Cards = 0;

            while (firstPlayerDeck.Count > 0 && winningCards.Count < startCount + 3)
            {
                string currCard = firstPlayerDeck.Dequeue();
                firstPlayerSum3Cards += currCard[currCard.Length - 1];
                winningCards.Add(currCard);
            }
            while (secondPlayerDeck.Count > 0 && winningCards.Count < startCount + 6)
            {
                string currCard = secondPlayerDeck.Dequeue();
                secondPlayerSum3Cards += currCard[currCard.Length - 1];
                winningCards.Add(currCard);
            }

            if (winningCards.Count < startCount + 2) break;

            if (firstPlayerSum3Cards > secondPlayerSum3Cards)
            {
                PutCardsInDeck(firstPlayerDeck, winningCards);
                break;
            }
            if (secondPlayerSum3Cards > firstPlayerSum3Cards)
            {
                PutCardsInDeck(secondPlayerDeck, winningCards);
                break;
            }
            if (secondPlayerSum3Cards != firstPlayerSum3Cards) break;
            startCount = winningCards.Count;
        }
    }

    private static int PowerOfNumbers(string card)
    {
        int powerOfCard = int.Parse(card.Substring(0, card.Length - 1));
        return powerOfCard;
    }
}