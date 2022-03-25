using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetElevator.HR;

namespace PetElevator.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void HireEmployee_Test()
        {
            Manager manager = new Manager("Manager", "Managerson");
            Department department = new Department("Test Department");
            manager.Department = department;

            Employee employee = manager.HireEmployee("Test", "Testerson", "Tester of testing", 50000);

            Assert.AreEqual("Test", employee.FirstName);
            Assert.AreEqual("Testerson", employee.LastName);
            Assert.AreEqual("Tester of testing", employee.Title);
            Assert.AreEqual(50000, employee.Salary);
            Assert.AreEqual("ttesterson@petelevator.com", employee.Email);
            Assert.AreEqual(department, employee.Department);
            Assert.IsTrue(department.DepartmentEmployees.Contains(employee));
        }
    }
}
