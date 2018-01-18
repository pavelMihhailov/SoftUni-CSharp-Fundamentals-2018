using System;

public class StartUp
{
    public static void Main()
    {
        var heiganHealth = 3000000d;
        var playerhealth = 18500d;

        var matrix = new int[15][];

        for (var i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new int[15];
        }

        var player = new[] { 7, 7 };
        var playerDamage = double.Parse(Console.ReadLine());
        var lastAttack = string.Empty;

        while (true)
        {
            var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            heiganHealth -= playerDamage;

            if (lastAttack.Equals("Cloud"))
                playerhealth -= 3500;

            if (playerhealth <= 0 || heiganHealth <= 0) break;

            var spell = input[0];
            var startRow = int.Parse(input[1]) - 1;
            if (startRow < 0) startRow = 0;
            var endRow = int.Parse(input[1]) + 1;
            if (endRow > 14) endRow = 14;
            var startCol = int.Parse(input[2]) - 1;
            if (startCol < 0) startCol = 0;
            var endCol = int.Parse(input[2]) + 1;
            if (endCol > 14) endCol = 14;

            for (var i = startRow; i <= endRow; i++)
                for (var j = startCol; j <= endCol; j++)
                    matrix[i][j] = 1;

            if (matrix[player[0]][player[1]] == 1)
                //try go up
                if (player[0] - 1 >= 0 && matrix[player[0] - 1][player[1]] == 0)
                {
                    player[0]--;
                    lastAttack = string.Empty;
                }
                //try go right
                else if (player[1] + 1 <= 14 && matrix[player[0]][player[1] + 1] == 0)
                {
                    player[1]++;
                    lastAttack = string.Empty;
                }
                //try go down
                else if (player[0] + 1 <= 14 && matrix[player[0] + 1][player[1]] == 0)
                {
                    player[0]++;
                    lastAttack = string.Empty;
                }
                //try go left
                else if (player[1] - 1 >= 0 && matrix[player[0]][player[1] - 1] == 0)
                {
                    player[1]--;
                    lastAttack = string.Empty;
                }
                else
                {
                    if (spell.Equals("Cloud"))
                        playerhealth -= 3500;

                    else if (spell.Equals("Eruption"))
                        playerhealth -= 6000;
                    lastAttack = spell;
                }

            for (var i = startRow; i <= endRow; i++)
                for (var j = startCol; j <= endCol; j++)
                    matrix[i][j] = 0;
            if (playerhealth <= 0)
                break;
        }
        if (heiganHealth <= 0) Console.WriteLine("Heigan: Defeated!");
        else Console.WriteLine($"Heigan: {heiganHealth:f2}");

        if (playerhealth <= 0)
            if (lastAttack.Equals("Eruption"))
                Console.WriteLine($"Player: Killed by {lastAttack}");
            else Console.WriteLine($"Player: Killed by Plague {lastAttack}");
        else Console.WriteLine($"Player: {playerhealth}");

        Console.WriteLine($"Final position: {player[0]}, {player[1]}");
    }
}