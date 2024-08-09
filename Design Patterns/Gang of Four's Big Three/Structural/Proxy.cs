using System;

// The interface that both the real subject and proxy will use
public interface IBankAccount
{
  void Deposit(decimal amount);
  bool Withdraw(decimal amount);
  decimal GetBalance();
}

// The real subject class
public class RealBankAccount : IBankAccount
{
  private decimal balance;
  private string accountNumber;

  public RealBankAccount(string accountNumber)
  {
    this.accountNumber = accountNumber;
    this.balance = 0;
  }

  public void Deposit(decimal amount)
  {
    balance += amount;
    Console.WriteLine($"Deposited ${amount}. New balance: ${balance}");
  }

  public bool Withdraw(decimal amount)
  {
    if (balance >= amount)
    {
      balance -= amount;
      Console.WriteLine($"Withdrawn ${amount}. New balance: ${balance}");
      return true;
    }
    Console.WriteLine("Insufficient funds.");
    return false;
  }

  public decimal GetBalance()
  {
    return balance;
  }
}

// The proxy class
public class BankAccountProxy : IBankAccount
{
  private RealBankAccount realAccount;
  private string accountNumber;
  private string accountHolder;

  public BankAccountProxy(string accountNumber, string accountHolder)
  {
    this.accountNumber = accountNumber;
    this.accountHolder = accountHolder;
  }

  private void InitializeRealAccount()
  {
    if (realAccount == null)
    {
      Console.WriteLine("Creating real account object...");
      realAccount = new RealBankAccount(accountNumber);
    }
  }

  public void Deposit(decimal amount)
  {
    InitializeRealAccount();
    Console.WriteLine($"Proxy: Logging deposit operation for {accountHolder}");
    realAccount.Deposit(amount);
  }

  public bool Withdraw(decimal amount)
  {
    InitializeRealAccount();
    Console.WriteLine($"Proxy: Checking withdrawal limit for {accountHolder}");
    if (amount > 1000)
    {
      Console.WriteLine("Proxy: Withdrawal amount exceeds daily limit.");
      return false;
    }
    Console.WriteLine($"Proxy: Logging withdrawal operation for {accountHolder}");
    return realAccount.Withdraw(amount);
  }

  public decimal GetBalance()
  {
    InitializeRealAccount();
    Console.WriteLine($"Proxy: Logging balance inquiry for {accountHolder}");
    return realAccount.GetBalance();
  }
}

class Program
{
  static void Main(string[] args)
  {
    IBankAccount account = new BankAccountProxy("123456", "John Doe");

    account.Deposit(500);
    account.Withdraw(200);
    account.Withdraw(1500);
    Console.WriteLine($"Final balance: ${account.GetBalance()}");
  }
}