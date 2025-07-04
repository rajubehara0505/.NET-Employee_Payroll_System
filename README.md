Employee Payroll System
Overview
This C# console application implements an object-oriented payroll system for different types of employees. The system models salaried, hourly, and commission-based employees, calculates their earnings, and summarizes payroll information.

The project demonstrates advanced OOP concepts, including abstraction, inheritance, polymorphism, and encapsulation, along with practical use of collections and overrides.

Features
Abstract Employee Base Class:
Common attributes like first name, last name, SIN (Social Insurance Number), manager reference, and shared employee count logic.

SalariedEmployee:

Fixed weekly salary.

Computes earnings directly from salary.

HourlyEmployee:

Earnings calculated based on hours worked, with overtime (1.5x rate) for hours above 40.

CommissionEmployee:

Earnings based on gross sales and a commission rate.

Employee Hierarchy:

Supports employees being managed by other employees.

Payroll Summary:

Calculates total payroll.

Identifies highest and lowest earners.

Counts each employee type.

How it works
The Employee base class defines shared properties and abstract Earnings() method to enforce earnings computation in subclasses.

Subclasses override Earnings() to calculate pay based on their specific model.

The PayrollTester class demonstrates creating various employee objects, printing detailed information, and generating a payroll summary.

Running the application
Clone or download this repository.

Open the project in an IDE that supports C# (e.g., Visual Studio, Rider, or VS Code with C# extension).

Build and run the project.

View employee earnings and payroll summary printed to the console.

Example output
yaml
Copy
Edit
Employee: Johnson, Alice
SIN: 321654987
Position: Salaried
Weekly Salary: $3000
Total Earnings: $3000

Employee: Smith, Bob
SIN: 987654321
Position: Salaried
Weekly Salary: $1500
Total Earnings: $1500

Employee: Davis, Carol
SIN: 456789123
Position: Hourly
Hourly Rate: $20
Hours Worked: 45
Total Earnings: $950

Employee: Wilson, David
SIN: 654321987
Position: Commission
Gross Sales: $10000
Commission Rate: 0.1
Total Earnings: $1000

PAYROLL SUMMARY
Top Earner: Johnson, Alice
Lowest Earner: Davis, Carol
Total Salaried Employees: 2
Total Hourly Employees: 1
Total Commission Employees: 1
Total Payroll: $6450
Technologies used
C#

.NET Console Application

