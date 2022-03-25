using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class ReservationSqlDaoTests : BaseDaoTests
    {
        [TestMethod]
        public void CreateReservation_Should_ReturnNewReservationId()
        {
            // Arrange
            ReservationSqlDao dao = new ReservationSqlDao(ConnectionString);

            // Act
            int returnedId = dao.CreateReservation(SiteId, "Test Name", DateTime.Now.AddDays(1), DateTime.Now.AddDays(3));

            // Assert
            Assert.AreEqual(ReservationId + 1, returnedId);
           
        }

        [TestMethod]
        public void ListReservationsWithin30Days__Returns_Reservations()
        {
            ReservationSqlDao dao = new ReservationSqlDao(ConnectionString);
            //ACT
            IList<Reservation> reservations = dao.ListReservationsWithin30Days(1);

            //ASSERT
            Assert.AreEqual(2, reservations.Count);
        
        }
       
       

    }
}
