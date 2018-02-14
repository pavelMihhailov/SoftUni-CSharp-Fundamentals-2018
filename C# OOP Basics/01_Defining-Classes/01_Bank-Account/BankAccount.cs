using System;
using System.Collections.Generic;
using System.Text;

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
        get { return balance; }
        set { balance = value; }
    }
}
