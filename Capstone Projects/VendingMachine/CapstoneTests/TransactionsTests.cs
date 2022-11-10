using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class TransactionsTests
    {
        [TestMethod("FeedMoney() should add money to the balance if given a positive whole number. ")]
        public void FeedMoney_WholeNumberTest()
        {
            //Arrange
            Transactions transactions = new Transactions();
            decimal testBalance = 10.00M;
            string testInput = "10";

            //Act
            transactions.FeedMoney(testInput);

            //Assert
            Assert.AreEqual(testBalance, transactions.Balance);
        }

        [TestMethod("FeedMoney() should not add money to the balance if given a negative number. ")]
        public void FeedMoney_NegativeNumberTest()
        {
            //Arrange
            Transactions transactions = new Transactions();
            decimal testBalance = 0.00M;
            string testInput = "-10";

            //Act
            transactions.FeedMoney(testInput);

            //Assert
            Assert.AreEqual(testBalance, transactions.Balance);
        }

        [TestMethod("FeedMoney() should not add money to the balance if not given a whole number. ")]
        public void FeedMoney_NonWholeNumberTest()
        {
            //Arrange
            Transactions transactions = new Transactions();
            decimal testBalance = 0.00M;
            string testInput = "10.05";

            //Act
            transactions.FeedMoney(testInput);

            //Assert
            Assert.AreEqual(testBalance, transactions.Balance);
        }

        [TestMethod("PurchaseItem() should subtract the inputted price from the current balance. ")]
        public void PurchaseItem_HappyPath()
        {
            //Assert
            Transactions transactions = new Transactions();
            transactions.FeedMoney("5");
            decimal testInput = 3.50M;

            //Act
            transactions.PurchaseItem(testInput);

            //Assert
            Assert.AreEqual(1.50M, transactions.Balance);
        }

        [TestMethod("PurchaseItem() should be able to completely empty the current balance")]
        public void PurchaseItem_AllInTest()
        {
            //Assert
            Transactions transactions = new Transactions();
            transactions.FeedMoney("5");
            decimal testInput = 5.00M;

            //Act
            transactions.PurchaseItem(testInput);

            //Assert
            Assert.AreEqual(0.00M, transactions.Balance);
        }

        [TestMethod("PurchaseItem() should return false and should not subtract the user inputted price from the balance if the balance is zero.")]
        public void PurchaseItem_EmptyWalletTest()
        {
            //Assert
            Transactions transactions = new Transactions();
            decimal testInput = 5.00M;

            //Act
            bool result = transactions.PurchaseItem(testInput);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod("GiveChange() should return the balance to the user, in the lowest number of coins possible")]
        public void GiveChange_TwoDimes()
        {
            //Arrange
            Transactions transactions = new Transactions();
            transactions.FeedMoney("4");
            transactions.PurchaseItem(2.55M);
            string expectedString = "Dispensing: 5 Quarter(s), 2 Dime(s), 0 Nickel(s).\n\n";

            //Act
            string result = transactions.GiveChange();

            //Assert
            Assert.AreEqual(expectedString, result);
            Assert.AreEqual(transactions.Balance, 0.00M);
        }

        [TestMethod("GiveChange() should not give out quarters if the balance is less than $0.25")]
        public void GiveChange_NickelAndDimedTest()
        {
            //Arrange
            Transactions transactions = new Transactions();
            transactions.FeedMoney("1");
            transactions.PurchaseItem(0.85M);
            string expectedString = "Dispensing: 0 Quarter(s), 1 Dime(s), 1 Nickel(s).\n\n";

            //Act
            string result = transactions.GiveChange();

            //Assert
            Assert.AreEqual(expectedString, result);
            Assert.AreEqual(transactions.Balance, 0.00M);
        }

        [TestMethod("GiveChange() should not give change if the balance is already $0.00")]
        public void GiveChange_ZeroBalance()
        {
            //Arrange
            Transactions transactions = new Transactions();
            string expectedString = "Nice try.";

            //Act
            string result = transactions.GiveChange();

            //Assert
            Assert.AreEqual(expectedString, result);
            Assert.AreEqual(transactions.Balance, 0.00M);
        }
    }
}
