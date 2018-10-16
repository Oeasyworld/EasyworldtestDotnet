using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Xml;
using System.Globalization;

namespace Easyworld
{
    /// <summary>
    /// Summary description for ewc
    /// </summary>
    [WebService(Namespace = "http://www.easyworld.com.ng/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ewc : System.Web.Services.WebService
    {

        string errInfo = "";
        [WebMethod]
        public string getUserInfo(string uname, string pwd)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getUserInfo" + "'" + uname + "'" + "," + "'" + pwd + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("EwMem20ber17tbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }

        [WebMethod]
        public string getbc()
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getbc";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("Ewbc");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                Stream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }


        [WebMethod]
        public string SendMessageByProffession(string senderEmail, double senderLat,
            double senderLon, string receiverProffession, string receiverEmail,
            double receiverMinLat, double receiverMaxLat, double receiverMinLon,
            double receiverMaxLon, string msg, string photo, string video,
            string audio, DateTime tim, DateTime datee, string privacy, string subjectheader,
            bool seenflag, int radius, string likes, string msgid)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute SendMessageByProffession" + "'" + senderEmail + "'" +
                    "," + "'" + senderLat + "'" + "," + "'" + senderLon + "'" +
                    "," + "'" + receiverProffession + "'" + "," + "'" + receiverEmail + "'" +
                    "," + "'" + receiverMinLat + "'" + "," + "'" + receiverMaxLat + "'" +
                    "," + "'" + receiverMinLon + "'" + "," + "'" + receiverMaxLon + "'" +
                    "," + "'" + msg + "'" + "," + "'" + photo + "'" + "," + "'" + video + "'" +
                    "," + "'" + audio + "'" + "," + "'" + tim + "'" + "," + "'" + datee + "'" +
                    "," + "'" + privacy + "'" + "," + "'" + subjectheader + "'" +
                    "," + "'" + seenflag + "'" + "," + "'" + radius + "'" + "," + "'" + likes + "'" +
                    "," + "'" + msgid + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("ProfessionalMessagetbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }



        [WebMethod]
        public string SendMessageByLocation(string senderEmail, double senderLat,
           double senderLon, string receiverEmail,
           double receiverMinLat, double receiverMaxLat, double receiverMinLon,
           double receiverMaxLon, string msg, string photo, string video,
           string audio, DateTime tim, DateTime datee, string privacy, string subjectheader,
           bool seenflag, int radius, string likes, string msgid)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute SendMessageByLocation" + "'" + senderEmail + "'" +
                    "," + "'" + senderLat + "'" + "," + "'" + senderLon + "'" + "," + "'" + receiverEmail + "'" +
                    "," + "'" + receiverMinLat + "'" + "," + "'" + receiverMaxLat + "'" +
                    "," + "'" + receiverMinLon + "'" + "," + "'" + receiverMaxLon + "'" +
                    "," + "'" + msg + "'" + "," + "'" + photo + "'" + "," + "'" + video + "'" +
                    "," + "'" + audio + "'" + "," + "'" + tim + "'" + "," + "'" + datee + "'" +
                    "," + "'" + privacy + "'" + "," + "'" + subjectheader + "'" +
                    "," + "'" + seenflag + "'" + "," + "'" + radius + "'" + "," + "'" + likes + "'" +
                    "," + "'" + msgid + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("Messagetbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }



        [WebMethod]
        public string getMessageByEmail(string senderEmail)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getMessageByEmail" + "'" + senderEmail + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("Messagetbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }




        [WebMethod]
        public string getFeed(string senderEmail)
        {
            string xmlstr = "";

            StringBuilder command = new StringBuilder();
            command.Append("Select Email, message from Messagetb where Email =" + "'" + senderEmail + "'" + "  " + " or ");
            int i = 0;
            int i2 = 0;

            try
            {

                //'CONECT TO DATABASE
                // 'CHECK IF EMAIL OR PHONE NUMBER HAS BEEN USED BY ANOTHER USER--------------------------

                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;

                // 'OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                // 'Get the friend list
                string strr = "execute getFriendList" + "'" + senderEmail + "'";
                SqlDataAdapter daa = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("Friendtb");
                daa.Fill(dtt);

                //  'Get the friend list count
                string strrcount = "execute getFriendListCount" + "'" + senderEmail + "'";
                SqlDataAdapter daacount = new SqlDataAdapter(strrcount, con);
                DataTable dttcount = new DataTable("Friendtb");
                daacount.Fill(dttcount);


                //'SAVE THE COUNT FRIEND
                int Count = Convert.ToInt32(dttcount.Rows[0]["FriendCount"].ToString());
                // 'OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO



                // 'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                // 'Get the List of people you are following
                string strrfl = "execute getFollowList" + "'" + senderEmail + "'";
                SqlDataAdapter daafl = new SqlDataAdapter(strrfl, con);
                DataTable dttfl = new DataTable("Followerstb");
                daafl.Fill(dttfl);

                //  'Get the follow count
                string strrcountfl = "execute getFollowListCount" + "'" + senderEmail + "'";
                SqlDataAdapter daacountfl = new SqlDataAdapter(strrcountfl, con);
                DataTable dttcountfl = new DataTable("Followerstb");
                daacountfl.Fill(dttcountfl);

                //'SAVE THE COUNT FOLLOW
                int Countfl = Convert.ToInt32(dttcountfl.Rows[0]["FriendCount"].ToString());
                //'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA


                // 'GENERATE THE COMMAND ADDING THE FRIENDS
                //'////////////////////////////////////////////////////////////
                while (Count > 0)
                {
                    command.Append(" " + "Email=" + "'" + dtt.Rows[i]["friend"].ToString() + "'" + " ");

                    if (Count > 1)
                    {
                        command.Append("or" + " ");
                    }

                    i += 1;
                    Count -= 1;
                }
                // '///////////////////////////////////////////////////////


                //'UPDATE THE COMMAND ANDDING THE FOLLOW
                //'--------------------------------------------------------------------

                while (Countfl > 0)
                {

                    if (i2 > 0)
                    {
                        command.Append("or" + " ");
                    }

                    command.Append(" " + "Email=" + "'" + dtt.Rows[i2]["Email"].ToString() + "'" + " ");

                    if (Countfl > 1)
                    {
                        command.Append("or" + " ");
                    }

                    i2 += 1;
                    Countfl -= 1;
                }
                // '------------------------------------------------------------------------

                SqlDataAdapter daa2 = new SqlDataAdapter(command.ToString(), con);
                DataTable dtt2 = new DataTable("Messagetb");
                daa2.Fill(dtt2);

                MemoryStream str = new MemoryStream();
                dtt2.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }



        [WebMethod]
        public string getMessageByProffession(double userlat, double userlon, double receiverProffession)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getMessageByProfByLocatn" + "'" + userlat + "'" + "," + "'" + userlon + "'" + "," + "'" + receiverProffession + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("ProffessionalMessagetbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }


        [WebMethod]
        public string getMessageByLocation(double userlat, double userlon)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getMessageByLocatn" + "'" + userlat + "'" + "," + "'" + userlon + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("Messagetbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }


        [WebMethod]
        public string basReg(string fname, string email, string pwd)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute basReg" + "'" + fname + "'" + "," + "'" + email + "'" + "," + "'" + pwd + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("Ewbc");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }


        [WebMethod]
        public string basicRegistration(string fname,  string email, string pwd, string pnone, DateTime dateofbirth, string occupation,string gender)
        {
            string xmlstr = "";
            string userid = SerialGen();







            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute basicRegistration" + "'" + userid + "'" + "," + "'" + fname + "'" + "," + "'" + email + "'" + "," + "'" + pwd + "'" + "," + "'" + pnone + "'" + "," + "'" + dateofbirth + "'" + "," + "'" + occupation + "'" + "," + "'" + gender + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("EwMem20ber17tbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }


       

        [WebMethod]
        public string uploctn(string email, string pwd, double lon, double lat)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute updatelocation" + "'" + email + "'" + "," + "'" + pwd + "'" + "," + "'" + lon + "'" + "," + "'" + lat + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("Ewbc");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }



        [WebMethod]
        public string getUserByLocatn(double minlat, double maxlat, double minlon, double maxlon)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getUserByLocatn" + "'" + minlat + "'" + "," + "'" + maxlat + "'" + "," + "'" + minlon + "'" + "," + "'" + maxlon + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("EwMem20ber17tbl");
                da.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    // Day1 = Convert.ToInt32(dt.Rows[0]["d1"]);
                }

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();

            }
            catch (Exception e)
            {
                errInfo = e.ToString();
            }

            return xmlstr;
        }




       [WebMethod]
        public string upldImage(string exten, string imgname,string encodedImage)
        {


            //Save Image name to database the save the image file


           string xmlstr = "";

            string resp = "";

            string extentn = "";


            if (exten == "j")
            {
                extentn = "jpg";
            }
            else
            {
                extentn = "png";
            }





            string directory = Server.MapPath("/images/");

            byte[] data = System.Convert.FromBase64String(encodedImage);

            ImageConverter imageConverter = new ImageConverter();
            System.Drawing.Image originalBMP = imageConverter.ConvertFrom(data) as System.Drawing.Image;
            Bitmap b = new Bitmap(originalBMP);




            using (MemoryStream ms = new MemoryStream(data))
            {
                originalBMP = System.Drawing.Image.FromStream(ms);

            }


            // 'Calculate the new image dimensions
            int origWidth = originalBMP.Width;
            int origHeight = originalBMP.Height;
            LogMsg("Data sent to calculator", origWidth + "   " + origHeight);

            ImageSize calSize = CalNewImageDim(originalBMP.Width, originalBMP.Height);

            int newWidth = calSize.resultWidth;
            int newHeight = calSize.resultHeight;
            LogMsg("Result returned to caller", newWidth + "   " + newHeight);

            int sngRatio = origWidth / origHeight;

            // ' Create a new bitmap which will hold the previous resized bitmap
            Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

            //  'Create a graphic based on the new bitmap
            Graphics oGraphics = Graphics.FromImage(newBMP);

            //  'Set the properties for the new graphic file
            oGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // ' Draw the new graphic based on the resized bitmap
            oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

            //GET THE IMAGE FORMAT
             //string  imgFormat = GetImageFormat(newBMP);

            //GENERATE A NEW NAME FOR THE IMAGE
            //string newImageName = SerialGen() + "." + imgFormat;

            // 'Save the new graphic file to the server--------------------------------------------------------------
            newBMP.Save(directory + imgname + "." + extentn);

            // 'Once finished with the bitmap objects, we deallocate them.
            originalBMP.Dispose();
            newBMP.Dispose();
            oGraphics.Dispose();


             resp = "<EwMem20ber17tbl><Respons>" + imgname + "." + extentn + "</Respons></EwMem20ber17tbl>";

           

            return resp;
        }


       public string SerialGen()
        {
            StringBuilder serial = new StringBuilder();

            string[] Mylist = {"a","b","c","d","e","f","g","h","i","j",
                             "k","l","m","n","o","p","q","r","s","t",
                             "u","v","w","x","y","z","A","B","C","D","E",
                             "F","G","H","I","J","K","L","M","N","O","P",
                             "Q","R","S","T","U","V","W","X","Y","Z","1","2","3","4","5","6","7","8","9","0"};

            Random rand = new Random();
            for (int number = 1; number <= 35; number++)
            {
                int randomNumber = rand.Next(61) + 1;

                serial.Append(Mylist[randomNumber]);


            }

            string result = serial.ToString();


            return result;
        }




        public static string GetImageFormat(Bitmap img)
        {
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return "jpg";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return "bmp";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return "Png";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
                return "Emf";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif))
                return "Exif";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return "Gif";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
                return "Icon";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
                return "jpg";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return "Tiff";
            else
                return "png";
        }


       [WebMethod]
        public string UpdatePhoto(string pw,  string email,  string valu) 
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute UpdatePhoto" + "'" + pw + "'" + "," + "'" + email + "'"  + "," + "'" + valu + "'" ;
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("EwMem20ber17tbl");
                da.Fill(dtt);

                con.Close();
                con.Dispose();

              
                if (dtt.Rows.Count > 0)
                {
                   

                MemoryStream str = new MemoryStream();
                dtt.WriteXml(str, false);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(str);
                xmlstr = sr.ReadToEnd();
              }
            }
            catch (Exception e)
            {
               
            }

            
            return xmlstr;
        }




