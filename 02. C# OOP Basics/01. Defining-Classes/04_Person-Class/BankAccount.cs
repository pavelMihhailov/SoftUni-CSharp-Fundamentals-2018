﻿using System;

public class BankAccount
{
    private int id;
    private decimal balance;

    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public decimal Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (this.balance < amount)
        {
            Console.WriteLine("Insufficient balance"); return;
        }

        this.balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.id}, balance {this.balance:f2}";
    }
}