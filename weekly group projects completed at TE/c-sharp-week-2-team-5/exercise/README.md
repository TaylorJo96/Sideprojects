# Week 2 review - TEams (Project Management Software)

You’ve been tasked with building an internal project management system for teams to track their projects. You don’t need to build a UI for this application. Your job is to build the foundational classes that drive the application’s features.

## Classes

The core of this application consists of three classes, which you'll create in the namespace `TEams`. Make sure to read through the requirements for each class before writing any code.

> Note: All dates in this application are strings using the format mm/dd/yyyy.

### Step One: Create the `Department` class

Create a new class called `Department.cs` with the following requirements.

#### Properties

| Name | Type | Getter | Setter |
|------|------|--------|--------|
| DepartmentId | int | x | x |
| Name | string | x | x |

#### Constructors

`Department` must have one constructor that accepts two parameters: `departmentId` and `name`.

### Step Two: Create the `Employee` class

Create a new class called `Employee.cs` with the following requirements.

#### Properties

| Name | Type | Getter | Setter |
|------|------|--------|--------|
| EmployeeId | long | x | x |
| FirstName | string | x | x |
| LastName | string | x | x |
| Email | string | x | x |
| Salary | double | x | x |
| Department | Department | x | x |
| HireDate | string | x | x |
| FullName | string | x |  |

> Note: `FullName` is a derived property that returns the employee's full name in the following format: "Last, First"

#### Constants

The default starting salary for all employees is $60,000 and is stored in a constant of type `double`.

#### Constructors

`Employee` needs two constructors.

The first one accepts all the arguments needed to create a new `Employee`: `employeeID`, `firstName`, `lastName`, `email`, `department`, and `hireDate`.

> Note: The first constructor doesn't include a `double` argument for the salary. Make sure to initialize each employees' salary to the static constant you created.

The second constructor is a no-argument constructor. This constructor allows you to create your `Employee` objects in multiple ways.

#### Methods

| Method Name | Description |
| ----------- | ----------- |
| `RaiseSalary(double percent)` | A method that raises the employee's salary by x percent |

### Step Three: Create the `Project` class

Create a new class called `Project.cs` with the following requirements.

#### Properties

| Name | Type | Getter | Setter |
|------|------|--------|--------|
| Name | string | x | x |
| Description | string | x | x |
| StartDate | string | x | x |
| DueDate | string | x | x |
| TeamMembers | List&lt;Employee&gt; | x | x |

> Note: Make sure to set `TeamMembers` to an empty list in your implementation.

#### Constructors

`Project` must have one constructor that accepts four parameters: `name`, `description`, `startDate` and `dueDate`. Use those parameter values to set the properties.


## Application

Now that you've created the core classes for this application, you'll write some code to test them. The logic for this application is in `Program.cs`.

### Step One: Create and print departments

Create an instance variable in the `Program` class called `departments` to hold a `List<Department>`.

Next, in `CreateDepartments()`, create these three departments and add them to the list you created:

| DepartmentId | Name |
|------|------|
| 1 | Marketing |
| 2 | Sales |
| 3 | Engineering |

Then, in the `PrintDepartments()` method, iterate over each element in `departments` and print them out. The final output in the console looks like this:

```
------------- DEPARTMENTS ------------------------------
Marketing
Sales
Engineering
```

### Step Two: Create and print employees

Create an instance variable in the `Program` class called `employees` to hold a `List<Employee>`.

Next, in `CreateEmployees()`, create three employees and add them to the list:

1. Dean Johnson: Create this employee using the no-argument constructor and set each property individually.

2. Angie Smith: Create this employee using the all-argument constructor.

3. Margaret Thompson: Create this employee using the all-argument constructor.

> Tip: use the `Department`s from the `departments` list to assign each employee's department. Retrieve the two departments you need by using index notation.

| EmployeeId | FirstName | LastName | Email | Salary | Department | HireDate |
|------|------|------|------|------|------|------|
| 1 | Dean | Johnson | djohnson@teams.com | 60000 | Engineering | 08/21/2020 |
| 2 | Angie | Smith | asmith@teams.com | 60000 | Engineering | 08/21/2020 |
| 3 | Margaret | Thompson | mthompson@teams.com | 60000 | Marketing | 08/21/2020 |

Before printing the list of `Employees`, give Angie a 10% raise in `Program.cs`.

In the `PrintEmployees()` method, iterate over each element in `employees` and print out their name, salary, and department. Use the derived property `FullName` for the employee's name. The final output in the console looks like this:

```
------------- EMPLOYEES ------------------------------
Johnson, Dean (60000) Engineering
Smith, Angie (66000) Engineering
Thompson, Margaret (60000) Marketing
```

