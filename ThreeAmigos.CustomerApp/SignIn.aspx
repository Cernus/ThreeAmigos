<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="ThreeAmigos.CustomerApp.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Sign In</h1>
        <div class="container">
            <!-- Username -->
            <div class="form-group">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label runat="server"><strong>Username: </strong></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="usernameLabel" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
            </div>

            <!-- Password -->
            <div class="form-group">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label runat="server"><strong>Password: </strong></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="passwordLabel" CssClass="form-control" runat="server"></asp:Label>
                    </div>
                </div>
            </div>

            <%--Submit Button--%>
            <div class="form-group">
                <div class="row">
                    <asp:Button ID="submitButton" class="btn btn-success" runat="server" Text="Submit" OnClick="submitButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
