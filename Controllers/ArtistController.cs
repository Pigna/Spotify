using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spotify.Models;
using Spotify.Models.Database;

namespace Spotify.Controllers
{
    public class ArtistController : Controller
    {
        DBArtist dbArtist = new DBArtist();
        // GET: Artist
        public ActionResult Index(int artistId)
        {
            Artist artist = dbArtist.GetArtistbyId(artistId);
            artist.SongList = dbArtist.GetSongsFromArtist(dbArtist.GetArtistbyId(artistId));
            return View(artist);
        }
    }
}