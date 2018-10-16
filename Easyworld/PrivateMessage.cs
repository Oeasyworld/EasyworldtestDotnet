using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easyworld
{
    public class PrivateMessage
    {
        public string type { get; set; }//traffic,offer,answer,candidate,message
        public Object offer { get; set; }
        public string name { get; set; }
        public string p { get; set; }
        public string userID { get; set; }
        public Object answer { get; set; }
        public string msg { get; set; }
        public string msgId { get; set; }
        public string tim { get; set; }
        public Object candidate { get; set; }
        public string success { get; set; }
        public string connectioid { get; set; }

        public string From { get; set; }
        public string To { get; set; }
        public string FromConn { get; set; }
        public string ToConn { get; set; }
        public string openV { get; set; }
        public string leave { get; set; }
        public string TrafficQuestion { get; set; }//traffic question
        public string trafficAnswer { get; set; }//free,moving slowly or standstill
        public double MinLat { get; set; }
        public double MaxLat { get; set; }
        public double MinLongi { get; set; }
        public double MaxLongi { get; set; }


    }
}