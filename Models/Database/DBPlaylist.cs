using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Spotify.Models.Database
{
    public class DBPlaylist : DBContext
    {
        private DBAccount dbAccount = new DBAccount();
        private DBUser dbUser = new DBUser();
        public List<Playlist> GetPlaylistsFromUser(User user) //name of ur query
        {
            List<Playlist> ret = new List<Playlist>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT id, name FROM Playlist WHERE userid = @userid"
            };
            cmd.Parameters.AddWithValue("@userid", user.ID);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = (dr.GetInt32(0));
                string naam = (dr.GetString(1));
                Playlist dbPlaylistItem = new Playlist(id, naam, user);
                ret.Add(dbPlaylistItem);
            }
            con.Close();
            return ret;
        }
        public Playlist GetPlaylistByID(int id) //name of ur query
        {
            Playlist ret;
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT id, name, userid FROM Playlist WHERE id = @id"
            };
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int userid = (dr.GetInt32(0));
                string naam = (dr.GetString(1));
                ret = new Playlist(id, naam, dbUser.GetUserById(userid));
                con.Close();
                return ret;
            }
            con.Close();
            return null;
        }
        public List<Playlist> GetPlaylistByName(Playlist playlist) //name of ur query
        {
            return null;
        }
        public bool AddPlaylist(string name, User user) //name of ur query
        {
            MySqlCommand query = new MySqlCommand
            {
                CommandText = "INSERT INTO Playlist VALUES (@name, @userid);"
            };
            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("@userid", user.ID);
            return false;
        }
        public List<Song> GetSongsFromPlaylist(Playlist playlist) //name of ur query
        {
            List<Song> ret = new List<Song>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT * FROM Song s, Playlist_Song ps WHERE s.id = ps.Songid AND ps.Playlistid = @playlistid"
            };
            cmd.Parameters.AddWithValue("@playlistid", playlist.ID);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = (dr.GetInt32(0));
                string name = (dr.GetString(1));
                int duration = (dr.GetInt32(2));
                DateTime? release = (dr.GetDateTime(3));
                Song newSong = new Song(id, name, duration, release);
                ret.Add(newSong);
            }
            con.Close();
            return ret;
        }

        public bool NewPlaylist(NewPlaylistModel playlist, User user)
        {
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "INSERT INTO Playlist (Name, Userid) VALUES (@name, @userid)"
            };
            cmd.Parameters.AddWithValue("@name", playlist.Name);
            cmd.Parameters.AddWithValue("@userid", user.ID);

            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
    }
}
