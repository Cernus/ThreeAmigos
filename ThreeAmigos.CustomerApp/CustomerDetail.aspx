<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDetail.aspx.cs" Inherits="ThreeAmigos.CustomerApp.CustomerDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>
            <asp:Label ID="usernameLabel" runat="server">Customer Detail</asp:Label>
        </h1>
        
        <!-- FullName -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Full Name</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="fullnameLabel" CssClass="form-control" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Address -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Address</strong></asp:Label>
                </div>
                <div id="addressDiv" class="col-md-8" runat="server">
                    <!-- Dynamically add address labels here -->
                </div>
            </div>
        </div>

        <!-- Email Address -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Email Address</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="emailAddressLabel" CssClass="form-control" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Tel Number -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Telephone Number</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="telLabel" CssClass="form-control" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Can Buy -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Can buy</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="canBuyLabel" CssClass="form-control" runat="server">Yes</asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
