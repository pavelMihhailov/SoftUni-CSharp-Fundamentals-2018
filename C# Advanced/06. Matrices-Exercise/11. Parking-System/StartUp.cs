using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var size = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        var rows = int.Parse(size[0]);
        var cols = int.Parse(size[1]);

        var parking = new Dictionary<int, HashSet<int>>();

        var input = Console.ReadLine();

        while (input != "stop")
        {
            var parameters = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var entryRow = int.Parse(parameters[0]);
            var desiredRow = int.Parse(parameters[1]);
            var desiredCol = int.Parse(parameters[2]);
            
            var parkColumn = 0;

            if (!IsOccupied(parking, desiredRow, desiredCol))
                parkColumn = desiredCol;
            else
                for (var i = 1; i < cols - 1; i++)
                    if (desiredCol - i > 0 &&
                        !IsOccupied(parking, desiredRow, desiredCol - i))
                    {
                        parkColumn = desiredCol - i;
                        break;
                    }
                    else if (desiredCol + i < cols &&
                             !IsOccupied(parking, desiredRow, desiredCol + i))
                    {
                        parkColumn = desiredCol + i;
                        break;
                    }

            if (parkColumn == 0) Console.WriteLine($"Row {desiredRow} full");
            else
            {
                parking[desiredRow].Add(parkColumn);
                var steps = Math.Abs(entryRow - desiredRow) + 1 + parkColumn;
                Console.WriteLine(steps);
            }
            input = Console.ReadLine();
        }
    }
    private static bool IsOccupied(Dictionary<int, HashSet<int>> parking, int row, int col)
    {
        if (parking.ContainsKey(row))
        {
            if (parking[row].Contains(col))
                return true;
        }
        else parking.Add(row, new HashSet<int>());
        return false;
    }
}