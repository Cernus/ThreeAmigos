<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestDelete.aspx.cs" Inherits="ThreeAmigos.CustomerApp.RequestDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Request Delete</h1>
        <div class="row">
            <p>Are you sure that you wish to request your account be deleted?</p>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <asp:Button ID="deleteButton" class="btn btn-warning" runat="server" Text="Delete" OnClick="delete_Click" />
            </div>
            <div class="col-sm-6">
                <asp:Button ID="backButton" class="btn btn-secondary" runat="server" Text="Back" OnClick="backButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
