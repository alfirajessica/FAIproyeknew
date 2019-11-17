<%@ Page Title="" Language="C#" MasterPageFile="~/Register.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="faiproyek.Register1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

<%--            REGISTER--%>
       <%-- email--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email tidak bole kosong" Display="Dynamic" Font-Bold="False" Font-Size="8pt" ForeColor="Red" ControlToValidate="tx_email"></asp:RequiredFieldValidator>
        <div class="bor8 m-b-20 how-pos4-parent">
        <asp:TextBox placeholder="email" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_email" runat="server" TextMode="Email"></asp:TextBox>
		<img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
        </div>

         <%--   nama--%>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nama tidak bole kosong" Display="Dynamic" Font-Bold="False" Font-Size="8pt" ForeColor="Red" ControlToValidate="tx_nama"></asp:RequiredFieldValidator>
         <div class="bor8 m-b-20 how-pos4-parent">
         <asp:TextBox placeholder="nama" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_nama" runat="server"> </asp:TextBox>
		 <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
	     </div>

         <%-- password--%>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="password tidak boleh kosong" Display="Dynamic" Font-Bold="False" Font-Size="8pt" ForeColor="Red" ControlToValidate="tx_pass"></asp:RequiredFieldValidator>
          <div class="bor8 m-b-20 how-pos4-parent">
          <asp:TextBox placeholder="password" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_pass" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
		  <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
	      </div>

        <%-- konfirm password--%>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="pass dan conpass tdk sama" ControlToCompare="tx_konpass" ControlToValidate="tx_pass" Font-Size="8pt" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
        <div class="bor8 m-b-20 how-pos4-parent">
        <asp:TextBox placeholder="konfirmasi password" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_konpass" runat="server" TextMode="Password" MaxLength="8"></asp:TextBox>
		<img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
        </div>

         <%--notelp--%>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="No telpon tidak boleh kosong" Display="Dynamic" Font-Bold="False" Font-Size="8pt" ForeColor="Red" ControlToValidate="tx_notelp"></asp:RequiredFieldValidator>
        <div class="bor8 m-b-20 how-pos4-parent">
            <asp:TextBox placeholder="nomor telepon" class="stext-111 cl2 plh3 size-116 p-l-62 p-r-30" ID="tx_notelp" runat="server" MaxLength="12" TextMode="Number"></asp:TextBox>
		    <img class="how-pos4 pointer-none" src="images/icons/icon-email.png" alt="ICON">
	    </div>

            <asp:Label ID="lb_notif" runat="server"></asp:Label>
            <asp:Button class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" ID="btn_regist_pembeli" runat="server" Text="Register sebagai Pembeli" OnClick="btn_regist_pembeli_Click" ValidateRequestMode="Enabled" />
            <br />
         <asp:Button class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" ID="btn_regist_penjual" runat="server" Text="Register sebagai penjual" OnClick="btn_regist_penjual_Click" />

        </ContentTemplate>
    </asp:UpdatePanel>     
</asp:Content>
