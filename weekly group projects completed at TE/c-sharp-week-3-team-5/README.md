# Week 3 review exercise

Congratulations—you've been hired by a pet setting and grooming company called Pet Elevator. They're building their own software to use in-house.

Your job is to create classes for the Customer Relationship Management (CRM) system. A CRM system helps to manage customer information and other related data.

Since Pet Elevator is a pet sitting and grooming company, you'll need to create a class to represent the human customers and a class to represent their pets.

## Getting started

### Step One: Open the project

Open the `PetElevator.sln` solution in Visual Studio.

### Step Two: Review starting code

The software team has started building a system for the Human Resources (HR) department to manage employee, manager, and department information. Take a moment to explore the starting code in the `HR` folder and `Shared` folder:

* `Shared`
    * `Person.cs`: base class representing a person
    * `IBillable.cs`: interface defining methods for objects that are "billable"—meaning someone that can be billed for services
* `HR`
    * `Department.cs`: class to represent a department in the business
    * `Employee.cs`: class to represent an employee of the company, inherits `Person` class
    * `Manager.cs`: class to represent a manager of the company, inherits `Employee` class

### Step Three: Review existing tests

In Visual Studio, click the **Test > Run All Tests** menu option. Then, click the **Test Explorer** tab to see the results of your tests and which ones passed or failed. All of the tests pass when you first open the project. You'll write additional tests to validate the code you'll add in this exercise.

## Notes for all classes

* An X in the set column indicates the property must have a `set`.
* `private` in the set column indicates the property must have a `private set`.
* If there's nothing in the set column, that means the property is a derived property.

## CRM system requirements

* *All classes you create must be in the `PetElevator.CRM` namespace.*
  * By convention, these classes go in the `PetElevator\CRM` folder.
* The project must not have any build errors.
* All unit tests pass as expected.
* Appropriate variable names and data types are used.
* Code is presented in a clean, organized format.
* Code is appropriately encapsulated.
* The code meets the specifications defined below.

There are no provided unit tests. You'll also write tests for the methods you write.

### Step Four: Create the `Pet` class

#### Properties

| Property     | Data Type    | Get | Set | Description                        |
| ------------ | ------------ | --- | --- | ---------------------------------- |
| PetName      | string       | X   | X   | Name of pet.                       |
| Species      | string       | X   | X   | Species of pet, like dog or cat.   |
| Vaccinations | List<string> | X   | X   | Vaccinations the pet has received. |

> Note: Remember to set `Vaccinations` to a new initialized `List`. You can do this in the property declaration or constructor.

#### Constructors

Create one constructor for `Pet` that accepts two `string`s to set `PetName` and `Species`.

#### Methods

| Method Name      | Return Type | Parameters |
| ---------------- | ----------- | ---------- |
| ListVaccinations | string      | none       |

The `ListVaccinations` method returns the elements of `Vaccinations` as a comma-delimited string. For example, if the `List` contains `["Rabies", "Distemper", "Parvo"]`, the output must be `"Rabies, Distemper, Parvo"`.

Keep in mind the spaces between and not to have a trailing comma.

#### Unit tests

Create a `PetTests` class in the `PetElevator.Tests` project. Create a test for `ListVaccinations`.

### Step Five: Create the `Customer` class

Declare a `Customer` class that inherits the `Person` class from `PetElevator.Shared`.

#### Properties

| Property    | Data Type | Get | Set | Description                      |
| ----------- | --------- | --- | --- | -------------------------------- |
| PhoneNumber | string    | X   | X   | Customer's phone number.         |
| Pets        | List<Pet> | X   | X   | Collection of customer's pets.   |

> Note: Remember to set `Pets` to a new initialized `List`. You can do this in the property declaration or constructors.

#### Constructors

`Customer` needs two constructors:

* One that accepts three `string` parameters for first name, last name, and phone number.
  * This constructor must set the phone number property, and call the base class constructor for first and last name.
* One that accepts two `string` parameters for first name and last name.
  * This constructor must call the first constructor with an empty string for phone number.

### Step Six: Implement the `IBillable` interface

You received an additional requirement to implement the `IBillable` interface on the `Customer` class and the `Employee` class because employees can also be customers.

The `IBillable` interface defines a method with the signature `double GetBalanceDue(Dictionary<string, double>)`. You need to implement this method in the `Customer` and `Employee` classes.

#### Methods

| Method Name   | Return Type | Parameters                 |
| ------------- | ----------- | -------------------------- |
| GetBalanceDue | double      | Dictionary<string, double> |

The `GetBalanceDue` method returns the total amount the customer owes.

It accepts one parameter, a `Dictionary` of services rendered:
* The key is a `string` representing the type of service—for example, "Grooming", "Walking", or "Sitting."
* The value is a `double` representing the price for each service.

Employees receive a 50% discount on walking services, but the discount isn't applied in the `Dictionary` provided. In the `Employee` implementation of the method, you'll have to calculate the discount.

#### Unit tests

Create a `CustomerTests` class in the `PetElevator.Tests` project. Create a test for `GetBalanceDue`.

You'll also need to add a test for `GetBalanceDue` in the `EmployeeTests` class. Keep in mind the discount.
