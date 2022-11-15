using afa_application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace afa_application.DAO
{
    public class PlayerSqlDao : IPlayerDao
    {
        private readonly string connectionString;
        public PlayerSqlDao(string dbConnectionString)
        {
      connectionString = dbConnectionString;
        }

        //Player GetPlayer(int playerId);
        //public List<Player> GetPlayers();


        public Player GetPlayer(int playerId)
        {
            Player player = null;
            //try {
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    {
            //        conn.Open();
            //        SqlCommand cmd = new SqlCommand("SELECT * FROM players WHERE player_id = @playerId");
            //        cmd.Parameters.AddWithValue("@playerId", playerId);
            //        SqlDataReader reader = cmd.ExecuteReader();
             
            //        if (reader.Read())
            //        {
            //            player = GetPlayerFromReader(reader);
            //        } 
            //    }

            //}
            //catch (SqlException) {
            //    throw;

            //}

            return player;
 
        }

        public List<Player> GetPlayers() {
            List<Player> players = new List<Player>() ;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT  player_id, first_name, last_name FROM players", conn);
                   
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Player player = GetPlayerFromReader(reader);

                          //  Nickname = Convert.ToString(reader["nickname"])

                        
                        players.Add(player);
                    }
                    return players;
                }
              
            }
            
            catch (SqlException)
            {
                throw;
            }
            
           

        }
        private Player GetPlayerFromReader(SqlDataReader reader)
        {
            Player player = new Player()
            {
                PlayerId = Convert.ToInt32(reader["player_id"]),
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
            //    Nickname = Convert.ToString(reader["nickname"])
            };
        return player;
        
        }


    }
}
