<%@ Page Title="" Language="C#" MasterPageFile="~/HistoryUser.Master" AutoEventWireup="true" CodeBehind="historyuser.aspx.cs" Inherits="faiproyek.historyuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myaccount" runat="server">
     <div class="auto-style1">
        <asp:Label  class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" ID="lb_namaUser" runat="server"></asp:Label>
        <div class="dropdown-menu">
            <a class="dropdown-item" href="accountsetting.aspx">My Account</a>
            <a class="dropdown-item" href="#">My History</a>
            <a class="dropdown-item" href="index.aspx">Logout</a>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="history" runat="server">
    <div class="container bg0 p-t-75 p-b-85">
        <div class="row">
            <div class="col-lg-10 col-xl-7 m-lr-auto m-b-50">
                <div class="m-l-25 m-r--38 m-lr-0-xl">
                    <div class="wrap-table-shopping-cart">
                        <asp:GridView ID="GridView1" class="table-shopping-cart" runat="server" AutoGenerateColumns="False" BorderStyle="None" CellPadding="10" CellSpacing="10" AllowPaging="True" GridLines="None" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
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
                                       
                                        <asp:Label ID="Label6" runat="server" Text=' <%# Eval("Status").ToString() == "P" ? "Proses" : "Sending" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="Action" SelectText="View Details" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                     <asp:DetailsView ID="DetailsView1" class="table-shopping-cart"  runat="server" Height="50px" Width="210px" AllowPaging="True" AutoGenerateRows="False" BackColor="#CCCCFF" BorderStyle="Solid" OnPageIndexChanging="DetailsView1_PageIndexChanging">
                         <Fields>
                             
                             <asp:TemplateField HeaderText="Image">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Id_sepatu") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <InsertItemTemplate>
                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Id_sepatu") %>'></asp:TextBox>
                                 </InsertItemTemplate>
                                 <ItemTemplate>
                                     <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Id_sepatu", "blob.aspx?Id_sepatu={0}") %>' />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
                             <asp:BoundField DataField="Id_order" HeaderText="Id_order" />
                             <asp:BoundField DataField="Id_cart" HeaderText="Id_cart" />
                             <asp:BoundField DataField="Nama_sepatu" HeaderText="Nama_sepatu" />
                             <asp:BoundField DataField="Size" HeaderText="Size" />
                             <asp:BoundField DataField="Warna" HeaderText="Warna" />
                             <asp:BoundField DataField="Jumlah" HeaderText="Jumlah" />
                             <asp:BoundField DataField="Total" HeaderText="Total" />
                             <asp:TemplateField HeaderText="Status">
                                 <EditItemTemplate>
                                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <InsertItemTemplate>
                                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                 </InsertItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("Status").ToString() == "P" ? "Paid" : "Sending" %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="Id_sepatu" HeaderText="Id_sepatu" Visible="False" />
                         </Fields>
                    </asp:DetailsView>

                </div>

            </div>
        </div>
    </div>


</asp:Content>
