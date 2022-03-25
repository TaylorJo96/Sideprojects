using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetElevator.Shared;

namespace PetElevator.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void FullNameReturnsFirstAndLastName()
        {
            Person person = new Person("Test", "Testerson");

            string fullName = person.FullName;

            Assert.AreEqual("Test Testerson", fullName);
        }
    }
}
