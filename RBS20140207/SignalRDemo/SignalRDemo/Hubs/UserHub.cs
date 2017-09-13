using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRDemo.Models;

namespace SignalRDemo.Hubs
{
    public class UserHub : Hub
    {
        static readonly List<User> Users = new List<User> { new User { Id = 1, Name = "Kevin" }, new User { Id = 2, Name = "Teresa" } };
        public User GetUser(int id)
        {
            Clients.All.Update("Got a request");
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public IList<User> GetUsers()
        {
            return Users;
        } 
    }
}