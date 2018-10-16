using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;

namespace Easyworld
{
    public class EasyHub : Hub
    {
        private bool loginSuccessful = false;

        private string ErrMsg;

        private static bool reconectFlag = false;

        public override Task OnConnected()
        {
            return Clients.Client(Context.ConnectionId).Connect("Connected!");
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return Clients.Client(Context.ConnectionId).CheckCandidate("Disconnected!");
        }


        public override Task OnReconnected()
        {
            reconectFlag = true;
            return base.OnReconnected();
        }


        public void Sendto(PrivateMessage data)
        {


            Clients.Client(data.ToConn).LoginResponse(data);
            LogMsg("SendTo", "SendTo was called");

        }


        public void SendAnswer(PrivateMessage data)
        {


            Clients.Client(data.ToConn).AnswerResponse(data);
            LogMsg("SendAnswer", "SendAnswer was called");

        }

        public void TestCon()
        {


            Clients.Client(Context.ConnectionId).TestConnection("Connected");
            LogMsg("Testing", "Testing Connection");

        }

        public void SendLoginResponse(PrivateMessage data)
        {


            Clients.Client(Context.ConnectionId).LoginResponse(data);


        }

       

        public void SendWebrtcConnData(PrivateMessage data)
        {


            //CHECK WHAT TYPE OF MESSAGE COMING FRO A WEBRTC CLIENT


            //when a user connects to our sever 
            // Call the broadcastMessage method to update clients.
            Clients.Client(Context.ConnectionId).Connect("Connected to Webrtc server!");

            //when server gets a message from a connected user 
            //Analize the message

            switch (data.type)
            {
                case "login":
                    onLogin(data.name,data.p);//key is password
                    break;

                case "offer":
                    //This connectionid will contain the connection of the user you want to call
                    Clients.Client(Context.ConnectionId).Connect("I entered the switch for offer");
                    onOffer(data);
                    break;

                case "answer":
                    onAnswer(data);
                    break;

                case "candidate":
                    LogMsg("Ice Switch", "I entered the Ice Switch");
                    LogMsg("candidate", data.candidate.ToString());
                    LogMsg("From", data.From);
                    LogMsg("To", data.To);


                    onCandidate(data);
                    break;

                case "msg":
                    onMsg(data);
                    break;

                case "leave":
                    onLeave(data);
                    break;

                case "openV":
                    onOpenVideoCall(data);
                    break;


                case "trafficQuestion":
                    onTrafficQuestion(data);
                    break;

                case "trafficAnswer":
                    onTrafficAnswer(data);
                    break;


                default:
                    break;


            }

            

        }


