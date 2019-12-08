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
                <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="False" BorderStyle="None" CellPadding="10" CellSpacing="10" AllowPaging="True" GridLines="None">
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
                                       
                                        <asp:Label ID="Label6" runat="server" Text=' <%# Eval("Status").ToString() == "P" ? "Prosess" : "UnPaid" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="Action" SelectText="View Details" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
            </div>
        </div>
    </div>
    </div>
</asp:Content>