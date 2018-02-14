using System;

public class Program
{
    public static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.ID = 1;
        acc.Deposit(15);
        acc.Withdraw(10);

        Console.WriteLine(acc);
    }
}
