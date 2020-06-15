using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
  class Program
  {
    class Transaction
    {
      public int Amount { get; set; }
      public string Type { get; set; } //Deposit or Withdraaw

      public string Account { get; set; } //Checkings or Savings
    }
    public static int PromptForInt(string prompt)
    {
      while (true)
      {
        Console.Write(prompt);

        var userInput = 0;

        var goodInputPotential = int.TryParse(Console.ReadLine(), out userInput);

        if (goodInputPotential && userInput >= 0)
        {
          return userInput;
        }
        else
        {
          Console.WriteLine("Not valid input.");
        }
      }
    }
    private static int CheckingBalance(List<Transaction> transactions)
    {
      var checkingDepositTotal = TransactionsTotal(transactions, "Checking", "Deposit");
      var checkingWithdrawTotal = TransactionsTotal(transactions, "Checking", "Withdraw");
      var checkingBalance = checkingDepositTotal - checkingWithdrawTotal;

      return checkingBalance;
    }
    private static int SavingsBalance(List<Transaction> transactions)
    {
      var savingsDepositTotal = TransactionsTotal(transactions, "Savings", "Deposit");
      var savingsWithdrawTotal = TransactionsTotal(transactions, "Savings", "Withdraw");
      var savingsBalance = savingsDepositTotal - savingsWithdrawTotal;

      return savingsBalance;
    }
    static int TransactionsTotal(List<Transaction> transactions, string account, string type)
    {
      var total = transactions.
          Where(transactions => transactions.Account == account && transactions.Type == type).
          Sum(transactions => transactions.Amount);

      return total;
    }
    static void Main(string[] args)
    {
      var reader = new StreamReader("transactions.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      var transactions = csvReader.GetRecords<Transaction>().ToList();


      var option = "";

      while (option != "Q")
      {
        Console.WriteLine();
        Console.WriteLine("DC - Deposit to Checking");
        Console.WriteLine("DS - Deposit to Savings");
        Console.WriteLine("WC - Withdraw from Checking");
        Console.WriteLine("WS - Withdraw from Savings");
        Console.WriteLine("B - Show my account balances");
        Console.WriteLine("Q - Quit");
        Console.WriteLine();
        Console.WriteLine("What do you want me to do? ");
        option = Console.ReadLine();

        if (option == "B")
        {
          int savingsBalance = SavingsBalance(transactions);
          var checkingBalance = CheckingBalance(transactions);

          Console.WriteLine($"Your checking  balance is ${checkingBalance} and your savings balance is ${savingsBalance}");
        }

        if (option == "DC")
        {
          var amount = PromptForInt("How much to deposit in Checking? ");
          var newTransaction = new Transaction { Type = "Deposit", Account = "Checking", Amount = amount };
          transactions.Add(newTransaction);
        }
        if (option == "DS")
        {
          var amount = PromptForInt("How much to deposit in Savings? ");

          var newTransaction = new Transaction { Type = "Deposit", Account = "Savings", Amount = amount };
          transactions.Add(newTransaction);
        }
        if (option == "WC")
        {
          var amount = PromptForInt("How much to withdraw from Checking? ");

          int checkingBalance = CheckingBalance(transactions);

          if (amount > CheckingBalance(transactions))
          {
            Console.WriteLine("No overdraft at First Bank of Suncoast");
          }

          var newTransaction = new Transaction { Type = "Withdraw", Account = "Checking", Amount = amount };
          transactions.Add(newTransaction);
        }
        if (option == "WS")
        {
          var amount = PromptForInt("How much to withdraw from Savings? ");

          if (amount > SavingsBalance(transactions))
          {
            Console.WriteLine("No overdraft at First Bank of Suncoast");
          }
          else
          {
            var newTransaction = new Transaction { Type = "Withdraw", Account = "Savings", Amount = amount };
            transactions.Add(newTransaction);
          }

        }

      }
      var writer = new StreamWriter("transactions.csv");

      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

      csvWriter.WriteRecords(transactions);

      writer.Close();

    }


  }
}
