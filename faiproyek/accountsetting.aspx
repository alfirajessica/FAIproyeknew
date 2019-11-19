<%@ Page Title="" Language="C#" MasterPageFile="~/AccountSetting.Master" AutoEventWireup="true" CodeBehind="accountsetting.aspx.cs" Inherits="faiproyek.accountsetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 class="mtext-105 cl2 txt-center p-b-30"> ACCOUNT SETTING </h4>
    <asp:Button class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" ID="btn_tampilformUbahdata" runat="server" Text="Ubah data " OnClick="btn_tampilformUbahdata_Click"/> 
    <br />
    <asp:Button class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" runat="server" Text="Ubah Password" ID="btn_ubahpass" OnClick="btn_ubahpass_Click" />

    <br />

     <%-- email--%>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email tidak bole kosong" Display="Dynamic" Font-Bold="False" Font-Size="8pt" ForeColor="Red" ControlToValidate="tx_email"></asp:RequiredFieldValidator>
    <div class="bor8 m-b-20 how-pos4-parent">
        <asp:TextBox placeholder="email" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_email" runat="server" TextMode="Email"></asp:TextBox>
        <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
    </div>

     <%-- password baru --%>
     <div class="bor8 m-b-20 how-pos4-parent">
        <asp:TextBox placeholder="password" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_passbaru" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
        <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
	 </div>


    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
</asp:Content>
