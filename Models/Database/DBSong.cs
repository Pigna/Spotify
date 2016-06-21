using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Spotify.Models.Database
{
    public class DBSong : DBContext
    {
        DBArtist dbArtist = new DBArtist();
        public Song GetSongById(int id)
        {
            Song ret;
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT id, name, duration, releasedate FROM Song WHERE id = @id"
            };
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(1);
                int duration = dr.GetInt32(2);
                DateTime releasedate = dr.GetDateTime(3);

                ret = new Song(id, name, duration, releasedate);
                con.Close();
                return ret;
            }
            con.Close();
            return null;
        }
        public List<Song> GetAllSongs(int start)
        {
            List<Song> ret = new List<Song>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT id, name, duration, releasedate FROM Song LIMIT @start, @end"
            };
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", start + 25);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                string name = dr.GetString(1);
                int duration = dr.GetInt32(2);
                DateTime releasedate = dr.GetDateTime(3);
                Song newSong = new Song(id, name, duration, releasedate);
                newSong.Artists = dbArtist.GetArtistsFromSong(newSong);
                ret.Add(newSong);
            }
            con.Close();
            return ret;
        }

    }
}