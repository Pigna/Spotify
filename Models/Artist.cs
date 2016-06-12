using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Artist
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public List<Song> SongList { get; set; }
        public Artist(string name, string image, string description, string publisher)
        {
            Name = name;
            Image = image;
            Description = description;
            Publisher = publisher;
        }
    }
}
