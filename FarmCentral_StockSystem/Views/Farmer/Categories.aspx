<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Farmer/FarmerMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="FarmCentral_StockSystem.Views.Farmer.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content">
        <div class="col-md-4">
            <h1>Manage Categories</h1>

            <div class="mb-3">
                <label for="Cname" class="form-label">Category Name</label>
                <input type="text" class="form-control" id="Cname" runat="server">
            </div>

            <div class="mb-3">
                <label for="Cremarks" class="form-label"> Category Remarks</label>
                <input type="text" class="form-control" id="Cremarks" runat="server">
            </div>

            <label id="ErrMsg" runat ="server" class="auto-style1"></label>
        <asp:Button Text="Edit" class="btnedit" runat="server" ID="EditBtn" OnClick="EditBtn_Click" />
        <asp:Button Text="Save" class="btnsave" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
        <asp:Button Text="Delete" class="btndelete" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
            <br />
            <br />
            <br />
    </div>
       <div class="col-md-8">
           </div>
         <asp:GridView runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" ID="CategoryGV"
    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoryGV_SelectedIndexChanged">
</asp:GridView>
       </div>

</asp:Content>
