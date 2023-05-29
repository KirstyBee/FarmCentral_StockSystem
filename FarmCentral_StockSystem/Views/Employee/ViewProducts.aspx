<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="FarmCentral_StockSystem.Views.Employee.ViewProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">

     <div class="content">
        <div class="col-md-4">
            <h1>Search for Farmer Products</h1>
            <p>&nbsp;</p>
            <p>&nbsp;</p>

            <div class="mb-3">
    
    Product Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="ProductNameTextBox" class="form-control" runat="server" Width="272px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                <label id="ErrMsg" runat ="server" class="auto-style1"></label>
    <asp:Button ID="Search" runat="server" CssClass="btnSearch" Text="Search" Width="172px" OnClick="FilterButton_Click" />
</div>
<div class="mb-3">
    <label for="txtFarmId" class="form-label">
        <br />
        Enter Farmer's FarmId:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFarmId" runat="server" CssClass="form-control" Width="272px"></asp:TextBox>
    </label>
    &nbsp;
</div>
Date Range:<br />
<br />
<div class="mb-3">
    <label for="StartDateTextBox" class="form-label">
        FROM:
    </label>
    <input type="date" class="form-control" id="StartDateTextBox" name="StartDateTextBox" runat="server" />
</div>
<div class="mb-3">
    <label for="EndDateTextBox" class="form-label">
        TO:
    </label>
    <input type="date" class="form-control" id="EndDateTextBox" name="EndDateTextBox" runat="server" />
</div>
          
<div class="col-md-8" style="margin-left: 210px;">
     
    <asp:GridView runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" ID="ProductGV"
        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True"
        AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductGV_SelectedIndexChanged">
    </asp:GridView>
</div>
</div>
         </div>
    </asp:Content>