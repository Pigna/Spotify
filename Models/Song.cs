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
        private int duration;
        public string Duration {
            get { return $"{duration/60}:{duration%60:00}"; }
            set { duration = Convert.ToInt32(value); }
        }
        public DateTime? Release { get; set; }
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Genre> GenreList { get; set; }


        public Song(string name, int duration, DateTime? release)
        {
            Name = name;
            Duration = Convert.ToString(duration);
            Release = release;
        }
        public Song(int id, string name, int duration, DateTime? release)
        {
            ID = id;
            Name = name;
            Duration = Convert.ToString(duration);
            Release = release;
        }
    }
}
