using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spotify.Models;
using Spotify.Models.Database;

namespace Spotify.Controllers
{
    public class SongController : Controller
    {
        DBSong dbSong = new DBSong();

        // GET: Song
        public ActionResult Index(int? start)
        {
            if (start == null || start < 0)
            {
                start = 0;
            }
            ViewBag.AllSongStart = start;
            List<Song> SongList = dbSong.GetAllSongs(Convert.ToInt32(start));
            return View(SongList);
        }
    }
}