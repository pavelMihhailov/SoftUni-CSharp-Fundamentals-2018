using System;

public class Program
{
    public static void Main()
    {
        BankAccount newAcc = new BankAccount();

        newAcc.ID = 1;
        newAcc.Balance = 15;
        Console.WriteLine($"Account {newAcc.ID}, balance {newAcc.Balance}");
    }
}
