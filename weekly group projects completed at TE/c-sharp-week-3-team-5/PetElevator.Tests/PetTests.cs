using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetElevator.CRM;

namespace PetElevator.CRM.Tests
{
    [TestClass]
    public class PetTests
    {
        [TestMethod]
        public void ListVaccinations_happyPath()
        {
            //arrange
            Pet listOfVaccinations = new Pet("Doug", "Chinchilla");
            listOfVaccinations.Vaccinations.Add("Rabies");
            listOfVaccinations.Vaccinations.Add("Distemper");
            listOfVaccinations.vaccinations.Add("Parvo");


            //act
            string results = listOfVaccinations.ListVaccinations();

            //assert
            Assert.AreEqual("Rabies, Distemper, Parvo", results);

        }
    }
}
