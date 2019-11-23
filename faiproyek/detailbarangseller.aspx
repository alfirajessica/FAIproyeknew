<%@ Page Title="" Language="C#" MasterPageFile="~/DetailBarangSeller.Master" AutoEventWireup="true" CodeBehind="detailbarangseller.aspx.cs" Inherits="faiproyek.detailbarangseller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%--menunjukan username--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbar-header">
         <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#main-menu" aria-controls="main-menu" aria-expanded="false" aria-label="Toggle navigation">
             <i class="fa fa-bars"></i>
         </button>
         <asp:Label class="navbar-brand" ID="lb_namauser1" runat="server" Text=""></asp:Label>
         <a class="navbar-brand hidden" href="./"><img src="images/logo2.png" alt="Logo"></a>
     </div>
</asp:Content>

<%-- master Tambah, edit, hapus detail barang seller--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">

       <%-- pilih barang yang ingin ditambah, edit, hapus detail barangnya--%>
         <div class="col-lg-7">
            <div class="card">
                <div class="card-header">
                    <strong>Pilih </strong> Barang 
                </div>
                <div class="card-body card-block">
                    <%-- isi--%>
                    <%-- id dan nama sepatu--%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="text-input" class=" form-control-label">Id - Nama Barang</label></div>
                        <div class="col-12 col-md-8">
                            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <%-- Dekskripsi sepatu--%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="select" class=" form-control-label">Deskripsi</label>
                        </div>
                        <div class="col-12 col-md-8">
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </div>        
                    </div>


                     <%--yakin ini barangnya--%>
                    <asp:Button ID="Button3" runat="server" Text="Add Detail"  class="btn btn-primary btn-sm" />
        
                </div>
            </div>
        </div>

        <%--Detail barang--%>
        <div class="col-lg-5">
            <div class="card">
                <div class="card-header">
                    <strong>Detail </strong> Barang
                </div>
                <div class="card-body card-block">
                    <%-- isi--%>
                    <%-- size sepatu--%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="text-input" class=" form-control-label">Size</label></div>
                        <div class="col-12 col-md-8">
                            <asp:TextBox ID="tx_sizesepatu" placeholder="Size" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            <small class="form-text text-muted">This is a help text</small>
                        </div>
                    </div>

                     <%-- kategori sepatu--%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="select" class=" form-control-label">Warna</label>
                        </div>
                        <div class="col-12 col-md-8">
                            <asp:DropDownList ID="dl_warnasepatu" runat="server" class="form-control">
                            <asp:ListItem class="form-control">Merah</asp:ListItem>
                            <asp:ListItem class="form-control">Putih</asp:ListItem>
                            <asp:ListItem class="form-control">Hitam</asp:ListItem>
                             </asp:DropDownList>
                        </div>        
                    </div>

                    <%-- stok sepatu--%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="text-input" class=" form-control-label">Stok</label></div>
                        <div class="col-12 col-md-8">
                            <asp:TextBox ID="tx_stoksepatu" placeholder="Stok" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            <small class="form-text text-muted">This is a help text</small>
                        </div>
                    </div>

                     <%--submit kedua untuk masukin ke database DSepatu dan munculkan ke table bawah--%>
                    <asp:Button ID="btn_addDetail" runat="server" Text="Add Detail"  class="btn btn-primary btn-sm" />
        
                </div>
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
                
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id_sepatu" HeaderText="#" >
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Email_seller" HeaderText="Email" >
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nama_sepatu" HeaderText="Nama" >
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Jenis_sepatu" HeaderText="Jenis_sepatu" >
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Deskripsi" HeaderText="Deskripsi" />
                        <asp:ImageField DataAlternateTextField="Gambar" DataAlternateTextFormatString="Gambar" DataImageUrlField="Id_sepatu" DataImageUrlFormatString="blob.aspx?Id_sepatu={0}" HeaderText="Gambar">
                        </asp:ImageField>
                        <asp:TemplateField AccessibleHeaderText="Action" HeaderText="Action" ShowHeader="False">
                            <ItemTemplate>
                                <%--kalau edit isi dari table row yg dipilih masuk ke detal barang--%>
                                <asp:Button class="btn btn-primary btn-sm" ID="Button1" runat="server" CausesValidation="False" CommandName="Select" Text="Edit" />
                                <asp:Button class="btn btn-danger btn-sm" ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                            </ItemTemplate>
                            <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
