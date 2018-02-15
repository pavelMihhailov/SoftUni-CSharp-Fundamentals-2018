using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

public class Program
{
    public static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();

        while (true)
        {
            string[] line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            if (line[0] == "Tournament") break;

            string trainerName = line[0];
            string pokemonName = line[1];
            string pokemonElement = line[2];
            int pokemonHealth = int.Parse(line[3]);

            Trainer newTrainer = new Trainer(trainerName);
            Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (trainers.Any(x => x.Name.Equals(newTrainer.Name)))
            {
                trainers.FirstOrDefault(x => x.Name.Equals(trainerName)).PokemonCollection.Add(newPokemon);
            }
            else
            {
                newTrainer.PokemonCollection.Add(newPokemon);
                trainers.Add(newTrainer);
            }
             
        }

        while (true)
        {
            string element = Console.ReadLine();
            if (element == "End") break;

            foreach (var trainer in trainers)
            {
                if (trainer.PokemonCollection.Any(x => x.Element.Equals(element)))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.PokemonCollection.ForEach(x => x.Health -= 10);
                    for (int i = 0; i < trainer.PokemonCollection.Count; i++)
                    {
                        if (trainer.PokemonCollection[i].Health <= 0)
                        {
                            trainer.PokemonCollection.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonCollection.Count}");
        }
    }
}
