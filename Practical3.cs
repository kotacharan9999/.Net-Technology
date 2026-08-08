
using System;
using System.Collections.Generic;

class Expense
{
    public string Product;
    public decimal Amount;
}

class Program
{
    static void Main()
    {
        List<Expense> expenses = new List<Expense>();

        try
        {
            // First Expense
            Console.Write("Enter First Expense: ");
            string product1 = Console.ReadLine();

            Console.Write("Enter amount: ");
            decimal amount1 = Convert.ToDecimal(Console.ReadLine());

            if (amount1 <= 0)
            {
                throw new Exception("Amount must be greater than 0");
            }

            Expense e1 = new Expense();
            e1.Product = product1;
            e1.Amount = amount1;

            expenses.Add(e1);


            // Second Expense
            Console.Write("Enter Second Expense: ");
            string product2 = Console.ReadLine();

            Console.Write("Enter amount: ");
            decimal amount2 = Convert.ToDecimal(Console.ReadLine());

            if (amount2 <= 0)
            {
                throw new Exception("Amount must be greater than 0");
            }

            Expense e2 = new Expense();
            e2.Product = product2;
            e2.Amount = amount2;

            expenses.Add(e2);


            // Calculate Total
            decimal total = 0;

            foreach (Expense x in expenses)
            {
                total = total + x.Amount;
            }

            Console.WriteLine("Total Expenses: " + total);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
