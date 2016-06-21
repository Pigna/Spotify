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
                DateTime birthday = (dr.GetDateTime(5));
                int country = (dr.GetInt32(6));
                int mobile = (dr.GetInt32(8));
                int subscription = (dr.GetInt32(9));
                ret = new User(id, name, email, postalcode, DateTime.Now, (Country)country, mobile, new Subscription("", 0.0, ""));
                con.Close();
                return ret;
            }
            con.Close();
            return null;
        }
        public List<Artist> GetFollowingArtists(User user) //name of ur query
        {
            List<Artist> ret = new List<Artist>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT id, artistname, image, description, publisher FROM Artist, FollowArtist WHERE Artist.id = FollowArtist.artistid AND FollowArtist.userid = @userid"
            };
            cmd.Parameters.AddWithValue("@userid", user.ID);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = (dr.GetInt32(0));
                string name = (dr.GetString(1));
                string image = "";
                if (!(dr.GetValue(2) is DBNull))
                {
                    image = (dr.GetString(2));
                }
                string description = "";
                if (!(dr.GetValue(3) is DBNull))
                {
                    image = (dr.GetString(3));
                }
                string publisher = "";
                if (!(dr.GetValue(4) is DBNull))
                {
                    image = (dr.GetString(4));
                }
                Artist dbPlaylistItem = new Artist(id, name, image, description, publisher);
                ret.Add(dbPlaylistItem);
            }
            con.Close();
            return ret;
        }
        public List<User> GetFollowingUsers(User user) //name of ur query
        {
            List<User> ret = new List<User>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT id, name FROM User, FollowUser WHERE User.id = FollowUser.Userid AND FollowUser.Userid2 = @userid"
            };
            cmd.Parameters.AddWithValue("@userid", user.ID);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = (dr.GetInt32(0));
                string name = (dr.GetString(1));
                User dbUserItem = new User(id, name);
                ret.Add(dbUserItem);
            }
            con.Close();
            return ret;
        }
        public List<Playlist> GetFollowingPlaylists(User user) //name of ur query
        {
            List<Playlist> ret = new List<Playlist>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT Playlist.id, Playlist.name, Playlist.Userid FROM Playlist, FollowPlaylist WHERE Playlist.id = FollowPlaylist.playlistid AND FollowPlaylist.userid = @userid"
            };
            cmd.Parameters.AddWithValue("@userid", user.ID);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = (dr.GetInt32(0));
                string name = (dr.GetString(1));
                int ownerid = (dr.GetInt32(2));
                Playlist dbPlaylistItem = new Playlist(id, name, GetUserById(ownerid));
                ret.Add(dbPlaylistItem);
            }
            con.Close();
            return ret;
        }
    }
}
