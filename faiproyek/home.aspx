<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="faiproyek.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WEBtopbarLogindanFAQ" runat="server">
     <div class="right-top-bar flex-w h-full">
         <asp:HyperLink ID="HyperLink1" class="flex-c-m trans-04 p-lr-25" runat="server">Help & FAQs</asp:HyperLink>  
         <asp:HyperLink ID="linkLogin" class="flex-c-m trans-04 p-lr-25" runat="server" NavigateUrl="~/login.aspx">Login</asp:HyperLink>  
      </div>
</asp:Content>



<%--catatan:
ContentPlaceHolderID --> menunjukan ID yang dimilki oleh Head dan form yang ada di Home.master--%>