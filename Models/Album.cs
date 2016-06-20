using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? Release { get; set; }
        public string Image { get; set; }
        public List<Song> SongList { get; set; }
        public Album(int id, string name, DateTime? release, string image)
        {
            ID = id;
            Name = name;
            Release = release;
            Image = image;
        }
    }
}
