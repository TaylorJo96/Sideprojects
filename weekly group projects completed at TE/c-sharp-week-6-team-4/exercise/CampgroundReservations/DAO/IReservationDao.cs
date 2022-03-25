using CampgroundReservations.Models;
using System;
using System.Collections.Generic;

namespace CampgroundReservations.DAO
{
    interface IReservationDao
    {
        int CreateReservation(int siteId, string name, DateTime fromDate, DateTime toDate);

    }
}
