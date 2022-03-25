using System.Collections.Generic;

namespace PetElevator.HR
{
    public class Department
    {
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; private set; }
        public Manager DepartmentHead { get; private set; }
        public List<Employee> DepartmentEmployees { get; private set; } = new List<Employee>();
        public int EmployeeCount
        {
            get
            {
                return DepartmentEmployees.Count;
            }
        }

        public Department(string deptName)
        {
            DepartmentName = deptName;
        }

        public void SetDepartmentHead(Manager manager)
        {
            if (manager.Title.StartsWith("Manager") || manager.Title.StartsWith("Director"))
            {
                DepartmentHead = manager;
            }
        }
        public void TransferEmployeeIn(Employee employee)
        {
            employee.Department.DepartmentEmployees.Remove(employee); //remove employee from old department's list
            employee.Department = this; //assign employee's department to this one
            DepartmentEmployees.Add(employee); //add employee to this department's list
        }
    }
}
