using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;

    public class GiftCardAccount:BankAccount    
    {

    // при создании объекта имя\баласн
    //  
    private readonly decimal _monthlyDeposit = 0m;
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)

        : base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;
    public override void PerformMonthAndTransaction()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add Monthly Deposit ");
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"monthly deposit : {_monthlyDeposit }";

    }
    
    


    }


   

