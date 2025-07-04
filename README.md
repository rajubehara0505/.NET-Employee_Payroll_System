# Employee Payroll System

## Overview

This C# console application implements an object-oriented payroll system for different types of employees. The system models salaried, hourly, and commission-based employees, calculates their earnings, and summarizes payroll information.

The project demonstrates advanced OOP concepts, including abstraction, inheritance, polymorphism, and encapsulation, along with practical use of collections and overrides.

---

## Features

- **Abstract Employee Base Class:**  
  Common attributes like first name, last name, SIN (Social Insurance Number), manager reference, and shared employee count logic.

- **SalariedEmployee:**  
  - Fixed weekly salary.
  - Computes earnings directly from salary.

- **HourlyEmployee:**  
  - Earnings calculated based on hours worked, with overtime (1.5x rate) for hours above 40.

- **CommissionEmployee:**  
  - Earnings based on gross sales and a commission rate.

- **Employee Hierarchy:**  
  - Supports employees being managed by other employees.

- **Payroll Summary:**  
  - Calculates total payroll.
  - Identifies highest and lowest earners.
  - Counts each employee type.

---

## How it works

1. The `Employee` base class defines shared properties and an abstract `Earnings()` method to enforce earnings computation in subclasses.
2. Subclasses override `Earnings()` to calculate pay based on their specific model.
3. The `PayrollTester` class demonstrates creating various employee objects, printing detailed information, and generating a payroll summary.

---

## Running the application

1. Clone or download this repository.
2. Open the project in an IDE that supports C# (e.g., Visual Studio, Rider, or VS Code with C# extension).
3. Build and run the project.
4. View employee earnings and payroll summary printed to the console.

---

## Example output