        public void onTrafficQuestion(PrivateMessage data)
        {
            //Get the connectionid of the user from the database
            string fromConn = GetConnection(data.From);
            LogMsg("From", data.From);

            //Select the connectionid of all users at the specified location from the database
            //Add the selected connectionIds to a new group
            //Send the request to all of them
            LogMsg("Traffic", "I entered traffic block");
            Stack<string> usersAtLocation = new Stack<string>();
            Stack<ConidAndAnswer> usersAtLocation2 = new Stack<ConidAndAnswer>();

            usersAtLocation2 = getUserByLocatnAndTimeForTraffic(data.MinLat, data.MaxLat, data.MinLongi, data.MaxLongi,data.tim);
            ConidAndAnswer ConnectionIds=null;
            if (usersAtLocation2.Count>0)
            {

                LogMsg("Level1", "inside level1");
                LogMsg("Count", usersAtLocation2.Count.ToString());
                int veryfree = 0;
                    int movinslowly = 0;
                    int standstill = 0;
                //Analyse the data
                
                while (usersAtLocation2.Count > 0)
                {
                    LogMsg("Level2", "inside level2");

                    ConnectionIds = usersAtLocation2.Pop();

                    if (ConnectionIds.answer == "Very Free")
                    {
                        veryfree += 1;
                    }
                    else if (ConnectionIds.answer == "Moving Slowly")
                    {
                        movinslowly += 1;
                    }
                    else if (ConnectionIds.answer == "Standstill")
                    {
                        standstill += 1;
                    }

                }

                //Find the highest answer
                String result = "Very Free";
                int high = veryfree;
                if (high < movinslowly)
                {

                    LogMsg("Level3", "inside level3");
                    high = movinslowly;
                    result = "Moving Slowly";
                }
                else if (high < standstill)
                {
                    high = standstill;
                    result = "Standstill";
                }

                //Send anawer back
                PrivateMessage trafficData = new PrivateMessage();
                trafficData.type = "trafficAnswer";
                trafficData.trafficAnswer = result;
                trafficData.From = "activeAnswer";
                trafficData.To = fromConn;
                trafficData.msgId = data.msgId;

                Clients.Client(fromConn).TrafficAnswer(trafficData);


            }
            else
            {
                LogMsg("Level4", "inside level4");
                usersAtLocation = getUserByLocatnForTraffic(data.MinLat, data.MaxLat, data.MinLongi, data.MaxLongi);

            PrivateMessage trafficData = new PrivateMessage();
            trafficData.type = data.type;
            trafficData.msgId = data.msgId;
            trafficData.From = data.From;

           //  Clients.Client(Context.ConnectionId).TrafficQuestion(trafficData);//Remove later----------------

            while (usersAtLocation.Count > 0)
            {
                    LogMsg("Level5", "inside level5");
                    LogMsg("TrafficCon", usersAtLocation.Count.ToString());

                string ConnectionIdss = usersAtLocation.Pop();
                trafficData.ToConn = ConnectionIdss;
                LogMsg("TrafficCon", ConnectionIdss);

                Clients.Client(ConnectionIdss).TrafficQuestion(trafficData);
              

            }
            }
         
        }

        public void onTrafficAnswer(PrivateMessage data)
        {

            string ToConn = GetConnection(data.To);

            LogMsg("Traffic Answer", "I enter the traffic answer block");
            LogMsg("Traffic type", data.type);
            LogMsg("Traffic Answer", data.trafficAnswer);
            LogMsg("Traffic To", data.To);
            LogMsg("Traffic From", data.From);
            PrivateMessage trafficData = new PrivateMessage();
            trafficData.type = data.type;
            trafficData.trafficAnswer = data.trafficAnswer;
            trafficData.From = data.From;
            trafficData.To = data.To;
            trafficData.msgId = data.msgId;

            Clients.Client(ToConn).TrafficAnswer(trafficData);



            LogMsg("Traffic Answer", data.trafficAnswer);
            LogMsg("Traffic time", data.tim.ToString());
            LogMsg("Traffic From", data.From);
            //Save the the answer for future use
            SaveActiveAnswer(data.From, data.trafficAnswer,data.tim);

            LogMsg("Traffic answer", "Answer was saved");
           
        }

