<%@ Page Title="" Language="C#" MasterPageFile="~/TambahBarangSeller.Master" AutoEventWireup="true" CodeBehind="tambahbarangseller.aspx.cs" Inherits="faiproyek.tambahbarangseller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

 <%--menunjukan username--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="navbar-header">
         <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#main-menu" aria-controls="main-menu" aria-expanded="false" aria-label="Toggle navigation">
             <i class="fa fa-bars"></i>
         </button>
         <asp:Label class="navbar-brand" ID="lb_namauser1" runat="server" Text=""></asp:Label>
         <a class="navbar-brand hidden" href="./"><img src="images/logo2.png" alt="Logo"></a>
     </div>
</asp:Content>

<%--Master Tambah barang baru -- Edit Barang lama -- Hapus Barang--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-header">
                    <strong>Master </strong> Barang
                </div>
                <div class="card-body card-block">
                    <asp:Label ID="lb_idsepatu" runat="server" Text=""></asp:Label>
                    <%-- nama sepatu--%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="text-input" class=" form-control-label">Nama Sepatu</label></div>
                        <div class="col-12 col-md-8">
                            <asp:TextBox ID="tx_namasepatu" placeholder="Text" class="form-control" runat="server" OnTextChanged="tx_namasepatu_TextChanged"></asp:TextBox>
                            <small class="form-text text-muted">This is a help text</small>
                        </div>
                    </div>

                     <%-- suitable for --%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="select" class=" form-control-label">Cocok Untuk</label>
                        </div>
                        <div class="col-12 col-md-8">
                            <asp:DropDownList ID="dl_gender" runat="server" class="form-control" AutoPostBack="True">
                                <asp:ListItem>Man</asp:ListItem>
                                <asp:ListItem>Women</asp:ListItem>
                                <asp:ListItem>Unisex</asp:ListItem>
                             </asp:DropDownList>
                        </div>        
                    </div>
                    
                    <%-- jenis/category sepatu--%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="select" class=" form-control-label">Jenis Sepatu</label>
                        </div>
                        <div class="col-12 col-md-8">
                            <asp:DropDownList ID="dl_jenissepatu" runat="server" class="form-control">
                             </asp:DropDownList>
                        </div>        
                    </div>

                     <%-- harga sepatu--%>
                    <div class="row form-group">
                        <div class="col col-md-3">
                            <label for="select" class=" form-control-label">Harga Sepatu</label>
                        </div>
                        <div class="col-12 col-md-8">
                            <asp:TextBox placeholder="Harga Sepatu" class="form-control" ID="tx_harga" runat="server" TextMode="Number"></asp:TextBox>
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
                    
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            
                            <%--gambar sepatu--%>
                            <div class="row form-group">
                                <div class="col col-md-3"><label for="file-input" class=" form-control-label">File Sepatu</label></div>
                                <div class="col-12 col-md-9">
                                    <asp:FileUpload ID="FileUpload1" runat="server"/>
                                    <br />
                                    <asp:Button ID="btn_reset" runat="server" Text="Reset" />
                                </div>
                            </div>
                            
                            <%--submit untuk store ke database HSepatu--%>
                            <asp:Button ID="btn_submitsepatu1" runat="server" Text="Submit"  class="btn btn-primary btn-sm" OnClick="btn_submitsepatu1_Click" />
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            
                            <br /><br />

                           <%-- ajax tidak bisa jalan di fileupload karena ada postbacktrigger--%>
                            <%--table barang apa saja yang dimilki seller/user/vendor--%>
                            <asp:GridView class="table table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView2_SelectedIndexChanging" AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_sepatu") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_sepatu") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Email_seller") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email_seller") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nama">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Nama_sepatu") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Nama_sepatu") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jenis_sepatu">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Jenis_sepatu") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Jenis_sepatu") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deskripsi" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Deskripsi") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Deskripsi") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gambar">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("Id_sepatu") %>' Tooltip='<%# Eval("Gambar", "Gambar") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" AlternateText='<%# Eval("Gambar", "Gambar") %>' ImageUrl='<%# Eval("Id_sepatu", "blob.aspx?Id_sepatu={0}") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="Black" ForeColor="White" />
                                    </asp:TemplateField>
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
                        </ContentTemplate>
                        
                        <%--fungsi trigger agar fileupload.hashfile dapat bernilai true--%>
                        <%--dan dapat upload gambar--%>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btn_submitsepatu1" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                </div>
            </div>
        </div>
    </div>  <%--close row--%>
</asp:Content>
 <%--TAMBAH BARANG BARU end --%>

