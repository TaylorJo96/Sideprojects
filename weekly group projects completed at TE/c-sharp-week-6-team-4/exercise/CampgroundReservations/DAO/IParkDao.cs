using CampgroundReservations.Models;
using System.Collections.Generic;

namespace CampgroundReservations.DAO
{
    interface IParkDao
    {
        IList<Park> GetAllParks();
    }
}