### Step Three: Create and print projects

Create an instance variable in the `Program` class called `projects` to hold a collection of projects. The variable must be of type `Dictionary<string,Project>` where the key is the name of the project.

In `CreateTeamsProject()`, create the following project:

- name: TEams
- description: Project Management Software
- startDate: 10/10/2020
- dueDate: 11/10/2020

After you create the project, follow these steps:

1. Add all the employees from the engineering department to this project.
2. Add the project to the `projects` dictionary.

Then, in `CreateLandingPageProject()`, create the following project:

- name: Marketing Landing Page
- description: Lead Capture Landing Page for Marketing
- startDate: 10/10/2020
- dueDate: 10/17/2020

After you create this project, follow these steps:

1. Add all the employees from the marketing department to this project.
2. Add the project to the `projects` dictionary.

Finally, in `PrintProjectsReport()`, print out the project's name with the total number of employees on the project. The final output in the console looks like this:

```
------------- PROJECTS ------------------------------
TEams: 2
Marketing Landing Page: 1
```

### Final output

```
------------- DEPARTMENTS ------------------------------
Marketing
Sales
Engineering

------------- EMPLOYEES ------------------------------
Johnson, Dean (60000) Engineering
Smith, Angie (66000) Engineering
Thompson, Margaret (60000) Marketing

------------- PROJECTS ------------------------------
TEams: 2
Marketing Landing Page: 1
```

## Bonus challenges

If you finish early, here are three challenge projects you can work on.

### Employee salary formatting

Right now, an employee's salary is of type `double`. When it prints to the console, it looks like this: `60000`. It'd be better to display this number in currency format, so it looks like this: `$60,000.00`.

C# has a set of [standard numeric format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings) which allow you to specify a number of different formats such as currency, fixed-point, and percent.

```csharp
double someAmount = 60000;
Console.WriteLine(someAmount.ToString("C2"));
```

Given this information, you can refactor the `PrintEmployees()` method to display this output:

```
------------- EMPLOYEES ------------------------------
Johnson, Dean ($60,000.00) Engineering
Smith, Angie ($66,000.00) Engineering
Thompson, Margaret ($60,000.00) Marketing
```

### Dates

In the `Project` and `Employee` classes, you used the type `string` for the dates. In a real-world application, if you needed to perform calculations on dates, you wouldn't use a `string`.

In C#, there's a data type called [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-3.1) that you can use with dates.

> Note: You may notice the term `struct` on the `DateTime` MSDN page. A `struct` is similar to a `class` in that it combines data and methods, but is a "value type" rather than "reference type" which is a `class`.
>
> Typically, you use `struct`s to "design small data-centric types that provide little or no behavior." In other words, they're mostly about the data. You won't write or come across `struct`s very much in your programming career, but you should know that some of the base C# data types are `struct`s. Feel free to read the [MSDN documentation on Structure types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct).

#### Project

Right now, you likely created a new project by hard-coding a start date string. For now, this works. But if you wanted to run the application next week, you'd probably want to use the current date rather than the one you hard-coded a week ago. You can use the built-in `DateTime` to get today's date and set that as the start date instead.

There's also a way to set the end date to `x` amount of days after the start date. Update both `startDate` and `dueDate` to type `DateTime` using the following requirements:

- Project TEams
    - start date: today
    - due date 30 days after today
- Marketing Landing Page
    - start date: today + 31 days
    - due date: start date + 7 days

Make sure to read the [MSDN documentation on performing arithmetic operations with dates and times](https://docs.microsoft.com/en-us/dotnet/standard/datetime/performing-arithmetic-operations).

#### Employee

Update the `HireDate` to use the `DateTime` type. In the `CreateEmployees()` method, create a variable called `today` and use `DateTime` to get today's date. You can now use that variable when creating each of your employees.

### Find department by name

Earlier, you wrote code to retrieve a specific department from the `departments` list by its index, but what if you didn't know its index, or if it was an unordered collection? You could instead loop through the collection, test for a particular value, and return the item that matches. This is a common technique to use when a language or library doesn't provide a built-in method, or you're managing complex data or conditions.

Create another `private` method in the `Program` class. Have the method accept a `string` and return a `Department`. Give the method a descriptive name for what it does—for example, `GetDepartmentByName`.

In the method, iterate through `departments`, and test if each department's `Name` matches the `string` passed into the method. If it matches, return that `Department`. If there's no match, return `null`.

Now, go back to the `CreateEmployees()` method. Locate the code you wrote for getting the Engineering and Marketing departments. Instead of retrieving it from `departments` by index, use the new method you wrote, passing in the department name.

You'll know your new method was successful if you still have the same output from the `PrintEmployees()` and `PrintProjectsReport()` methods.
