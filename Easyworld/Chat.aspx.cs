﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.SignalR;

namespace Easyworld
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Make long polling connections wait a maximum of 110 seconds for a
// response. When that time expires, trigger a timeout command and
// make the client reconnect.
//GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(110);
 
// Wait a maximum of 30 seconds after a transport connection is lost
// before raising the Disconnected event to terminate the SignalR connection.
//GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(30);
 
// For transports other than long polling, send a keepalive packet every
// 10 seconds.
// This value must be no more than 1/3 of the DisconnectTimeout value.
//GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(10);
 


        }
    }
}