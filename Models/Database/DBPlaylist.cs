using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Models.Database
{
    class DBPlaylist : DBContext
    {
        private DBAccount dbAccount = new DBAccount();
        private DBUser dbUser = new DBUser();
        public List<Playlist> GetPlaylistsFromUser(User user) //name of ur query
        {
            List<Playlist> ret = new List<Playlist>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM playlist WHERE Userid = " + user.ID + ""); //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (Dictionary<string, object> results in QueryX) //look for all posseble results in the query result.
            {
                Playlist dbPlaylistItem = new Playlist(Convert.ToInt32(results["id"]), Convert.ToString(results["name"]), user);
                ret.Add(dbPlaylistItem); //add each result to the created list, if the list if for a class, u need to add 'new class_name' infront of the convert
            }

            return ret;     //this will return the list as result from the query.
        }
        public List<Playlist> GetPlaylistByName(Playlist playlist) //name of ur query
        {
            List<Playlist> ret = new List<Playlist>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT * FROM playlist WHERE name = " + playlist.Name + ""); //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (Dictionary<string, object> results in QueryX) //look for all posseble results in the query result.
            {
                Playlist dbPlaylistItem = new Playlist(Convert.ToInt32(results["id"]), Convert.ToString(results["name"]), dbUser.GetUserById(Convert.ToInt32(results["Userid"])));
                ret.Add(dbPlaylistItem); //add each result to the created list, if the list if for a class, u need to add 'new class_name' infront of the convert
            }

            return ret;     //this will return the list as result from the query.
        }
        public List<string> AddPlaylist() //name of ur query
        {
            List<string> ret = new List<string>(); //result of query will end up in here
            List<Dictionary<string, object>> QueryX = getQuery("SELECT naam FROM gebruiker WHERE GebruikerID = 1"); //replace your query with te example query, replace 'QueryX' with a clear name.
            foreach (Dictionary<string, object> results in QueryX) //look for all posseble results in the query result.
            {
                ret.Add((Convert.ToString(results["naam"]))); //add each result to the created list, if the list if for a class, u need to add 'new class_name' infront of the convert
            }

            return ret;     //this will return the list as result from the query.
        }
    }
}
