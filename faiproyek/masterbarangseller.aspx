<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBarangSeller.Master" AutoEventWireup="true" CodeBehind="masterbarangseller.aspx.cs" Inherits="faiproyek.masterbarangseller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--header nama user--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="navbar-header">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#main-menu" aria-controls="main-menu" aria-expanded="false" aria-label="Toggle navigation">
                    <i class="fa fa-bars"></i>
                </button>
                <asp:Label class="navbar-brand" ID="lb_namauser1" runat="server" Text=""></asp:Label>
               <%-- <a class="navbar-brand" href="./"><img src="images/logo.png" alt="Logo"></a>--%>
                <a class="navbar-brand hidden" href="./"><img src="images/logo2.png" alt="Logo"></a>
            </div>
</asp:Content>

<%--isi konten--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
    <!--/.MASTER BARANG-->
    <div class="col-lg-7">
        <div class="card">
            <div class="card-header">
                <strong>Master </strong> Barang
            </div>
            <div class="card-body card-block">
                <%-- isi--%>
               

                <%-- nama sepatu--%>
                <div class="row form-group">
                    <div class="col col-md-3">
                        <label for="text-input" class=" form-control-label">Nama Sepatu</label></div>
                    <div class="col-12 col-md-8">
                        <asp:TextBox ID="tx_namasepatu" placeholder="Text" class="form-control" runat="server"></asp:TextBox>
                        <small class="form-text text-muted">This is a help text</small>
                    </div>
                </div>

                 <%-- jenis sepatu--%>
                <div class="row form-group">
                    <div class="col col-md-3">
                        <label for="select" class=" form-control-label">Jenis Sepatu</label>
                    </div>
                    <div class="col-12 col-md-8">
                        <asp:DropDownList ID="dl_jenissepatu" runat="server" class="form-control">
                        <asp:ListItem class="form-control">Flatshoes</asp:ListItem>
                        <asp:ListItem class="form-control">Sneaker</asp:ListItem>
                        <asp:ListItem class="form-control">Sports</asp:ListItem>
                         </asp:DropDownList>
                    </div>        
                </div>

                <%-- deskripsi sepatu--%>
                <div class="row form-group">
                    <div class="col col-md-3">
                        <label for="select" class=" form-control-label">Deskripsi</label>
                    </div>
                    <div class="col-12 col-md-8">
                         <asp:TextBox name="textarea-input" rows="5" ID="tx_deskripsi" placeholder="deskripsi" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>

                 <%--gambar sepatu--%>
                 <div class="row form-group">
                     <div class="col col-md-3"><label for="file-input" class=" form-control-label">File Sepatu</label></div>
                     <div class="col-12 col-md-9">
                         <asp:FileUpload ID="FileUpload1" runat="server" class="form-control-file"/>
                         <br />
                          <asp:Button ID="btn_reset" runat="server" Text="Reset" />
                     </div>
                 </div>

                 <%--submit pertama untuk masukin ke database HSepatu--%>
                <asp:Button ID="btn_submitsepatu1" runat="server" Text="Submit"  class="btn btn-primary btn-sm" OnClick="btn_submitsepatu1_Click" />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                <%--btn edit ini akan muncul saat ia telah melakukan submit, jd diawal button ini akann visible false--%>
                <asp:Button ID="btn_editsepatu" runat="server" Text="Edit"  class="btn btn-primary btn-sm" />

            </div>
        </div>
    </div>

    <!--/.DETAIL BARANG-->
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
