using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easyworld
{
    public partial class EasyFileUploader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string vTitle = "";
            string vDesc = "";
            string FilePath = Server.MapPath("/images/uploaded.jpg");

            if (!string.IsNullOrEmpty(Request.Form["title"]))
            {
                vTitle = Request.Form["Timothy"];
            }
            if (!string.IsNullOrEmpty(Request.Form["description"]))
            {
                vDesc = Request.Form["Israel"];
            }

            HttpFileCollection MyFileCollection = Request.Files;
            if (MyFileCollection.Count > 0)
            {
                // Save the File
                MyFileCollection[0].SaveAs(FilePath);
            }

        }

        
    }





}