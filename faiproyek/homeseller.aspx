<%@ Page Title="" Language="C#" MasterPageFile="~/HomeSeller.Master" AutoEventWireup="true" CodeBehind="homeseller.aspx.cs" Inherits="faiproyek.homeseller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

 <%--menunjukan username--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="navbar-header">
         <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#main-menu" aria-controls="main-menu" aria-expanded="false" aria-label="Toggle navigation">
             <i class="fa fa-bars"></i>
          </button>
         <asp:Label class="navbar-brand" ID="lb_namauser1" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="dashboard" runat="server">
        <div class="row">
            <div class="col-lg-7">
                <div class="card">
                    <asp:DropDownList ID="ddlChart" AutoPostBack="true" runat="server" CssClass="custom-select col-md-4" 
                        OnSelectedIndexChanged="ddlChart_SelectedIndexChanged"></asp:DropDownList> 
                    <asp:Chart ID="chart_category" runat="server" Palette="EarthTones" Width="524px" >
                        <Series>
                            <asp:Series Name="Series1"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX Title="Nama_sepatu"></AxisX>  
                                <AxisY Title="Harga"></AxisY> 
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                 </div>
             </div>
        </div>

    <%--    table--%>
    <div class="row">
        <!--/.TABLE BARANG-->
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
               <strong>Detail Sepatu</strong>
            </div>
            <div class="card-body card-block">
                <%-- isi--%>
                <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="False" BorderStyle="None" CellPadding="10" CellSpacing="10" AllowPaging="True" GridLines="None" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Order Id">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_order") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_order") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tanggal Order">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Tgl_order") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Tgl_order") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Total", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>                                       
                                        <asp:Label ID="Label6" runat="server" Text=' <%# Eval("Status").ToString() == "P" ? "Proses" : "Send" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="Kirim Barang" 
                                            Visible='<%# Eval("Status").ToString() == "P" ? true : false %>' />
                                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select" Text="View Details" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id_cart" Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Id_cart") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Id_cart") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
            </div>
        </div>
    </div>
    </div>
    <div class="row">
        <!--/.detailview-->
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
               <strong>Detail pemesanan</strong>
            </div>
            <div class="card-body card-block">
                <%-- isi--%>
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                <asp:DetailsView ID="DetailsView1" class="table table-bordered"  runat="server" Height="50px" Width="671px" AllowPaging="True" AutoGenerateRows="False" BackColor="#CCCCFF" BorderStyle="Solid" OnPageIndexChanging="DetailsView1_PageIndexChanging">
                         <Fields>
                             
                             <asp:TemplateField HeaderText="Image">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Id_sepatu") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <InsertItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Id_sepatu") %>'></asp:TextBox>
                                 </InsertItemTemplate>
                                 <ItemTemplate>
                                     <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Id_sepatu", "blob.aspx?Id_sepatu={0}") %>' Width="150" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
                             <asp:BoundField DataField="Id_order" HeaderText="Id_order" />
                             <asp:BoundField DataField="Id_cart" HeaderText="Id_cart" />
                             <asp:BoundField DataField="Nama_sepatu" HeaderText="Nama_sepatu" />
                             <asp:BoundField DataField="Size" HeaderText="Size" />
                             <asp:BoundField DataField="Warna" HeaderText="Warna" />
                             <asp:BoundField DataField="Jumlah" HeaderText="Jumlah" />
                             <asp:BoundField DataField="Total" HeaderText="Total" />
                             <asp:BoundField DataField="Id_sepatu" HeaderText="Id_sepatu" Visible="False" />
                         </Fields>
                    </asp:DetailsView>
            </div>
        </div>
        </div>
</asp:Content>