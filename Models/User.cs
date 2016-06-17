using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class User : Account
    {
        public int ID { get; private set; }
        [Display(Name = "Naam")]
        [Required(ErrorMessage = "Vul een naam in.")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vul een email in.")]
        public string Email { get; set; }
        [Display(Name = "Postcode")]
        [Required(ErrorMessage = "Vul een postcode in.")]
        public string Zipcode { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Geboortedatum")]
        [Required(ErrorMessage = "Vul een geboortedatum in.")]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Land")]
        [Required(ErrorMessage = "Vul een land in.")]
        public Country Country { get; set; }
        public string Iban { get; set; }
        [Display(Name = "Mobiel")]
        [Required(ErrorMessage = "Vul een nummer in.")]
        public int Phonenumber { get; set; }
        public List<User> FollowUsers { get; set; }
        public Subscription Subscription { get; set; }
        public List<Playlist> PlaylistList { get; set; }
        public User(int id, string name, string email, string zipcode, DateTime birthdate, Country country, int phonenumber, Subscription subscription) : base()
        {
            ID = id;
            Name = name;
            Email = email;
            Zipcode = zipcode;
            Birthdate = birthdate;
            Country = country;
            Phonenumber = phonenumber;
            Subscription = subscription;
        }
        public User(string name, string email, string zipcode, DateTime birthdate, Country country, int phonenumber, Subscription subscription) : base()
        {
            Name = name;
            Email = email;
            Zipcode = zipcode;
            Birthdate = birthdate;
            Country = country;
            Phonenumber = phonenumber;
            Subscription = subscription;
        }
        public User(int id, string name) : base()
        {
            ID = id;
            Name = name;
        }
    }

    public class UserLoginModel
    {
        [Display(Name = "Gebruikersnaam")]
        [Required(ErrorMessage = "Vul een gebruikersnaam in.")]
        public string Username { get; set; }
        [Display(Name = "Wachtwoord")]
        [Required(ErrorMessage = "Vul een wachtwoord in.")]
        public string Password { get; set; }
    }
}