<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBarangSeller.Master" AutoEventWireup="true" CodeBehind="masterbarangseller.aspx.cs" Inherits="faiproyek.masterbarangseller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%-- nama sepatu--%>
    <div class="row form-group">
       <div class="col col-md-3">
           <label for="text-input" class=" form-control-label">Nama Sepatu</label></div>
       <div class="col-12 col-md-9">
           <asp:TextBox ID="tx_namasepatu" placeholder="Text" class="form-control" runat="server"></asp:TextBox>
           <small class="form-text text-muted">This is a help text</small>
       </div>
   </div>

   <%-- kategori sepatu--%>
   <div class="row form-group">
       <div class="col col-md-3"><label for="select" class=" form-control-label">Select</label></div>
       <asp:DropDownList ID="DropDownList1" runat="server" class="col-12 col-md-9">
           <asp:ListItem class="form-control">Flatshoes</asp:ListItem>
           <asp:ListItem class="form-control">Sneaker</asp:ListItem>
       </asp:DropDownList>
       <div class="col-12 col-md-9">
           <select name="select" id="select" class="form-control">
               <option value="0">Please select</option>
               <option value="1">Option #1</option>
               <option value="2">Option #2</option>
               <option value="3">Option #3</option>
           </select>
       </div>
   </div>
</asp:Content>
