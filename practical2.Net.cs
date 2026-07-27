using System;
using System.Collections.Generic;

// 1. The Interface
public interface IPayable
{
    decimal CalculatePay();
}

// 2. The Base Class (Inheritance)
public abstract class Employee : IPable
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Employee(string name, int id)
    {
        Name = name;
        Id = id;
    }

    // Subclasses must fill in this method
    public abstract decimal CalculatePay();
}

// 3. Salaried Employee Subclass
public class SalariedEmployee : Employee
{
    public decimal MonthlySalary { get; set; }

    public SalariedEmployee(string name, int id, decimal salary) : base(name, id)
    {
        MonthlySalary = salary;
    }

    // Overriding the base method
    public override decimal CalculatePay()
    {
        return MonthlySalary;
    }
}

// 4. Hourly Employee Subclass
public class HourlyEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public decimal HoursWorked { get; set; }

    public HourlyEmployee(string name, int id, decimal rate, decimal hours) : base(name, id)
    {
        HourlyRate = rate;
        HoursWorked = hours;
    }

    // Overriding the base method with multiplication math
    public override decimal CalculatePay()
    {
        return HourlyRate * HoursWorked;
    }
}

// 5. Main Program Run
class Program
{
    static void Main()
    {
        // Simple human-written object names
        SalariedEmployee charan1 = new SalariedEmployee("Charan One", 101, 4000m);
        HourlyEmployee charan2 = new HourlyEmployee("Charan Two", 102, 25m, 160m);

        // Polymorphism: Adding different objects to the same list
        List<Employee> staffList = new List<Employee>();
        staffList.Add(charan1);
        staffList.Add(charan2);

        // Loop through the list to calculate pay automatically
        foreach (Employee emp in staffList)
        {
            Console.WriteLine($"Employee: {emp.Name}");
            Console.WriteLine($"Pay Amount: ${emp.CalculatePay()}");
            Console.WriteLine("-------------------");
        }
    }
}
