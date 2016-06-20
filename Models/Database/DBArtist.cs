using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Spotify.Models.Database
{
    public class DBArtist : DBContext
    {
        public Artist GetArtistbyId(int artistId) //name of ur query
        {
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText = "SELECT id, artistname, image, description, publisher FROM Artist WHERE Artist.id = @artistid"
            };
            cmd.Parameters.AddWithValue("@artistid", artistId);
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
                Artist ret = new Artist(id, name, image, description, publisher);
                con.Close();
                return ret;
            }
            con.Close();
            return null;
        }
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

        public List<Song> GetSongsFromArtist(Artist artist) //name of ur query
        {
            List<Song> ret = new List<Song>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText =
                    "SELECT Song.id, Song.name, duration, Song.releasedate, Album.id, Album.name, Album.releasedate, Album.image FROM Album, Song, Artist_Song WHERE Album.id = Song.albumid AND Song.id = Artist_Song.songid AND Artist_Song.artistid = @artistid ORDER BY Album.name"
            };
            cmd.Parameters.AddWithValue("@artistid", artist.ID);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int songid = dr.GetInt32(0);
                string songname = dr.GetString(1);
                int songduration = dr.GetInt32(2);
                DateTime songreleasedate = dr.GetDateTime(3);
                int albumid = dr.GetInt32(4);
                string albumname = dr.GetString(5);
                DateTime releasedate = dr.GetDateTime(6);
                string image = "";
                if (!(dr.GetValue(7) is DBNull))
                {
                    image = dr.GetString(7);
                }
                Album album = new Album(albumid, albumname, releasedate, image);
                Song song = new Song(songid, songname, songduration, songreleasedate);
                song.Album = album;
                song.Artists = new List<Artist>
                {
                    artist
                };
                ret.Add(song);
            }
            con.Close();
            return ret;
        }
        public List<Artist> GetArtistsFromSong(Song song) //name of ur query
        {
            List<Artist> ret = new List<Artist>();
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = con,
                CommandText =
                    "SELECT id, artistname, image, description, Publisher FROM Artist, Artist_Song WHERE Artist_Song.artistid = Artist.id AND Artist_Song.songid = @artistid"
            };
            cmd.Parameters.AddWithValue("@artistid", song.ID);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                string name = dr.GetString(1);
                string image = "";
                if (!(dr.GetValue(2) is DBNull))
                {
                    image = dr.GetString(2);
                }
                string description = "";
                if (!(dr.GetValue(3) is DBNull))
                {
                    description = dr.GetString(3);
                }
                string publisher = "";
                if (!(dr.GetValue(4) is DBNull))
                {
                    publisher = dr.GetString(4);
                }
                Artist artist = new Artist(id, name, image,description,publisher);
                ret.Add(artist);
            }
            con.Close();
            return ret;
        }
    }
}