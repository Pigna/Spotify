using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Subscription(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;

        }
    }
}
