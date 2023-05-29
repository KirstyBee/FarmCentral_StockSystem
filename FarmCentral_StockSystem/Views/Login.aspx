<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FarmCentral_StockSystem.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Assests/css/LoginStyle.css" rel="stylesheet" />
       <style type="text/css">
           .auto-style1 {
               width: 110px;
               height: 103px;
               overflow: hidden;
               top: -53px;
               left: 122px;
               position: absolute;
           }
       </style>
       </head>
    <body>
        <div class ="loginbox">
            <img src="../Assests/Images/login_icon.png" alt="Alternate Text" class ="auto-style1" />
            <h2>Login Here</h2>
            <form runat="server">
                <asp:Label Text ="Email" CssClass="lblemail" runat="server"/>
                <asp:TextBox runat="server" CssClass="txtemail" placeholder="Enter email" ID="Email" required ="required"/>

                <asp:Label Text ="Password" CssClass="lblpass" runat="server" />
                <asp:TextBox runat="server" CssClass="txtpass" TextMode="Password" placeholder="Enter Password" ID="Password"  required ="required"/>  

               <asp:Label CssClass="lblfarmer" Text="Farmer" runat="server" />
                <asp:RadioButton runat ="server" CssClass="checkbx1" ID="FarmerRadio"  name="Role" GroupName="RoleGroup"/>
                
              <!--  <asp:Label CssClass="lblemployee" Text="Admin" runat="server" />
                <asp:RadioButton runat ="server" CssClass="checkbx2" ID="AdminRadio" Checked="False"  name="Role"/>-->

                <asp:Label CssClass="lblemployee" Text="Admin" runat="server" />
                <asp:RadioButton runat="server" CssClass="checkbx2" ID="AdminRadioControl" Checked="False" AutoPostBack="true" GroupName="RoleGroup" />


                
                <label id ="errMsg" runat ="server"></label>

                <asp:Button Text="Sign In" CssClass="btnsubmit" runat="server" Id="SignInBtn" OnClick="SignInBtn_Click"/>
                <asp:LinkButton Text="Forgot Password" CssClass="btnforgot" runat="server" />

            </form>
        </div>
</body>
</html>
