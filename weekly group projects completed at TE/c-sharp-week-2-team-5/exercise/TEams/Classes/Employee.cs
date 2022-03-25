using System;
using System.Collections.Generic;

namespace TEams.Classes
{
	public class Employee
	{
		public Employee(long employeeID, string firstName, string lastName,string email, Department department, string hireDate)
		{
			this.EmployeeId = employeeID;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Department = department;
			this.Email = email;
			this.HireDate = hireDate;
			}
		public Employee()
        {
			
        }
        

		public long EmployeeId { get; set; }

		public string FirstName { get; set; }
		
		public string LastName { get; set; }
		
		public string Email { get; set; }

		private double salary = 60000; // connect with Salary
		public double Salary { get { return salary; } set { this.salary = value; } }
		
		public Department Department { get; set; }
		


		public string HireDate { get; set; } //mm/dd/yyyy
		
		public string FullName { get; } //Last,First I didnot do that yet

		public double RaiseSalary(double percent)
        {
			return Salary = Salary + Salary * percent;
        }





	}
}