using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Spotify.Models.Database
{
    class DBUser : DBContext
    {
        public User GetUserById(int id)
        {
            User ret;
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT * FROM User WHERE id = @id"
            };
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string name = (dr.GetString(1));
                string email = (dr.GetString(2));
                string postalcode = (dr.GetString(3));
                string gender = (dr.GetString(4));
                string birthday = (dr.GetString(5));
                int country = (dr.GetInt32(6));
                string iban = (dr.GetString(7));
                int mobile = (dr.GetInt32(8));
                int subscription = (dr.GetInt32(9));
                ret = new User(id, name, email, postalcode, DateTime.Now, (Country)country, iban, mobile, new Subscription("", 0.0, ""));
                con.Close();
                return ret;
            }
            con.Close();
            return null;
        }
    }
}
