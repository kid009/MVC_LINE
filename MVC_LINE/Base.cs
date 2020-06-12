using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVC_LINE
{
    public class Base
    {
        //connect Database
        public SqlConnection ManageConnection()
        {
            SqlConnection connection = new SqlConnection();

            string connectionString = ConfigurationManager.ConnectionStrings["connectLocalhost"].ConnectionString;

            connection.ConnectionString = connectionString; //set

            if (connection != null && connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }
    }
}