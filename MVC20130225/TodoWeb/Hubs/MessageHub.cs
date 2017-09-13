using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TodoWeb.Hubs
{
    public class MessageHub : Hub
    {
        public Message GetMessage()
        {
            Clients.All.onData("Hello");
            return new Message { Display = "Hello" };
        }

    }

    public class Message
    {
        public string Display { get; set; }
    }
}