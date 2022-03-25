using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class CampgroundSqlDaoTests : BaseDaoTests
    {
        [TestMethod]
        public void GetCampgroundsTest_Should_ReturnAllCampgrounds()
        {
            // Arrange
            CampgroundSqlDao dao = new CampgroundSqlDao(ConnectionString);

            // Act
            IList<Campground> campgrounds = dao.GetCampgroundsByParkId(ParkId);

            // Assert
            Assert.AreEqual(2, campgrounds.Count);
        }
    }
}
