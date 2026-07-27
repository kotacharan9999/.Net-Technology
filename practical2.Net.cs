using System;
using System.Collections.Generic;

public interface IPayable
{
    decimal CalculatePay();
}

public abstract class Employee : IPayable
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Employee(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public abstract decimal CalculatePay();
}

public class SalariedEmployee : Employee
{
    public decimal MonthlySalary { get; set; }

    public SalariedEmployee(string name, int id, decimal salary) : base(name, id)
    {
        MonthlySalary = salary;
    }

    public override decimal CalculatePay()
    {
        return MonthlySalary;
    }
}

public class HourlyEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public decimal HoursWorked { get; set; }

    public HourlyEmployee(string name, int id, decimal rate, decimal hours) : base(name, id)
    {
        HourlyRate = rate;
        HoursWorked = hours;
    }

    public override decimal CalculatePay()
    {
        return HourlyRate * HoursWorked;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> staffList = new List<Employee>();

        Console.Write("Enter number of employees to add: ");
        if (!int.TryParse(Console.ReadLine(), out int count))
        {
            Console.WriteLine("Invalid input. Exiting.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\n--- Entering details for Employee #{i + 1} ---");
            
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Employee Type (1 for Salaried, 2 for Hourly): ");
            int type = int.Parse(Console.ReadLine());

            if (type == 1)
            {
                Console.Write("Enter Monthly Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());
                staffList.Add(new SalariedEmployee(name, id, salary));
            }
            else if (type == 2)
            {
                Console.Write("Enter Hourly Rate: ");
                decimal rate = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Hours Worked: ");
                decimal hours = decimal.Parse(Console.ReadLine());

                staffList.Add(new HourlyEmployee(name, id, rate, hours));
            }
            else
            {
                Console.WriteLine("Invalid employee type. Skipping.");
            }
        }

        Console.WriteLine("\n================ RESULTS ================");
        foreach (Employee emp in staffList)
        {
            Console.WriteLine($"Employee ID: {emp.Id}");
            Console.WriteLine($"Employee Name: {emp.Name}");
            Console.WriteLine($"Pay Amount: ${emp.CalculatePay()}");
            Console.WriteLine("-------------------");
        }
    }
}
