<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderSuccess.aspx.cs" Inherits="ThreeAmigos.CustomerApp.OrderSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Order Successful</h1>

        <!-- Message -->
        <div class="form-group">
            <div class="row">
                <asp:Label ID="messageLabel" CssClass="form-control textBoxStyling" runat="server"></asp:Label>
            </div>
        </div>

        <%--Buttons--%>
        <div class="row">
            <asp:Button ID="OrderButton" class="btn btn-success" runat="server" Text="Order" OnClick="OrderButton_Click" />
        </div>
    </div>
</asp:Content>
