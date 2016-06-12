using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Song
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public DateTime Release { get; set; }
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Genre> GenreList { get; set; }


        public Song(string name, string duration, DateTime release, List<Genre> genreList)
        {
            Name = name;
            Duration = duration;
            Release = release;
            GenreList = genreList;
        }
    }
}
