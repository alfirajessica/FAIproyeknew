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

                <%-- nama sepatu--%>
                <div class="row form-group">
                    <div class="col col-md-3">
                        <label for="text-input" class=" form-control-label">Nama Sepatu</label></div>
                    <div class="col-12 col-md-8">
                        <asp:TextBox ID="tx_namasepatu" placeholder="Text" class="form-control" runat="server"></asp:TextBox>
                        <small class="form-text text-muted">This is a help text</small>
                    </div>
                </div>

                 <%-- kategori sepatu--%>
                <div class="row form-group">
                    <div class="col col-md-3">
                        <label for="select" class=" form-control-label">Jenis Sepatu</label>
                    </div>
                    <div class="col-12 col-md-8">
                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                        <asp:ListItem class="form-control">Flatshoes</asp:ListItem>
                        <asp:ListItem class="form-control">Sneaker</asp:ListItem>
                         </asp:DropDownList>
                    </div>        
                </div>

                <%-- deskripsi sepatu--%>
                <div class="row form-group">
                    <div class="col col-md-3">
                        <label for="select" class=" form-control-label">Deskripsi</label>
                    </div>
                    <div class="col-12 col-md-8">
                         <asp:TextBox name="textarea-input" rows="5" ID="TextBox1" placeholder="deskripsi" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>

                 <%--submit pertama untuk masukin ke database HSepatu--%>
                <asp:Button ID="btn_submitsepatu1" runat="server" Text="Submit"  class="btn btn-primary btn-sm" />
    
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
                        <asp:TextBox ID="TextBox2" placeholder="Size" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        <small class="form-text text-muted">This is a help text</small>
                    </div>
                </div>

                 <%-- kategori sepatu--%>
                <div class="row form-group">
                    <div class="col col-md-3">
                        <label for="select" class=" form-control-label">Warna</label>
                    </div>
                    <div class="col-12 col-md-8">
                        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
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
                        <asp:TextBox ID="TextBox3" placeholder="Stok" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        <small class="form-text text-muted">This is a help text</small>
                    </div>
                </div>

                 <%--submit kedua untuk masukin ke database DSepatu--%>
                <asp:Button ID="Button1" runat="server" Text="Submit"  class="btn btn-primary btn-sm" />
    
            </div>
        </div>
    </div>
    </div>
  

  
    
     

    <%-- WARNA sepatu--%>
   <%--<div class="row form-group">
       <div class="col col-md-3">
           <label for="select" class=" form-control-label"></label>
       </div>
       <div class="col-12 col-md-9">
           <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
           <asp:ListItem class="form-control">Flatshoes</asp:ListItem>
           <asp:ListItem class="form-control">Sneaker</asp:ListItem>
            </asp:DropDownList>
       </div>        
   </div>--%>


   

   <%-- size sepatu yg tersedia--%>



</asp:Content>
