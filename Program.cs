Console.WriteLine("Welcome to my Banking System (Coded) NEW UI");

Console.Write("Name: ");
var name = Console.ReadLine();

Console.Write("Account Number: ");
var accountNumber =  Console.ReadLine();

Console.Write("Intial Balance (in KD): ");
var initalAmount = decimal.Parse(Console.ReadLine());

var myAccount = new BankAccount(name, accountNumber, initalAmount);
var choice = DisplayMenu();
do
{
    switch (choice)
    {
        case Choice.Deposit:
            Console.Write("What the amount for deposit: ");
            var deposit = Decimal.Parse(Console.ReadLine());
            myAccount.Deposit(deposit);

            break;
        case Choice.Withdraw:
            Console.Write($"What the ammount for withdrawal (Max Allowed: {myAccount.GetBalance()}): ");
            var withdrawal = Decimal.Parse(Console.ReadLine());
            myAccount.Withdraw(withdrawal);
            break;
        case Choice.ViewBalance:
            Console.WriteLine($"The Current balance is {myAccount.GetBalance()} KWD");
            break;
        default:
            break;
    }

    choice = DisplayMenu();
} while (choice != Choice.Quit);

Choice DisplayMenu()
{
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Withdraw");
    Console.WriteLine("3. View Balance");
    Console.WriteLine("4. Exit");

    Console.WriteLine("Choice: ");
    var choice = int.Parse(Console.ReadLine());

    return (Choice) choice;
}

enum Choice 
{
    Deposit = 1,
    Withdraw,
    ViewBalance,
    Quit
}

public class BankAccount
{
    public BankAccount(string name, string id, decimal initalBalance)
    {
        Name = name;
        Id = id;
        InitalBalance = initalBalance;
    }

    public string Name { get; }
    public string Id { get; }
    public decimal InitalBalance { get; }
    public List<decimal> Transaction { get; set; } = new();
    // public bool IsAccountForzen = false;
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Transaction.Add(amount);
        }
    }
    public void Withdraw(decimal amount)
    {
        if (amount <= GetBalance())
        {
            Transaction.Add(amount * -1);
        }
    }
    public decimal GetAllDeposit()
    {
        return Transaction.Where(r => r > 0).Sum();
    }
    public decimal GetAllWithdarwal()
    {
        return Transaction.Where(r => r < 0).Sum();
    }
    public decimal GetBalance()
    {
        return InitalBalance + Transaction.Sum();
    }
}