        public void onLogin(string name,string password)
        {


            //Get the connectionid of the user from the database
            string fromConn = GetConnection(name);



            if (ConfirmMemberlogin(name, password))//name is email
            {
                LogMsg("Confirm Login", "Login Passed");

                //if anyone is logged in with this username then refuse 
                //Block 1
                if (fromConn != "" && fromConn != null && fromConn != Context.ConnectionId)//Someone is using this name and it is not a Reconnnection
                {

                    LogMsg("Block 1", "I entered Block 1");
                    PrivateMessage respons = new PrivateMessage();
                    respons.type = "login";
                    respons.success = "true";


                    //UPDATE THE CONNECTION ID
                    UpdateConnection(fromConn, Context.ConnectionId);
                    LogMsg(name, "My Connection has been updated");
                    LogMsg(name, Context.ConnectionId);
                    SendLoginResponse(respons);
                    //Clients.Client(Context.ConnectionId).Connect("I entered the login area");

                }

                //Block 2
                else if (fromConn != "" && fromConn != null && fromConn == Context.ConnectionId)//This user is Reconnecting
                {
                    LogMsg("Block 2", "I entered Block 2");

                    PrivateMessage respons = new PrivateMessage();
                    respons.type = "login";
                    respons.success = "true";

                    //do nothing
                    SendLoginResponse(respons);
                    //Clients.Client(Context.ConnectionId).Connect("I entered the login area");
                }


                //Block 3
                else if (fromConn == "" || fromConn != null)
                {
                    LogMsg("Block 3", "I entered Block 3");

                    PrivateMessage respons = new PrivateMessage();
                    respons.type = "login";
                    respons.success = "true";

                    //save the name and connectionid in the database
                    SaveUserData(name, Context.ConnectionId);

                    //do nothing
                    SendLoginResponse(respons);
                    //Clients.Client(Context.ConnectionId).Connect("I entered the login area");
                }


                //Block 4
                else
                {
                    LogMsg("Block 4", "I entered Block 4");

                    PrivateMessage respons = new PrivateMessage();
                    respons.type = "login";
                    respons.success = "true";

                    //save the name and connectionid in the database
                    SaveUserData(name, Context.ConnectionId);


                    SendLoginResponse(respons);
                    //Clients.Client(Context.ConnectionId).Connect("I entered the login area");
                }
            }
            else {

                //Block 5

               
                PrivateMessage respons = new PrivateMessage();
                respons.type = "login";
                respons.success = "false";
                SendLoginResponse(respons);

                LogMsg("Block 5", "Confirm Login failed");
                LogMsg("Email", name);
                LogMsg("Password", password);

            }

           
        }

        public void onOffer(PrivateMessage data)  // data also contains the name of the user that is beeing called
        {
            //for ex. UserA wants to call UserB 
            //console.log("Sending offer to: ", data.name);
            //if UserB exists then send him offer details 
            Clients.Client(Context.ConnectionId).Connect("I entered the offer area");


            //Get the connectionid of the user from the database
            string ToConn = GetConnection(data.To);


            // string val = data.offer;
            // string myOffer = val.Replace("object", "");

            if (ToConn != "")
            {


                PrivateMessage dataToSend = new PrivateMessage();

                dataToSend.type = "offer";
                dataToSend.offer = data.offer;         //offer from the person making the call to the connectionid
                dataToSend.From = data.From;
                dataToSend.ToConn = ToConn;

                Clients.Client(Context.ConnectionId).Connect("Message was compiled!");
                //setting that UserA connected with UserB 

                Sendto(dataToSend);


                //Log to Database
                LogMsg("dataToSend.type", "offer");
                LogMsg("dataToSend.offer", data.offer.ToString());
                LogMsg("dataToSend.From", data.From);
                LogMsg("dataToSend.ToConn", ToConn);

                LogMsg("Offer Block", "I entered the Offer Block");
            }
        }

        public void onAnswer(PrivateMessage data)   // data also contains the name and connectionid of the user that the answer is going to
        {

            //Get the connectionid of the user from the database
            string ToConn = GetConnection(data.To);
            string From = GetName(Context.ConnectionId);

            //find the conectionid of the recipient
            if (ToConn != "")
            {



                PrivateMessage dataToSend = new PrivateMessage();

                dataToSend.type = "answer";             //type of message is answer
                dataToSend.answer = data.answer;         //answer from the user that is answering the call       
                dataToSend.From = From;
                dataToSend.ToConn = ToConn;


                SendAnswer(dataToSend);
                Clients.Client(ToConn).EasyMsg("AnswerSent"); 
                //send answer back to the caller

                LogMsg("dataToSend.type", "answer");
                LogMsg("dataToSend.answer", data.answer.ToString());
                LogMsg("dataToSend.From", From);
                LogMsg("dataToSend.ToConn", ToConn);

                LogMsg("Offer Received " + From, "I have receive an offer, and have sent an answer ");
                LogMsg("Answer", "Answer received from " + From);

              
            }
        }




