<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Farmer/FarmerMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="FarmCentral_StockSystem.Views.Farmer.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <div class="col-md-4">
            <h1>Product Details</h1>

            <div class="mb-3">
                <label for="Pname" class="form-label">Product Name</label>
                <input type="text" class="form-control" id="Pname" runat="server">
            </div>

 <%--<div class="mb-3">
    <label for="Pcategory" class="form-label">Product Category</label>
    <!--<input type="text" class="form-control" id="Pcategory" runat="server">-->
    <asp:DropDownList ID="CategoryCb" CssClass="form-control" runat="server"></asp:DropDownList>
</div>--%>

             <div class="mb-3">
    <label for="Pprice" class="form-label">Product Price</label>
    <input type="text" class="form-control" id="Pprice" runat="server" />
</div>

            <div class="mb-3">
    <label for="Pquantity" class="form-label">Product Quantity</label>
    <input type="text" class="form-control" id="Pquantity" runat="server" />
</div>

             <div class="mb-3">
    <label for="Exdate" class="form-label">Expiration Date</label>
    <input type="date" class="form-control" id="Exdate" runat="server" />
</div>
            <label runat="server"  id="ErrMsg"></label>
        <asp:Button Text="Edit" class="btnedit" runat="server" ID="BtnEdit" OnClick="BtnEdit_Click" />
        <asp:Button Text="Save" class="btnsave" runat="server" ID="btnSave" OnClick="btnSave_Click" />
        <asp:Button Text="Delete" class="btndelete" runat="server" OnClick="btnDelete_Click" />
            <br />
            <br />
            <br />
    </div>
       <div class="col-md-8">
           <asp:GridView runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" ID="ProductGV"
    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductGV_SelectedIndexChanged" >
</asp:GridView>
           </div>
       </div>
</asp:Content>
