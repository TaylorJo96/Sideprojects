using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class BaseDaoTests
    {
        private const string DatabaseName = "CampgroundTesing";

        private const string AdminConnectionString = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        protected const string ConnectionString = @"Server=.\SQLEXPRESS;Database=" + DatabaseName + ";Trusted_Connection=True;";

        protected static int ParkId { get; set; }
        protected static int ReservationId { get; set; }
        protected static int SiteId { get; set; }

        /// <summary>
        /// The transaction for each test.
        /// </summary>
        private TransactionScope transaction;

        [AssemblyInitialize]
        public static void BeforeAllTests(TestContext context)
        {
            string sql = File.ReadAllText("create-test-db.sql").Replace("test_db_name", DatabaseName);

            using (SqlConnection conn = new SqlConnection(AdminConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }

            sql = File.ReadAllText("test-data.sql");
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ParkId = Convert.ToInt32(reader["park_id"]);
                    SiteId = Convert.ToInt32(reader["site_id"]);
                    ReservationId = Convert.ToInt32(reader["reservation_id"]);
                }
            }
        }

        [AssemblyCleanup]
        public static void AfterAllTests()
        {
            // drop the temporary database
            string sql = File.ReadAllText("drop-test-db.sql").Replace("test_db_name", DatabaseName);

            using (SqlConnection conn = new SqlConnection(AdminConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }


        [TestInitialize]
        public void Setup()
        {
            // Begin the transaction
            transaction = new TransactionScope();

        }

        [TestCleanup]
        public void Cleanup()
        {
            // Roll back the transaction
            transaction.Dispose();
        }

    }
}
