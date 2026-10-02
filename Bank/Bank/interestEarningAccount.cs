using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;
public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance)
     : base(name, initialBalance)
    {

    }
    public override void PerformMonthAndTransaction()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow, "Apply month interest ");
        }
    }
}

