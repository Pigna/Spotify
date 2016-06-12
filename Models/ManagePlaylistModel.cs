using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spotify.Models
{
    public class NewPlaylist
    {
        [Required(ErrorMessage = "Vul een naam in.")]
        [StringLength(55,MinimumLength = 4,ErrorMessage = "Lengte groter dan 4, kleiner dan 55.")]
        public string Name { get; set; }
    }
}