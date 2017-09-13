using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebSockets.Hubs
{
    public class TennisHub : Hub
    {
        static readonly List<Player> Players = new List<Player>{new Player{Id = 1, Name="Murray"}, new Player{Id=2, Name = "Nadal"}};

        public List<Player> GetPlayers()
        {
            return Players;
        }
        
        public void AddPlayer(string firstName, string lastName, int ranking)
        {
            
        }

        public void UpdateScores()
        {
            Clients.All.newScore(new Player {Name = "Murray"}, "6-2");
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}