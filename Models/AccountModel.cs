using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models
{
    class AccountRegistereUser
    {
        [Required(ErrorMessage = "Vul een gebruikersnaam in.")]
        [StringLength(55, MinimumLength = 4, ErrorMessage = "Lengte groter dan 4, kleiner dan 55.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vul een wachtword in.")]
        [StringLength(55, MinimumLength = 4, ErrorMessage = "Lengte groter dan 4, kleiner dan 55.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vul een naam in.")]
        [StringLength(55, MinimumLength = 4, ErrorMessage = "Lengte groter dan 4, kleiner dan 55.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vul een naam in.")]
        [StringLength(55, MinimumLength = 4, ErrorMessage = "Lengte groter dan 4, kleiner dan 55.")]
        public string Email { get; set; }
        public string Zipcode { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public Country Country { get; set; }
        public string Iban { get; set; }
        public int Phonenumber { get; set; }
    }
}
