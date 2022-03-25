using CampgroundReservations.Models;
using System.Collections.Generic;

namespace CampgroundReservations.DAO
{
    interface ICampgroundDao
    {
        IList<Campground> GetCampgroundsByParkId(int parkId);
    }
}
