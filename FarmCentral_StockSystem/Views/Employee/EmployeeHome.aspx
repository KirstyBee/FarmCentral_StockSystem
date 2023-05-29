<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeHome.aspx.cs" Inherits="FarmCentral_StockSystem.Views.Employee.EmployeeHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">

    <div style="background-image:url(../../Assests/Images/Farmbg.jpg); 
     width:100%; 
     height:720px; 
     background-repeat:no-repeat; 
     background-size:cover;
     background-attachment:fixed;">

        <div>
            <asp:Label ID="lblMsg" runat ="server"></asp:Label>
        </div>
        <h3 style="padding:0;
          margin:0;
          text-align:center;
          color:#4cff00;">Welcome to the Admin Home Page</h3>
    </div>
    
</asp:Content>
