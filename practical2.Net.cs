using System;
using System.Collections.Generic;

public interface IPayable
{
    decimal CalculatePay();
}


public abstract class Employee : IPable
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
        SalariedEmployee charan1 = new SalariedEmployee("Charan One", 101, 4000m);
        HourlyEmployee charan2 = new HourlyEmployee("Charan Two", 102, 25m, 160m);

        List<Employee> staffList = new List<Employee>();
        staffList.Add(charan1);
        staffList.Add(charan2);

        foreach (Employee emp in staffList)
        {
            Console.WriteLine($"Employee: {emp.Name}");
            Console.WriteLine($"Pay Amount: ${emp.CalculatePay()}");
            Console.WriteLine("-------------------");
        }
    }
}
