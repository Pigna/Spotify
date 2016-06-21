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
    public class DBSongTests
    {
        [TestMethod()]
        public void GetSongByIdTest()
        {
            //Niet correct? Door datum denk.
            DBSong dbSong = new DBSong();
            Song actual = dbSong.GetSongById(1);
            Song expect = new Song(1, "Keep yourself Alive", 144, Convert.ToDateTime("2016-06-12"));
            Assert.AreEqual(expect,actual);
        }
        ///Gaat ook mis door datum. Zelfde probleem
        [TestMethod()]
        public void GetAllSongsTest()
        {
            Assert.Fail();
        }
    }
}