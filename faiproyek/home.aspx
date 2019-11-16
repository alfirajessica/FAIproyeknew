<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="faiproyek.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="myaccount" runat="server">
    
    <div class="btn-group">
        <asp:Label  class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" ID="lb_namaUser" runat="server"></asp:Label>
        <div class="dropdown-menu">
            <a class="dropdown-item" href="#">My Account</a>
            <a class="dropdown-item active" href="index.aspx">Logout</a>
        </div>
    </div>
 
</asp:Content>



<%--catatan:
ContentPlaceHolderID --> menunjukan ID yang dimilki oleh Head dan form yang ada di Home.master--%>