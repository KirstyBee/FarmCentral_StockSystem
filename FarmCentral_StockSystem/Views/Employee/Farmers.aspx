<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="Farmers.aspx.cs" Inherits="FarmCentral_StockSystem.Views.Employee.Farmers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">


   <div class="content">
        <div class="col-md-4">
            <h1>Manage Farmer</h1>

            <div class="mb-3">
                <label for="Fname" class="form-label">Name</label>
                <input type="text" class="form-control" id="Fname" runat ="server">
            </div>

            <div class="mb-3">
    <label for="Fsurname" class="form-label">Surname</label>
    <input type="text" class="form-control" id="Fsurname" runat="server">
</div>


            <div class="mb-3">
                <label for="Femail" class="form-label">Email</label>
                <input type="text" class="form-control" id="Femail" runat ="server">
            </div>

            <div class="mb-3">
                <label for="Fpassword" class="form-label">Password</label>
                <input type="text" class="form-control" id="Fpassword" runat ="server">

             </div>
             <div class="mb-3">
                <label for="Fphone" class="form-label">Contact Information</label>
                <input type="tel" class="form-control" id="Fphone" runat ="server">

             </div>
            <label id="ErrMsg" runat ="server" class="auto-style1"></label>
        <asp:Button Text="Edit" class="btnedit" runat="server" OnClick="btnEdit_Click" />
        <asp:Button Text="Save" class="btnsave" runat="server" OnClick="btnsave_Click" />
        <asp:Button Text="Delete" class="btndelete" runat="server" OnClick="btnDelete_Click" />
          
            <br />
            <br />
          
    </div>

       <asp:GridView runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" ID="FarmerGV"
    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateSelectButton="True"
    OnSelectedIndexChanged="FarmerGV_SelectedIndexChanged" DataKeyNames="FarmId">
</asp:GridView>


       </div>
      
    
</asp:Content>