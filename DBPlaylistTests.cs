using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotify.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models.Database.Tests
{
    [TestClass()]
    public class DBPlaylistTests
    {
        [TestMethod()]
        public void GetPlaylistsFromUserTest()
        {
            DBPlaylist dbPlaylist = new DBPlaylist();

            Assert.Fail();
        }

        [TestMethod()]
        public void GetPlaylistByIDTest()
        {
            DBPlaylist dbPlaylist = new DBPlaylist();
            Playlist actual = dbPlaylist.GetPlaylistByID(1);
            User user = new User(1, "Myron Antonissen", "myron.antonissen@gmail.com", "4761KL", DateTime.Now, Country.Germany, 624196793, new Subscription("", 0.0, ""));
            Playlist expect = new Playlist(1, "MyPlaylist", user);
            Assert.AreEqual(expect,actual);
        }

        [TestMethod()]
        public void GetPlaylistByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddPlaylistTest()
        {
            DBPlaylist dbPlaylist = new DBPlaylist();
            User user = new User(1, "Myron Antonissen", "myron.antonissen@gmail.com", "4761KL", DateTime.Now, Country.Germany, 624196793, new Subscription("", 0.0, ""));
            Assert.AreEqual(true, (dbPlaylist.AddPlaylist("TestPlaylist", user)));
        }

        [TestMethod()]
        public void GetSongsFromPlaylistTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NewPlaylistTest()
        {
            DBPlaylist dbPlaylist = new DBPlaylist();
            User user = new User(1, "Myron Antonissen", "myron.antonissen@gmail.com", "4761KL", DateTime.Now, Country.Germany, 624196793, new Subscription("", 0.0, ""));
            NewPlaylistModel playlist = new NewPlaylistModel();
            Assert.AreEqual(true, dbPlaylist.NewPlaylist(playlist,user));
        }

        [TestMethod()]
        public void AddSongToPlaylistTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveSongFromPlaylistTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckIfOwnerTest()
        {
            Assert.Fail();
        }
    }
}