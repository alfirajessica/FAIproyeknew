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
    <div class="bor8 m-b-20 how-pos4-parent">
        <asp:TextBox placeholder="email" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_email" runat="server" TextMode="Email" Enabled="False"></asp:TextBox>
        <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
    </div>

     <%--nama--%>
     <div class="bor8 m-b-20 how-pos4-parent" ID="nama" runat="server">
         <asp:TextBox placeholder="nama" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_nama" runat="server"> </asp:TextBox>
		 <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
	 </div>

     <%--notelp--%>
     <div class="bor8 m-b-20 how-pos4-parent" ID="notelp" runat="server">
       <asp:TextBox placeholder="nomor telepon" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_notelp" runat="server" MaxLength="12" TextMode="Number"></asp:TextBox>
       <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
	 </div>
   
     <%-- password lama dan utk konfirmasi pengubahn data (jika dia memilih ubah password)  --%>
     <div class="bor8 m-b-20 how-pos4-parent" ID="pass_lama" runat="server">
        <asp:TextBox placeholder="password anda" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_passlama" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
        <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
	 </div>

     <%-- password baru --%>
     <div class="bor8 m-b-20 how-pos4-parent" ID="pass_baru" runat="server">
        <asp:TextBox placeholder="password baru" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_passbaru" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
        <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
	 </div>

    <asp:Label ID="lb_notif" runat="server"></asp:Label>

    <%--button submit data diri baru--%>
    <div class="bor8 m-b-20 how-pos4-parent" ID="submit" runat="server">
        <asp:Button class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" runat="server" Text="Submit" ID="btn_submit" OnClick="btn_submit_Click" />
	</div>

    <%--button submit ubah pass--%>
    <div class="bor8 m-b-20 how-pos4-parent" ID="submitpass" runat="server">
        <asp:Button class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" runat="server" Text="Submit password baru" ID="btn_submitpassbaru" OnClick="btn_submitpassbaru_Click" />
	</div>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/home.aspx">Back to Home</asp:HyperLink>


</asp:Content>
