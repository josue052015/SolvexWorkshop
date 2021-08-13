using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Model;

namespace TodoApi.hub
{
    public class Hubs : Hub
    {
        public async Task SendTodo(string todo)
        {
            await Clients.All.SendAsync("ReceiveTodo", todo);
        }
    }
}
