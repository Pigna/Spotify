using System;
using System.Collections.Generic;

namespace Spotify.Models
{
    public class User : Account
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Zipcode { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public Country Country { get; set; }
        public string Iban { get; set; }
        public int Phonenumber { get; set; }
        public List<User> FollowUsers { get; set; }
        public Subscription Subscription { get; set; }
        public List<Playlist> PlaylistList { get; set; }
        public User(string username, string name, string email, string zipcode, DateTime birthdate, Country country, string iban, int phonenumber, Subscription subscription ):base(username)
        {
            Name = name;
            Email = email;
            Zipcode = zipcode;
            Birthdate = birthdate;
            Country = country;
            Iban = iban;
            Phonenumber = phonenumber;
            Subscription = subscription;
        }
    }
}