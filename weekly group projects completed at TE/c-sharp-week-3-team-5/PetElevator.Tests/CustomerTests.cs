using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetElevator.CRM;

namespace PetElevator.Shared.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        [TestMethod]
        public void GetBalance_happyPath()
        {

            //arrange
            Customer steve = new Customer("Steve", "Miller");
            Dictionary<string, double> servicesAndPrice = new Dictionary<string, double>();
            servicesAndPrice.Add("Grooming", 20.00);
            servicesAndPrice.Add("Walking", 10.00);
            servicesAndPrice.Add("Sitting", 40.00);

            //act

            double amountOwed = steve.GetBalanceDue(servicesAndPrice);


            //assert
            Assert.AreEqual(70.00, amountOwed);


        }





    }
}
