<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Easyworld.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Easyworld</title>
    <link rel="stylesheet" href="Style/Easystyle.css" />
     <meta name="viewport" content="width=device-width" />
</head>
<body>
    <form id="form1" runat="server">

 <div id="container">
     <div id="logoDiv">
         <img alt="" src="images/Easylogo.png" />

     </div>

      <div id="easyworldTextDiv">
          <asp:Label ID="EasyworldLabel" runat="server" Text="Easyworld"></asp:Label>

     </div>
    <div id="nav">
            <div id="loginContainer">
                <div class="colWithNoWidht">
                    <div class="navLabelDiv">
                        <asp:Label ID="Label1" runat="server" Text="Please Login" CssClass="navLabel"></asp:Label>
                    </div>

                    </div>
                <div class="colWithNoWidht">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="navTextbox" placeholder="Phone or Email"></asp:TextBox></div>
                <div class="colWithNoWidht">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="navTextbox" placeholder="Password"></asp:TextBox></div>
                <div class="colWithNoWidht">
                    <asp:Button ID="Login" runat="server" Text="Login" CssClass="navButtons" /></div>
                <div class="colWithNoWidht">
                    <div class="navLabelDiv">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="navLinkButton">Forgot your password?</asp:LinkButton></div>
                    </div>
            </div>
    </div>
     









        <div id="content">

            <div id="contentSection">
                <div id="contentHeaderDiv">
                    <h1>Connecting the world without limit...
                    </h1>
                    <p>We help your connect with people of your imagination, with just a click</p>
                </div>
                <div id="contentBannerDiv">
                    <img id="homebanner" alt="Easy Home Image" src="images/homebanner.png" />
                </div>

            </div>

             <div id="contentAside">
                 <div id="formContainer">
                     <div class="formContainerHeaderDiv">

                         <asp:Label ID="Label2" runat="server" Text="Create an Account"></asp:Label>
                     </div>
                    <div class="formContainerTextboxDiv">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="formContainerTextbox" placeholder="Business name" ForeColor="#0f113c"></asp:TextBox>
                     </div>
                     <div class="formContainerTextboxDiv">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="formContainerTextbox" placeholder="Phone" ForeColor="#0f113c"></asp:TextBox>
                     </div>
                     <div class="formContainerTextboxDiv">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="formContainerTextbox" placeholder="Email" ForeColor="#0f113c"></asp:TextBox>
                     </div>

                      <div class="formContainerTextboxDiv">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="formContainerTextbox" placeholder="Password" ForeColor="#0f113c"></asp:TextBox>
                     </div>

                     <div class="formContainerTextboxDiv">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="formContainerTextbox" placeholder="Confirm Password" ForeColor="#0f113c"></asp:TextBox>
                     </div>
                      <div class="formContainerTextboxDiv">
                          <asp:Button ID="Button1" runat="server" Text="Create" CssClass="formContainerButton" />
                     </div>





                 
                 </div>

                  

            </div>
    
    </div>








        <div id="footer">
    
            <div class="fourColDiv"><h4>Connecting you...</h4>
                <p>Easyworld helps you to connect with people arround the world, in a way that brings out the beauty in you.</p>
            </div>
            <div class="fourColDiv"><h4>Easyworld</h4>
                <p>
                 <asp:LinkButton ID="LinkButton2" runat="server" CssClass="navLinkButton">About</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="navLinkButton">Jobs</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="navLinkButton">Press</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="navLinkButton">Brand Center</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton6" runat="server" CssClass="navLinkButton">Privacy and Terms</asp:LinkButton>
                </p>
            </div>
            <div class="fourColDiv"><h4>Get in touch</h4>
                <p>
                    <asp:LinkButton ID="LinkButton7" runat="server" CssClass="navLinkButton">Contact Us</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton8" runat="server" CssClass="navLinkButton">Facebook</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton9" runat="server" CssClass="navLinkButton">Twitter</asp:LinkButton>
                </p>
            </div>
            <div class="fourColDiv"><h4>Connect</h4>
                <p>
                    <asp:LinkButton ID="LinkButton10" runat="server" CssClass="navLinkButton">Make a Call</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton11" runat="server" CssClass="navLinkButton">Send a Message</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton12" runat="server" CssClass="navLinkButton">Find a Friend</asp:LinkButton>
                </p>
            </div>

    </div>

</div>



        <asp:FileUpload ID="FileUpload1" runat="server" />



    </form>
</body>
</html>

