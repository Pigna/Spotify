using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotify.Models.Database;

namespace Spotify.Models
{
    public class Playlist
    {
        DBPlaylist dbPlaylist = new DBPlaylist();
        public int ID { get; set; }
        public string Name { get; set; }
        public User Creator { get; set; }
        public List<Song> SongList { get; set; }

        public Playlist(string name, User creator)
        {
            Name = name;
            Creator = creator;
            SongList = GetSongList();
        }
        public Playlist(int id, string name, User creator)
        {
            ID = id;
            Name = name;
            Creator = creator;
            SongList = GetSongList();
        }

        public List<Song> GetSongList()
        {
            List<Song> songlist = dbPlaylist.GetSongsFromPlaylist(this);
            return songlist;
        }
    }
}
