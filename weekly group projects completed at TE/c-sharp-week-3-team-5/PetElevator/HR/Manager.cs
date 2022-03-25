namespace PetElevator.HR
{
    public class Manager : Employee
    {
        public Manager(string firstName, string lastName) : base(firstName, lastName)
        {
        }
        public Manager(string firstName, string lastName, string title, double salary) : base(firstName, lastName, title, salary)
        {
        }

        public Employee HireEmployee(string firstName, string lastName, string title, double salary)
        {
            Employee newEmployee = new Employee(firstName, lastName, title, salary);
            newEmployee.Email = firstName.Substring(0, 1).ToLower() + lastName.ToLower() + "@petelevator.com";

            newEmployee.Department = Department; //manager's department
            Department.DepartmentEmployees.Add(newEmployee);

            return newEmployee;
        }
    }
}
