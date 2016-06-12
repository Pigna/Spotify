using System;
using System.Collections.Generic;
using System.Configuration;
using Spotify.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Spotify.Models.Database
{
    public abstract class DBContext
    {
        //fields
        protected MySqlConnection con = new MySqlConnection();

        /// <summary>
        /// doQuery
        /// </summary>
        /// <returns></returns>
        protected DBContext()
        {
            con.ConnectionString = "Data Source=mc.mysql.freaze.nl;Initial Catalog=ssd_1517;User ID=ssd_1517;Password=db62cd8afe;";
            //Data Source=mc.mysql.freaze.nl;Persist Security Info=True;User ID=ssd_1517;Password=db62cd8afe;
        }
    }
}