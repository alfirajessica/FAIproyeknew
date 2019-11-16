<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="faiproyek.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WEBtopbarLogindanFAQ" runat="server">
     <div class="right-top-bar flex-w h-full">
         <asp:HyperLink ID="HyperLink1" class="flex-c-m trans-04 p-lr-25" runat="server">Help & FAQs</asp:HyperLink>  
         <asp:HyperLink ID="linkLogin" class="flex-c-m trans-04 p-lr-25" runat="server" NavigateUrl="~/login.aspx">Login</asp:HyperLink>  
      </div>
</asp:Content>
