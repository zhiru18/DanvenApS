﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiveChat.Startup))]
namespace LiveChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
