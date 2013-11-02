using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PhotoSharing.Webservice.Data
{
    /// <summary>
    /// Clase que expone el acceso a la base de datos
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Connecion String
        /// </summary>
        private static readonly string PhotoConnectionString;
        /// <summary>
        /// init del connection string
        /// </summary>
        static Database()
        {
            Database.PhotoConnectionString = ConfigurationManager.ConnectionStrings["photoConnectionString"].ConnectionString;
        }
        /// <summary>
        /// obtiene una conexión abierta a la base de datos de MySQL
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetDatabase()
        {
            MySqlConnection con = new MySqlConnection(Database.PhotoConnectionString);

            try
            {                
                con.Open();
            }
            catch (MySqlException ex)
            {

                throw ex;
            }

            return con;
        }
    }
}