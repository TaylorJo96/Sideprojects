using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class ReservationSqlDao : IReservationDao
    {
        private readonly string connectionString;

        public ReservationSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public int CreateReservation(int siteId, string name, DateTime fromDate, DateTime toDate)
        {
            int newreservationID;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO reservation(site_Id, name, from_Date, to_Date)
                                                 OUTPUT INSERTED.reservation_ID
                                                 VALUES (@site_Id, @name, @from_Date, @to_Date)", conn);


                cmd.Parameters.AddWithValue("@site_Id", siteId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@from_date", fromDate);
                cmd.Parameters.AddWithValue("@to_date", toDate);
                newreservationID = Convert.ToInt32(cmd.ExecuteScalar());
               

            }
            return newreservationID;
              
        }

        public IList<Reservation>  ListReservationsWithin30Days(int parkId)
        {
            List<Reservation> reservationList = new List<Reservation>();

            using (SqlConnection connie = new SqlConnection(connectionString))
            {
                connie.Open();
                SqlCommand cmd = new SqlCommand("SELECT reservation_id, reservation.site_id, reservation.name, from_date, to_date, create_date"+ 
                                                             " FROM reservation JOIN site ON reservation.site_id = site.site_id"+
                                                             " JOIN campground ON campground.campground_id = site.campground_id" +
                                                              " JOIN park ON park.park_id = campground.park_id" +
                                                              " WHERE DATEDIFF(day, GETDATE(), from_date) < 30 AND  DATEDIFF(day, GETDATE(), from_date) >= 0 AND park.park_id = @park_id; ", connie);
                cmd.Parameters.AddWithValue("@park_id", parkId);
                SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())  
                {
                   Reservation reservation = GetReservationFromReader(reader);
                    reservationList.Add(reservation);
                }
            }

            return reservationList;
        }



            private Reservation GetReservationFromReader(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = Convert.ToInt32(reader["reservation_id"]);
            reservation.SiteId = Convert.ToInt32(reader["site_id"]);
            reservation.Name = Convert.ToString(reader["name"]);
            reservation.FromDate = Convert.ToDateTime(reader["from_date"]);
            reservation.ToDate = Convert.ToDateTime(reader["to_date"]);
            reservation.CreateDate = Convert.ToDateTime(reader["create_date"]);

            return reservation;
        }
    }
}
