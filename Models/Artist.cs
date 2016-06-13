using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public List<Song> SongList { get; set; }
        public Artist(int id, string name, string image, string description, string publisher)
        {
            ID = id;
            Name = name;
            Image = image;
            Description = description;
            Publisher = publisher;
        }
    }
}
