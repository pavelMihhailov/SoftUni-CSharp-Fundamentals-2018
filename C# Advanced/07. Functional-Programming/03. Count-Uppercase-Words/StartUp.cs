using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        Func<string, bool> checker = w => Char.IsUpper(w[0]);

        List<string> input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        
        input.Where(checker).ToList().ForEach(w => Console.WriteLine(w));
    }
}
