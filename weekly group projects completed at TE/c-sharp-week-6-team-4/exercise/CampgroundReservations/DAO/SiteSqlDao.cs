using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class SiteSqlDao : ISiteDao
    {
        private readonly string connectionString;

        public SiteSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Site> GetSitesThatAllowRVs(int parkId)
        {


            IList<Site> mySite = new List<Site>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM site JOIN campground ON site.campground_id = campground.campground_id " +
                                                "JOIN park on park.park_id = campground.park_id WHERE @park_id = park.park_id AND max_rv_length != 0", conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Site site = GetSiteFromReader(reader);
                    mySite.Add(site);
                }

            }

            return mySite;
        }


        public IList<Site> CurrentlyAvailableSitesByPark(int parkId)
        {
            IList<Site> siteList = new List<Site>();

            using (SqlConnection connie = new SqlConnection(connectionString))
            {
                connie.Open();
                SqlCommand cmd = new SqlCommand("SELECT  * FROM site   JOIN reservation on site.site_id = reservation.site_id " +
                                                 " JOIN campground ON campground.campground_id = site.campground_id " +
                                                 " JOIN park ON park.park_id = campground.park_id  WHERE GETDATE() NOT BETWEEN from_date AND to_date AND park.park_id = @park_id", connie);
                cmd.Parameters.AddWithValue("@park_id", parkId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Site site = GetSiteFromReader(reader);
                    siteList.Add(site);
                }
            }

            return siteList;
        }

        private Site GetSiteFromReader(SqlDataReader reader)
        {
            Site site = new Site();
            site.SiteId = Convert.ToInt32(reader["site_id"]);
            site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            site.SiteNumber = Convert.ToInt32(reader["site_number"]);
            site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            site.Accessible = Convert.ToBoolean(reader["accessible"]);
            site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
            site.Utilities = Convert.ToBoolean(reader["utilities"]);

            return site;
        }
    }
}
