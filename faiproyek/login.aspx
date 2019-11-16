<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="faiproyek.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   <div class="bor8 m-b-20 how-pos4-parent">
       <asp:TextBox class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_email" runat="server"> </asp:TextBox>
		<img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">

	</div>
   

   <div class="bor8 m-b-20 how-pos4-parent">
        <asp:TextBox class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_password" runat="server"> </asp:TextBox>		
       <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">

   </div>
    <asp:Button class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" ID="btn_login" runat="server" Text="Button" OnClick="btn_login_Click" />
  
</asp:Content>
