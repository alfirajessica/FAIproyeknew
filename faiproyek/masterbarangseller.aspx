<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBarangSeller.Master" AutoEventWireup="true" CodeBehind="masterbarangseller.aspx.cs" Inherits="faiproyek.masterbarangseller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <!--/.MASTER BARANG-->
    <div class="col-lg-7">
        <div class="card">
            <div class="card-header">
                <strong>Master </strong> Barang
            </div>
            <div class="card-body card-block">
                <%-- isi--%>
                <%--gambar sepatu--%>
                <asp:FileUpload ID="FileUpload1" runat="server" />

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

                 <%--submit pertama untuk masukin ke database HSepatu--%>
                <asp:Button ID="btn_submitsepatu1" runat="server" Text="Submit"  class="btn btn-primary btn-sm" />
                
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
                        <asp:BoundField DataField="id" HeaderText="#" >
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Size" HeaderText="Size" >
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Warna" HeaderText="Warna" >
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Stok" HeaderText="Stok" >
                        <HeaderStyle BackColor="Black" ForeColor="White" />
                        </asp:BoundField>
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
