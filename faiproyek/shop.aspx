<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="faiproyek.shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myaccount" runat="server">
     <div class="btn-group">
        <asp:Label  class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" ID="lb_namaUser" runat="server"></asp:Label>
        <div class="dropdown-menu">
            <a class="dropdown-item" href="accountsetting.aspx">My Account</a>
            <a class="dropdown-item active" href="index.aspx">Logout</a>
        </div>
    </div>
</asp:Content>

 <%-- filter berdasarkan gender--%>
<asp:Content ID="Content3" ContentPlaceHolderID="filter_gender" runat="server">
    <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
    <asp:Button ID="Button1" runat="server" Text="Button" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1"/>
    <asp:Button ID="Button2" runat="server" Text="Button" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"/>
    <asp:Button ID="Button3" runat="server" Text="Button" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"/>
</asp:Content>

