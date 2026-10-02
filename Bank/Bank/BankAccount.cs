using System.Text;

namespace Bank;

public class BankAccount
{
    private readonly decimal _minimalBalace;
    private List<Transaction> _allTransactions = new List<Transaction>();
    public string Owner { get; private set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }
    public string Number { get; }
    private static int s_accountNumberSeed = 1000000000;
    public BankAccount(string name, decimal initialBalance):this (name , initialBalance,0)
    {
    }
    public BankAccount(string name, decimal initialBalance, decimal minimalBalance) 
    {
    
        Owner = name; // this.Owner = name;
      
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        _minimalBalace = minimalBalance;

        if (initialBalance>0) 
  MakeDeposit(initialBalance, DateTime.UtcNow, "initial balance");
    }

    

        public void MakeDeposit(decimal amount, DateTime date, string note)
      {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException
                    (nameof(amount), "Amount of deposit must be positive");
        }

        var deposite = new Transaction(amount, date, note);
        _allTransactions.Add(deposite);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        Transaction? OverdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimalBalace);
        Transaction? withdrawal = new(-amount, date, note);

        _allTransactions.Add(withdrawal);

        if (OverdraftTransaction is not null)
            _allTransactions.Add(OverdraftTransaction);

    }

    //  модификатор доступа , который  означает. что его можно вызвать, только из текущего и  дочернего класса 
   // клиент(внешний код ) данный метод вызвать не может 
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)

    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient rubls for this withdrawal");

        }
        else
        {
            return default;
        }
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" +
                $"{item.Date.ToShortDateString()}\t+" +
                $"{item.Amount}\t {balance}\t{item.Note}");

        }
        return report.ToString();
    }

    // ключевое слово virtual позволяет в дочернем классе предоставить другую реализцаию этого метода  PerformMonthAndTransaction

    public virtual void PerformMonthAndTransaction()
    { 
     
    }


    public override string ToString()
    {
        return $"Owner: {Owner}\t account number: {Number} ( type of shit {GetType()})";
    }
}
