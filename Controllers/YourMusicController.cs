using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spotify.Models;

namespace Spotify.Controllers
{
    public class YourMusicController : Controller
    {
        List<Playlist> playlists = new List<Playlist>
        {
            new Playlist(1,"Playlist1",null),
            new Playlist(2,"Playlist2",null),
            new Playlist(3,"Playlist3",null),
            new Playlist(4,"Playlist4",null)
        };
        // GET: YourMusic
        //List of all playlists
        public ActionResult Index(int PlaylistId = 0)
        {
            if (PlaylistId == 0)
            {
                ViewBag.PlaylistIndex = PlaylistId;
            }
            else
            {
                ViewBag.PlaylistIndex = GetPlaylistFromList(PlaylistId);
            }
            return View(playlists);

        }

        public ActionResult _Playlist(int PlaylistId = 0)
        {
            Playlist playlist = playlists[PlaylistId];
            return View(playlist);
        }
        //Songs
        public ActionResult Songs()
        {
            return View();
        }
        //Artists
        public ActionResult Artists()
        {
            return View();
        }
        //albums
        public ActionResult Albums()
        {
            return View();
        }
        //Create newplaylist
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }
        private int GetPlaylistFromList(int id)
        {
            //change playlist with getmethod
            foreach (var playlist in playlists)
            {
                if (playlist.ID == id)
                {
                    int index = playlists.IndexOf(playlist);
                    if (index == -1)
                    {
                        return 0;
                    }
                    else
                    {
                        return index;
                    }
                }
            }
            return 0;
        }
    }
}