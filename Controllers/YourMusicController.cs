using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spotify.Models;
using Spotify.Models.Database;

namespace Spotify.Controllers
{
    public class YourMusicController : Controller
    {
        DBPlaylist dbPlaylist = new DBPlaylist();
        User LogedinUser = new User(1,"","","",DateTime.Now,Country.Netherlands,"",0,new Subscription("",0.0,""));
        private List<Playlist> playlists = new List<Playlist>();
        // GET: YourMusic
        //List of all playlists
        public ActionResult Index(int? playlistId)
        {
            playlists = dbPlaylist.GetPlaylistsFromUser(LogedinUser);
            if (playlistId != null)
            {
                int id = Convert.ToInt32(playlistId);
                ViewBag.PlaylistIndex = GetPlaylistFromList(id);
                
            }
            else
            {
                ViewBag.PlaylistIndex = 0;
            }
            return View(playlists);

        }

        public ActionResult _Playlist(int PlaylistId = 0)
        {
            Playlist playlist = dbPlaylist.GetPlaylistByID(PlaylistId);
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
            foreach (Playlist playlist in playlists)
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