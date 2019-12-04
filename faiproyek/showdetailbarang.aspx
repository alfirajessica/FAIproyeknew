<%@ Page Title="" Language="C#" MasterPageFile="~/ShowDetailBarang.Master" AutoEventWireup="true" CodeBehind="showdetailbarang.aspx.cs" Inherits="faiproyek.showdetailbarang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="myaccount" runat="server">
     <div class="auto-style1">
        <asp:Label  class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" ID="lb_namaUser" runat="server"></asp:Label>
        <div class="dropdown-menu">
            <a class="dropdown-item" href="accountsetting.aspx">My Account</a>
            <a class="dropdown-item" href="index.aspx">Logout</a>
        </div>
    </div>
</asp:Content>--%>

<%--detail barang--%>
<asp:Content ID="Content3" ContentPlaceHolderID="detailbarang" runat="server">
    
		<div class="container">
			<div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">
				
                <asp:ImageButton ID="btn_cancel" runat="server" ImageUrl="~/icon-close2.png" OnClick="btn_cancel_Click" />
                
				<div class="row">
					<div class="col-md-6 col-lg-7 p-b-30">
						<div class="p-l-25 p-r-30 p-lr-0-lg">
							<div class="wrap-slick3 flex-sb flex-w">
								<div class="wrap-slick3-dots"></div>
								<div class="wrap-slick3-arrows flex-sb-m flex-w"></div>

								<div class="slick3 gallery-lb">
									<div class="item-slick3" data-thumb="">
										<div class="wrap-pic-w pos-relative">

                                            <%--gambar product--%>
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" Height="300px" Width="300px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="id" Visible="False">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_sepatu") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_sepatu") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ImageField DataImageUrlField="Id_sepatu" DataImageUrlFormatString="blob.aspx?Id_sepatu={0}">
                                                        <ControlStyle Height="300px" Width="300px" />
                                                    </asp:ImageField>
                                                </Columns>
                                            </asp:GridView>

										</div>
									</div>

									
								</div>
							</div>
						</div>
					</div>
					
					<div class="col-md-6 col-lg-5 p-b-30">
						<div class="p-r-50 p-t-5 p-lr-0-lg">
                            <asp:Label ID="lb_namaproduk" runat="server" Text="" class="mtext-105 cl2 js-name-detail p-b-14"></asp:Label> /
                            <asp:Label ID="lb_jenis" runat="server" Text=""></asp:Label><br />
                            <asp:Label ID="lb_harga" runat="server" Text="" class="mtext-106 cl2"></asp:Label><br />

                           
                            <asp:Label ID="lb_deskripsi" runat="server" Text="" class="stext-102 cl3 p-t-23"></asp:Label>

							<!--  -->
							<div class="p-t-33">
								<div class="flex-w flex-r-m p-b-10">                
									<div class="size-203 flex-c-m respon6">
										Size
									</div>

									<div class="size-204 respon6-next">
										<div class="rs1-select2 bor8 bg0">
                                           <%-- size yang tersedia diambil dari detail barang milik barang yg dipilih--%>
                                            <asp:DropDownList ID="dl_size" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="dl_size_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem>Select Size</asp:ListItem>
                                            </asp:DropDownList>
										</div>
									</div>
								</div>

								<div class="flex-w flex-r-m p-b-10">
									<div class="size-203 flex-c-m respon6">
										Color
									</div>

									<div class="size-204 respon6-next">
										<div class="rs1-select2 bor8 bg0">
                                             <%-- warna yang tersedia diambil dari detail barang milik barang yg dipilih--%>
                                            <asp:DropDownList ID="dl_color" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dl_color_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem>Select Color</asp:ListItem>
                                             </asp:DropDownList>
										</div>
									</div>
								</div>

                                
								<div class="flex-w flex-r-m p-b-10">
									<div class="size-203 flex-c-m respon6">
										Stok tersisa
									</div>

									<div class="size-204 respon6-next">
										<div class="rs1-select2 bor8 bg0">

                                          <%-- stok tersisa--%>
                                             <asp:Label ID="lb_sisanotif" runat="server" Text=""></asp:Label>
										</div>
									</div>
								</div>
                              

								<div class="flex-w flex-r-m p-b-10">
									<div class="size-204 flex-w flex-m respon6-next">
										<div class="wrap-num-product flex-w m-r-20 m-tb-10">
											 <asp:TextBox ID="tx_jumlah" min="1" max="50" placeholder="Jumlah" 
                                                 class="form-control" runat="server" TextMode="Number" OnTextChanged="tx_jumlah_TextChanged" AutoPostBack="True"></asp:TextBox>
										</div>
                                        <asp:Label ID="lb_total" runat="server" Text=""></asp:Label>

                                        <asp:Button ID="btn_addtocart" runat="server" Text="Add to cart" class="flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer" OnClick="btn_addtocart_Click"/>
                                        
                                    </div>
								</div>	
							</div>
							
						</div>
					</div>
				</div>
			</div>
		</div>
       
</asp:Content>

