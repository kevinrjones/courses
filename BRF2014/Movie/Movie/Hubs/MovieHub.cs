using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Movie.Models;

namespace Movie.Hubs
{
    public class MovieHub : Hub
    {
        static List<MovieViewModel> _movies = new List<MovieViewModel>{
            new MovieViewModel{Id=1, Title = "Gone Girl", Director = "David Fincher"}, 
            new MovieViewModel{Id=2, Title = "Jaws", Director = "Steven Speilberg"}
        };

        public List<MovieViewModel> GetMovies()
        {
            return _movies;
        }

        public void SendMessage(string message)
        {
            Clients.All.BroadcastMessage(_movies[0]);
        }
    }
}
