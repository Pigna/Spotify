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
        private DBUser dbUser = new DBUser();
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
                string image = (dr.GetString(2));
                string description = (dr.GetString(3));
                string publisher = (dr.GetString(4));
                Artist dbPlaylistItem = new Artist(id, name, image, description, publisher);
                ret.Add(dbPlaylistItem);
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
                Playlist dbPlaylistItem = new Playlist(id, name, dbUser.GetUserById(ownerid));
                ret.Add(dbPlaylistItem);
            }
            con.Close();
            return ret;
        }
    }
}
