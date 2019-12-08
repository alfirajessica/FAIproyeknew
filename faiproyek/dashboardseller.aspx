<%@ Page Title="" Language="C#" MasterPageFile="~/DashboardSeller.Master" AutoEventWireup="true" CodeBehind="dashboardseller.aspx.cs" Inherits="faiproyek.dashboardseller" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
    <div class="col-lg-6">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="mb-3">Bar chart </h4>
                                <canvas id="barChart"></canvas>
                            </div>
                        </div>
                    </div><!-- /# column -->
</asp:Content>
