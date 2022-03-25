using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PetElevator.HR;

namespace PetElevator.Tests
{
    [TestClass]
    public class DepartmentTests
    {
        [TestMethod]
        public void TransferEmployeeIn_Test()
        {
            Department oldDept = new Department("Old Department");
            Department newDept = new Department("New Department");

            Employee employee = new Employee("Test", "Testerson");
            employee.Department = oldDept;

            newDept.TransferEmployeeIn(employee);

            List<Employee> oldDeptEmps = oldDept.DepartmentEmployees;
            List<Employee> newDeptEmps = newDept.DepartmentEmployees;

            Assert.IsTrue(oldDeptEmps.Count == 0);
            Assert.IsTrue(newDeptEmps.Count == 1);
            Assert.IsTrue(newDeptEmps.Contains(employee));
        }

        [TestMethod]
        public void SetDepartmentHead_TestManger()
        {
            Department department = new Department("Test Department");
            Manager manager = new Manager("Manager", "Managerson", "Manager of Testing", 100000);

            department.SetDepartmentHead(manager);

            Assert.AreEqual(manager, department.DepartmentHead);
        }

        [TestMethod]
        public void SetDepartmentHead_TestDirector()
        {
            Department department = new Department("Test Department");
            Manager manager = new Manager("Manager", "Managerson", "Director of Testing", 100000);

            department.SetDepartmentHead(manager);

            Assert.AreEqual(manager, department.DepartmentHead);
        }

        [TestMethod]
        public void SetDepartmentHead_TestBadTitle()
        {
            Department department = new Department("Test Department");
            Manager manager = new Manager("Manager", "Managerson", "Head of Testing", 100000);

            department.SetDepartmentHead(manager);

            Assert.IsNull(department.DepartmentHead);
            Assert.AreNotEqual(manager, department.DepartmentHead);
        }
    }
}