        public void onMsg(PrivateMessage data)   // data also contains the name and connectionid of the user that the answer is going to
        {

            //Get the connectionid of the user from the database
            string ToConn = GetConnection(data.To);
            string From = GetName(Context.ConnectionId);

          

            //find the conectionid of the recipient
            if (ToConn != "")
            {



                PrivateMessage dataToSend = new PrivateMessage();

                dataToSend.type = "msg";             //type of message is answer
                dataToSend.msg = data.msg;   //answer from the user that is answering the call   
                dataToSend.msgId = data.msgId;
                dataToSend.From = From;
                dataToSend.ToConn = ToConn;

                LogMsg("Message Block", "I entered the Message Block");

            }

            


          
        }








        //AUTHENTICATE MEMBER LOGIN----------------------------------------------------------------------
        public bool ConfirmMemberlogin(string email, string LogInPassword)
        {

            bool flag = true;
            bool result = false;
            try
            {
                string conString = @"Data Source=mssql.easyworld.com.ng,1500;Database=oeasyworld2017pass;Uid=oeasyworld;Password=easyworldstartin2017;";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = conString;

                string str = "execute confirmMemberlogin" + "'" + email + "'";


                SqlDataAdapter da = new SqlDataAdapter(str, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {


                    string SavedPasswordHash = dt.Rows[0]["kokoro"].ToString();

                    if (SavedPasswordHash == LogInPassword)
                    {
                        loginSuccessful = true;
                        result = true;
                    }


                    /*
                    byte[] hashBytes = Convert.FromBase64String(SavedPasswordHash);


                    byte[] salt = new byte[16];

                    //Take the salt out of the string
                    Array.Copy(hashBytes, 0, salt, 0, 16);


                    //Hash the entered password with the salt from the database
                    var pbkdf2 = new Rfc2898DeriveBytes(LogInPassword, salt, 10000);

                    byte[] hash = pbkdf2.GetBytes(20);

                    for (int i = 0; i < 20; i++)
                    {
                        if (hashBytes[i + 16] != hash[i])
                        {
                            flag = false;
                        }

                    }
                   
                    if (flag)
                    {

                        result = true;
                    }

                         */

                }

                con.Close();

            }
            catch (Exception e)
            {
                ErrMsg = "There was a problem, please try again later...";
            }


            return result;
        }



        public void onOpenVideoCall(PrivateMessage data)
        {
            //Get the connectionid of the user from the database
            string ToConn = GetConnection(data.To);
        
            //find the conectionid of the recipient
            if (ToConn != "")
            {



                PrivateMessage dataToSend = new PrivateMessage();

                dataToSend.type = "openV";             //type of message is answer
                dataToSend.openV = data.openV;   //answer from the user that is answering the call   
                dataToSend.From = data.From;
                dataToSend.ToConn = ToConn;


                LogMsg("dataToSend.type", "openV");
                LogMsg("dataToSend.openV", data.openV);
                LogMsg("dataToSend.From", data.From);
                LogMsg("dataToSend.ToConn", data.To);



                Sendto(dataToSend);
                LogMsg("Open Video Call", "I entered here");

            }

        }



        public void onCandidate(PrivateMessage data)
        {


            //Get the connectionid of the user from the database
            string ToConn = GetConnection(data.To);
            string From = GetName(Context.ConnectionId);


            if (ToConn != "")
            {

                PrivateMessage dataToSend = new PrivateMessage();

                dataToSend.type = "candidate";             //type of message is candidate
                dataToSend.candidate = data.candidate;
                dataToSend.From = From;
                dataToSend.ToConn = ToConn;


                SendAnswer(dataToSend);          //send candidate back


                LogMsg("Ice Block", "I have received ice candidate");
                LogMsg("type", "Candidate");
                LogMsg("candidate", data.candidate.ToString());
                LogMsg("From", From);
                LogMsg("ToConn", ToConn);


            }
        }



      

        public void onLeave(PrivateMessage data)
        {

            //Get the connectionid of the user from the database
            string ToConn = GetConnection(data.To);
            string From = GetName(Context.ConnectionId);

            if (ToConn != "")
            {


                PrivateMessage dataToSend = new PrivateMessage();
                dataToSend.type = "leave";
                dataToSend.From = From;
                dataToSend.ToConn = ToConn;

                Sendto(dataToSend);          //inform the sender of being disconnected

                DelConnectionInfo(From);

                Clients.Client(Context.ConnectionId).CheckCandidate("Disconnected");
                Clients.Client(ToConn).CheckCandidate("Your Friend  " + From + "  has just left ,Disconnected");


            }
        }



        public void SaveUserData(string name, string conn)
        {
            try
            {
                string conString = @"Data Source=mssql.easyworld.com.ng,1500;Database=oeasyworld2017pass;Uid=oeasyworld;Password=easyworldstartin2017;";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = conString;

                string str = "execute UpdateConnectionInfo" + "'" + name + "'" + "," + "'" + conn + "'";


                SqlDataAdapter da = new SqlDataAdapter(str, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                LogMsg(name,"My Data has been saved");
            }
            catch (Exception e)
            {

            }
        }


        public string GetConnection(string name)
        {
            string conn = "";

            try
            {
                string conString = @"Data Source=mssql.easyworld.com.ng,1500;Database=oeasyworld2017pass;Uid=oeasyworld;Password=easyworldstartin2017;";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = conString;

                string str = "execute GetConnection" + "'" + name + "'";


                SqlDataAdapter da = new SqlDataAdapter(str, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    conn = dt.Rows[0]["conId"].ToString();
                }


            }
            catch (Exception e)
            {

            }

            return conn;
        }


        public string GetName(string conn)

        {
            string name = "";


            try
            {
                string conString = @"Data Source=mssql.easyworld.com.ng,1500;Database=oeasyworld2017pass;Uid=oeasyworld;Password=easyworldstartin2017;";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = conString;

                string str = "execute GetName" + "'" + conn + "'";


                SqlDataAdapter da = new SqlDataAdapter(str, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    name = dt.Rows[0]["emailaddress"].ToString();
                }


            }
            catch (Exception e)
            {

            }


            return name;
        }




        public void DelConnectionInfo(string name)

        {



            try
            {
                string conString = @"Data Source=mssql.easyworld.com.ng,1500;Database=oeasyworld2017pass;Uid=oeasyworld;Password=easyworldstartin2017;";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = conString;

                string str = "execute DelConnectionInfo" + "'" + name + "'";


                SqlDataAdapter da = new SqlDataAdapter(str, con);

                DataTable dt = new DataTable();

                da.Fill(dt);




            }
            catch (Exception e)
            {

            }



        }



        public void UpdateConnection(string oldConnectionId,string newConnectionId)

        {



            try
            {
                string conString = @"Data Source=mssql.easyworld.com.ng,1500;Database=oeasyworld2017pass;Uid=oeasyworld;Password=easyworldstartin2017;";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = conString;

                string str = "execute UpdateConnectionId" + "'" + oldConnectionId + "'" + "," + "'" + newConnectionId + "'";


                SqlDataAdapter da = new SqlDataAdapter(str, con);

                DataTable dt = new DataTable();

                da.Fill(dt);


                

            }
            catch (Exception e)
            {

            }



        }


        public void password_is_correct(string email, string pw)

        {



            try
            {
                string conString = @"Data Source=mssql.easyworld.com.ng,1500;Database=oeasyworld2017pass;Uid=oeasyworld;Password=easyworldstartin2017;";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = conString;

                string str = "execute UpdateConnectionId" + "'" + email + "'" + "," + "'" + pw + "'";


                SqlDataAdapter da = new SqlDataAdapter(str, con);

                DataTable dt = new DataTable();

                da.Fill(dt);




            }
            catch (Exception e)
            {

            }



        }



        public void JoinAGroup(string group, string message)
        {
            Groups.Add(Context.ConnectionId, group);
            Clients.Group(group).addChatMessage(message);
        }


        public void RemoveFromGroup(string group)
        {
            Groups.Remove(Context.ConnectionId, group);
        }

        public void BroadcastToGroup(string group, string message)
        {

            Clients.Group(group).addChatMessage(message);

        }


        public void LogMsg(string title, string description)
        {



            try
            {
                string conString = @"Data Source=mssql.easyworld.com.ng,1500;Database=oeasyworld2017pass;Uid=oeasyworld;Password=easyworldstartin2017;";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = conString;

                string str = "execute LogMsg" + "'" + title + "'" + "," + "'" + description + "'";


                SqlDataAdapter da = new SqlDataAdapter(str, con);

                DataTable dt = new DataTable();

                da.Fill(dt);




            }
            catch (Exception e)
            {

            }
        }


        public Stack<string> getUserByLocatnForTraffic(double minlat, double maxlat, double minlon, double maxlon)
        {
            Stack<string> usersAtLocation = new Stack<string>();

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getUserByLocatnForTraffic" + "'" + minlat + "'" + "," + "'" + maxlat + "'" + "," + "'" + minlon + "'" + "," + "'" + maxlon + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("EwMem20ber17tbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    for (int i=0; i<10; i++)
                    {
                        usersAtLocation.Push(dtt.Rows[i]["conId"].ToString());
                       
                    }
                    
                }

               

            }
            catch (Exception e)
            {
                
            }

            return usersAtLocation;
        }


