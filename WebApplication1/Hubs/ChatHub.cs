﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await this.Clients.All.SendAsync("RecieveMessage", user, message);
        }
    }
}
