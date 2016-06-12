using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Playlist
    {
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
            List<Song> songlist = new List<Song>
            {
                new Song("song1", "1234", DateTime.Now, null),
                new Song("song2", "1234", DateTime.Now, null),
                new Song("song3", "1234", DateTime.Now, null),
                new Song("song4", "1234", DateTime.Now, null)
            };
            return songlist;
        }
    }
}