        public Stack<ConidAndAnswer> getUserByLocatnAndTimeForTraffic(double minlat, double maxlat, double minlon, double maxlon, string tim)
        {
            Stack<ConidAndAnswer> usersAtLocation = new Stack<ConidAndAnswer>();
            ConidAndAnswer data = new ConidAndAnswer();

            try
            {
                LogMsg("Block 6 Time", tim);
                LogMsg("Block 6", "I entered Block 6");
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getUserByLocatnForTraffic2" + "'" + minlat + "'" + "," + "'" + maxlat + "'" + "," + "'" + minlon + "'" + "," + "'" + maxlon + "'" + "," + "'" + tim + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                LogMsg("Block 7", "I entered Block 7");
                if (dtt.Rows.Count > 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        data.conid = dtt.Rows[i]["conId"].ToString();
                        data.answer = dtt.Rows[i]["answer"].ToString();
                        LogMsg("Block 7 answer", data.answer);
                        LogMsg("Block 7 Conid", data.conid);
                        usersAtLocation.Push(data);

                    }

                }



            }
            catch (Exception e)
            {
                LogMsg("Block 8", e.ToString());
            }

            return usersAtLocation;
        }

        public void SaveActiveAnswer(string email, string ans, string tim)
        {
            Stack<ConidAndAnswer> usersAtLocation = new Stack<ConidAndAnswer>();
            ConidAndAnswer data = new ConidAndAnswer();
            
            try
            {
                LogMsg("SaveActiveAnswer", "Top " );
                LogMsg("email", email);
                LogMsg("ans", ans);
                LogMsg("time", tim.ToString());
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute [insertAnwer]" + "'" + email + "'" + "," + "'" + ans + "'" + "," + "'" + tim + "'" ;
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                LogMsg("SaveActiveAnswer", "Bottom");
            }
            catch (Exception e)
            {
                LogMsg("SaveActiveAnswer", "Failed " + e.ToString());
            }

            
        }


    }
}