        [WebMethod]
        public string SendPost(string email,string pw, string postId
            , string postTitle,string imageName, string videoName
            , string contentt,string tim,DateTime dat, double logi
            , double lati, string privacy,int likes, int comments, int dislikes)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute SendPost" + "'" + email + "'" + "," + "'" + pw + "'" + "," + "'" + postId 
                    + "'" + "," + "'" + postTitle + "'" + "," + "'" + imageName + "'" + "," + "'" + videoName 
                    + "'" + "," + "'" + contentt + "'" + "," + "'" + tim + "'" + "," + "'" + dat + "'"
                     + "," + "'" + logi + "'" + "," + "'" + lati + "'" + "," + "'" + privacy + "'"
                     + "," + "'" + likes + "'" + "," + "'" + comments + "'" + "," + "'" + dislikes + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("WallPost");
                da.Fill(dtt);

                con.Close();
                con.Dispose();


                if (dtt.Rows.Count > 0)
                {


                    MemoryStream str = new MemoryStream();
                    dtt.WriteXml(str, false);
                    str.Seek(0, SeekOrigin.Begin);
                    StreamReader sr = new StreamReader(str);
                    xmlstr = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {

            }


            return xmlstr;
        }



        [WebMethod]
        public string GetWallPostByEmail(string email)
        {
            string xmlstr = "";

            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getWallPostByEmail" + "'" + email + "'" ;
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("WallPost");
                da.Fill(dtt);

                con.Close();
                con.Dispose();


                if (dtt.Rows.Count > 0)
                {


                    MemoryStream str = new MemoryStream();
                    dtt.WriteXml(str, false);
                    str.Seek(0, SeekOrigin.Begin);
                    StreamReader sr = new StreamReader(str);
                    xmlstr = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {

            }


            return xmlstr;
        }


        [WebMethod]
        public string GetWallPostByTime(string email,string dat)
        {
            string xmlstr = "";

            LogMsg("Level A", dat.ToString());
            // string  datt = dat.ToString("MM/dd/yyyy HH:mm:ss");//yyyy'-'MM'-'dd HH':'mm':'ss'Z'    DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
            string data = dat.Replace("'","");
            DateTime dattt = Convert.ToDateTime(data, CultureInfo.InvariantCulture);

            
             LogMsg("Level B", data);
            LogMsg("Level B", email);
            try
            {
               
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = conString;
                string strr = "execute getWallPostByEmailTime" + "'" + email + "'" + "," + "'" + dattt + "'";
                SqlDataAdapter da = new SqlDataAdapter(strr, con);
                DataTable dtt = new DataTable("WallPost");
                da.Fill(dtt);

                con.Close();
                con.Dispose();

                LogMsg("Level C", data);
                LogMsg("Level C", email);
                if (dtt.Rows.Count > 0)
                {


                    MemoryStream str = new MemoryStream();
                    dtt.WriteXml(str, false);
                    str.Seek(0, SeekOrigin.Begin);
                    StreamReader sr = new StreamReader(str);
                    xmlstr = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                LogMsg("Post Error", email);
                LogMsg("Post Error", data);
                LogMsg("Post Error", e.ToString());
            }


            return xmlstr;
        }


        public class ImageSize
        {
            public int resultWidth { get; set; }
            public int resultHeight { get; set; }

        }


        public ImageSize CalNewImageDim(int originalWidth,int OriginalHeigth) {
            ImageSize imageSize = new ImageSize();

            int targetHeightWidth = 600;

            if ((originalWidth < targetHeightWidth + 1) && (OriginalHeigth < targetHeightWidth + 1))
            {
                LogMsg(originalWidth + " " + OriginalHeigth, "Height and width are smaller than target");

                imageSize.resultWidth = originalWidth;
                imageSize.resultHeight = OriginalHeigth;

                LogMsg("Result", originalWidth + "   " + OriginalHeigth);
            }
            else if ((originalWidth > targetHeightWidth + 1) && (OriginalHeigth < targetHeightWidth + 1))
            {
                LogMsg(originalWidth + " " + OriginalHeigth, "Width is greater than target, and height");

                //SCALE BY WIDTH----
                //SET THE HEIGHT TO THE TARGET HEIGHT
                int newWidth = targetHeightWidth;

                //CALCULATE THE PERCENT REDUCTION FROM ORIGINAL HEIGHT TO TARGET HEIGHT
                int resizePercent = (targetHeightWidth * 100) / originalWidth;

                //USE THE PERCENTAGE TO CALCULATE THE WIDTH
                int newHeight = (resizePercent * OriginalHeigth) / 100;

                //RETURN THE NEW HEIGHT AND WIDTH------
                imageSize.resultWidth = newWidth;
                imageSize.resultHeight = newHeight;

                LogMsg("Result", newWidth+"   "+newHeight);
            }
            else if ((originalWidth < targetHeightWidth + 1) && (OriginalHeigth > targetHeightWidth + 1))
            {
                LogMsg(originalWidth + " " + OriginalHeigth, "Height is greater than target, and width");
                //SCALE BY HEIGHT----
                //SET THE HEIGHT TO THE TARGET HEIGHT
                int newHeight = targetHeightWidth;

                //CALCULATE THE PERCENT REDUCTION FROM ORIGINAL HEIGHT TO TARGET HEIGHT
                int resizePercent = (targetHeightWidth * 100) / OriginalHeigth;

                //USE THE PERCENTAGE TO CALCULATE THE HEIGHT
                int newWidth = (resizePercent * originalWidth) / 100;

                //RETURN THE NEW HEIGHT AND WIDTH------
                imageSize.resultWidth = newWidth;
                imageSize.resultHeight = newHeight;

                LogMsg("Result", newWidth + "   " + newHeight);
            }
            else if ((originalWidth > targetHeightWidth ) && (OriginalHeigth > targetHeightWidth))
            {
                LogMsg(originalWidth + " " + OriginalHeigth, "Height and width are greater than target");
                //SET THE HEIGHT TO THE TARGET HEIGHT
                int newHeight = targetHeightWidth;

                //CALCULATE THE PERCENT REDUCTION FROM ORIGINAL HEIGHT TO TARGET HEIGHT
                int resizePercent = (targetHeightWidth * 100) / OriginalHeigth;

                //USE THE PERCENTAGE TO CALCULATE THE WIDTH
                int newWidth = (resizePercent * originalWidth) / 100;

                //RETURN THE NEW HEIGHT AND WIDTH------
                imageSize.resultWidth = newWidth;
                imageSize.resultHeight = newHeight;


                LogMsg("Result", newWidth + "   " + newHeight);

            }
            else { }
            return imageSize;
        }




        public void LogMsg(string title, string description)
        {



            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Easypassworld2017ConnectionString"].ConnectionString; 
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













    }


}


  
