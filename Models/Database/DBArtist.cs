using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Spotify.Models.Database
{
    public class DBArtist : DBContext
    {
        public List<Album> GetAlbumsFromArtist(Artist artist) //name of ur query
        {
            List<Album> ret = new List<Album>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT id, name, releasedate, image FROM Album, Song, Artist_Song WHERE Album.id = Song.albumid AND Song.id = Artist_Song.songid AND Artist_Song.artistid = @artistid"
            };
            cmd.Parameters.AddWithValue("@artistid", artist.ID);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = (dr.GetInt32(0));
                string name = (dr.GetString(1));
                DateTime releasedate = (dr.GetDateTime(2));
                string image = (dr.GetString(3));
                Album dbPlaylistItem = new Album(id, name, releasedate, image);
                ret.Add(dbPlaylistItem);
            }
            con.Close();
            return ret;
        }
    }
}