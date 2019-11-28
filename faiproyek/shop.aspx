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

            <div class="filter-col3 p-r-15 p-b-27">
                <div class="mtext-102 cl2 p-b-15">
                    Color
                </div>
                <ul>
                    <li class="p-b-6">
                        <asp:DropDownList ID="dl_warnasepatu" runat="server" AutoPostBack="True" class="form-control">
                           
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

        </div>

    </div>

    <%--DATALIST PRODUCT--%>
    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" TabIndex="5" CellPadding="0" HorizontalAlign="Left" CellSpacing="10">
        <ItemStyle Height="400px" VerticalAlign="Top" Width="400px" BorderColor="White" />

        <ItemTemplate>  
            
            <div class="block2-pic hov-img0">               
                <asp:Image href="showdetailbarang.aspx"  ID="Image1" runat="server" ImageUrl='<%# Eval("Id_sepatu", "blob.aspx?Id_sepatu={0}") %>' Width="300" Height="300" />
                <asp:Button ID="Button1" runat="server" Text=" Quick View" class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-10 trans-04 js-show-modal1" PostBackUrl="~/showdetailbarang.aspx" />
               
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
                
                <div class="block2-txt-child2 flex-r p-t-3">
                    <a href="#" class="btn-addwish-b2 dis-block pos-relative js-addwish-b2">
                        <img class="icon-heart1 dis-block trans-04" src="images/icons/icon-heart-01.png" alt="ICON">
                        <img class="icon-heart2 dis-block trans-04 ab-t-l" src="images/icons/icon-heart-02.png" alt="ICON">

                    </a>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

            </div>
                
        </ItemTemplate>
       <SeparatorStyle BorderStyle="Solid" BackColor="White" BorderWidth="5px" />
    </asp:DataList>
   

</div>
</asp:Content>

