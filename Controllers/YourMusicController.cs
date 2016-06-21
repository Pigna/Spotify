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
        DBArtist dbArtist = new DBArtist();
        DBUser dbUser = new DBUser();
        DBSong dbSong = new DBSong();
        User LogedinUser = new User(1,"","","",DateTime.Now,Country.Netherlands,0,new Subscription("",0.0,""));
        private List<Playlist> playlists = new List<Playlist>();
        // GET: YourMusic
        //List of all playlists
        public ActionResult Index(int? playlistId, int? songId)
        {
            playlists = dbPlaylist.GetPlaylistsFromUser(LogedinUser);
            if (songId != null)
            {
                dbPlaylist.RemoveSongFromPlaylist(playlists[ViewBag.PlaylistIndex], dbSong.GetSongById(Convert.ToInt32(songId)));
            }
            if (playlistId != null)
            {
                ViewBag.PlaylistIndex = GetPlaylistFromList(Convert.ToInt32(playlistId));
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
        public ActionResult Artists()
        {
            List<Artist> artistlist = dbUser.GetFollowingArtists(LogedinUser);
            return View(artistlist);
        }
        //albums
        public ActionResult Users()
        {
            List<User> userlist = dbUser.GetFollowingUsers(LogedinUser);
            return View(userlist);
        }
        //Create newplaylist
        public ActionResult NewPlaylist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPlaylist(NewPlaylistModel playlist)
        {
            if (dbPlaylist.NewPlaylist(playlist, LogedinUser))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
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