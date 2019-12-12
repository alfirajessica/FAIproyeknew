<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="faiproyek.shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            display: -ms-inline-flexbox;
            display: inline-flex;
            vertical-align: middle;
            left: 0px;
            top: 0px;
        }
        .auto-style2 {
            float: left;
            height: 169px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myaccount" runat="server">
     <div class="auto-style1">
        <asp:Label  class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" ID="lb_namaUser" runat="server"></asp:Label>
        <div class="dropdown-menu">
            <a class="dropdown-item" href="accountsetting.aspx">My Account</a>
            <a class="dropdown-item" href="historyuser.aspx">My History</a>
            <a class="dropdown-item" href="index.aspx">Logout</a>
        </div>
    </div>
</asp:Content>

 <%-- filter berdasarkan gender--%>
<asp:Content ID="Content3" ContentPlaceHolderID="search_filter_listbrg" runat="server">

<div class="flex-w flex-sb-m p-b-52">
   <!-- Search product -->
    <div class="panel-search w-full p-t-10 p-b-15">
        <div class="bor8 dis-flex p-l-15">
            <button class="size-113 flex-c-m fs-16 cl2 hov-cl1 trans-04">
                <i class="zmdi zmdi-search"></i>
            </button>
            <asp:TextBox ID="tx_search" runat="server" placeholder="Search" class="mtext-107 cl2 size-114 plh2 p-r-15" TextMode="Search" style="width: 990px"></asp:TextBox>           
        </div>	
    </div>
    <!-- end of Search product -->

    <!-- Filter -->
    <div class="panel-filter w-full p-t-10">
        <div class="wrap-filter flex-w bg6 w-full p-lr-40 p-t-27 p-lr-15-sm">
            
            <div class="filter-col1 p-r-15 p-b-27">
                <div class="mtext-102 cl2 p-b-15">
                    Gender
                </div>
                <ul>      
                    <li class="p-b-6">
                        <asp:DropDownList ID="dl_gender" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dl_gender_SelectedIndexChanged">
                            <asp:ListItem>Man</asp:ListItem>
                            <asp:ListItem>Women</asp:ListItem>
                            <asp:ListItem>Unisex</asp:ListItem>
                            
                        </asp:DropDownList>
                    </li>
                </ul>
            </div>
            
            <%--DATALIST PRODUCT--%>
            <div class="filter-col2 p-r-15 p-b-27">
                <div class="mtext-102 cl2 p-b-15">
                    Price
                </div>
                <ul>
                    <li class="p-b-6">
                        <asp:DropDownList ID="dl_price" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dl_price_SelectedIndexChanged">
                            <asp:ListItem>Rp100.000 - Rp1.000.000</asp:ListItem>
                            <asp:ListItem>Rp1.000.000 - Rp3.000.000</asp:ListItem>
                            <asp:ListItem>&gt; 3.000.000</asp:ListItem>
                        </asp:DropDownList>
                    </li>

                </ul>

            </div>
            <div class="filter-col4 p-b-27">
                <div class="mtext-102 cl2 p-b-15">
                    Category
                </div>
                <div class="flex-w p-t-4 m-r--5"> 
                    <asp:DropDownList ID="dl_category" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="dl_category_SelectedIndexChanged"></asp:DropDownList>
                </div>

            </div>
            <div class="filter-col2 p-r-15 p-b-27">
                <div class="mtext-102 cl2 p-b-15">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Reset filter</asp:LinkButton>
                </div>
               
            </div>

        </div>

    </div>

    <%--DATALIST PRODUCT--%>
    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" TabIndex="5" CellPadding="0" HorizontalAlign="Left" CellSpacing="10">
        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
        <ItemStyle Height="400px" VerticalAlign="Top" Width="400px" BorderColor="White" />

        <ItemTemplate>  
            
            <div class="block2-pic hov-img0">               
                <asp:Image href="showdetailbarang.aspx"  ID="Image1" runat="server" ImageUrl='<%# Eval("Id_sepatu", "blob.aspx?Id_sepatu={0}") %>' Width="300" Height="300" />               
            </div>

            <div class="block2-txt flex-w flex-t p-t-14">
                <div class="block2-txt-child1 flex-col-l ">
                    <a href="showdetailbarang.aspx?id_sepatu=<%# Eval("Id_sepatu") %>" class="stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6">
                        <%#Eval("Nama_sepatu")%>
                    </a>
                    
                    <span class="stext-105 cl3">
                       <%# string.Format("{0:C}", Eval("Harga"))%>
                    </span>

                </div>
            </div>
                
        </ItemTemplate>
       <SeparatorStyle BorderStyle="Solid" BackColor="White" BorderWidth="5px" />
    </asp:DataList>

    <div class="flex-l-m flex-w w-full p-t-10 m-lr--7">
        <asp:Repeater ID="rptPager" runat="server" >
            <ItemTemplate>
                <asp:LinkButton class="flex-c-m how-pagination1 trans-04 m-all-7" ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                    CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                    OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>' EnableTheming="True" Font-Bold="True" BorderStyle="None" BackColor="White" Height="50" Width="50" TabIndex="10" EnableViewState="True"></asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</asp:Content>

