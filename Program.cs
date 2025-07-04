using System;
using System.Collections.Generic;

abstract class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SIN { get; set; }
    public Employee ManagedBy { get; set; }
    private static int numEmployees = 0;

    public Employee(string firstName, string lastName, string sin, Employee managedBy = null)
    {
        FirstName = firstName;
        LastName = lastName;
        SIN = sin;
        ManagedBy = managedBy ?? this;
        numEmployees++;
    }

    public static int Count()
    {
        return numEmployees;
    }

    public override bool Equals(object obj)
    {
        if (obj is Employee otherEmployee)
        {
            return this.SIN == otherEmployee.SIN;
        }
        return false;
    }

    public abstract double Earnings();

    public override string ToString()
    {
        return $"Employee: {LastName}, {FirstName}\nSIN: {SIN}";
    }
}

class SalariedEmployee : Employee
{
    public double WeeklySalary { get; set; }

    public SalariedEmployee(string firstName, string lastName, string sin, double weeklySalary, Employee managedBy = null)
        : base(firstName, lastName, sin, managedBy)
    {
        WeeklySalary = weeklySalary;
    }

    public override double Earnings()
    {
        return WeeklySalary;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nPosition: Salaried\nWeekly Salary: ${WeeklySalary}\nTotal Earnings: ${Earnings()}";
    }
}

class HourlyEmployee : Employee
{
    public double HourlyRate { get; set; }
    public double HoursWorked { get; set; }

    public HourlyEmployee(string firstName, string lastName, string sin, double hourlyRate, double hoursWorked, Employee managedBy = null)
        : base(firstName, lastName, sin, managedBy)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override double Earnings()
    {
        if (HoursWorked <= 40)
        {
            return HourlyRate * HoursWorked;
        }
        else
        {
            return (HourlyRate * 40) + ((HourlyRate * 1.5) * (HoursWorked - 40));
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"\nPosition: Hourly\nHourly Rate: ${HourlyRate}\nHours Worked: {HoursWorked}\nTotal Earnings: ${Earnings()}";
    }
}

class CommissionEmployee : Employee
{
    public double CommissionRate { get; set; }
    public double GrossSales { get; set; }

    public CommissionEmployee(string firstName, string lastName, string sin, double commissionRate, double grossSales, Employee managedBy = null)
        : base(firstName, lastName, sin, managedBy)
    {
        CommissionRate = commissionRate;
        GrossSales = grossSales;
    }

    public override double Earnings()
    {
        return GrossSales * CommissionRate;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nPosition: Commission\nGross Sales: ${GrossSales}\nCommission Rate: {CommissionRate}\nTotal Earnings: ${Earnings()}";
    }
}

class PayrollTester
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new SalariedEmployee("Alice", "Johnson", "321654987", 3000),
            new SalariedEmployee("Bob", "Smith", "987654321", 1500, new SalariedEmployee("Alice", "Johnson", "321654987", 3000)),
            new HourlyEmployee("Carol", "Davis", "456789123", 20.00, 45, new SalariedEmployee("Alice", "Johnson", "321654987", 3000)),
            new CommissionEmployee("David", "Wilson", "654321987", 0.10, 10000, new SalariedEmployee("Bob", "Smith", "987654321", 1500))
        };

        double totalPayroll = 0;
        Employee highestPaid = null;
        Employee lowestPaid = null;

        foreach (var emp in employees)
        {
            Console.WriteLine(emp.ToString());
            totalPayroll += emp.Earnings();

            if (highestPaid == null || emp.Earnings() > highestPaid.Earnings())
            {
                highestPaid = emp;
            }

            if (lowestPaid == null || emp.Earnings() < lowestPaid.Earnings())
            {
                lowestPaid = emp;
            }
        }

        Console.WriteLine("\nPAYROLL SUMMARY");
        Console.WriteLine($"Top Earner: {highestPaid.LastName}, {highestPaid.FirstName}");
        Console.WriteLine($"Lowest Earner: {lowestPaid.LastName}, {lowestPaid.FirstName}");
        Console.WriteLine($"Total Salaried Employees: {employees.FindAll(e => e is SalariedEmployee).Count}");
        Console.WriteLine($"Total Hourly Employees: {employees.FindAll(e => e is HourlyEmployee).Count}");
        Console.WriteLine($"Total Commission Employees: {employees.FindAll(e => e is CommissionEmployee).Count}");
        Console.WriteLine($"Total Payroll: ${totalPayroll}");
    }
}

