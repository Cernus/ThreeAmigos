<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerInputs.ascx.cs" Inherits="CustomerApp.User_Controls.CustomerInputs" %>
<!-- Username -->
<div class="form-group">
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server"><strong>Username</strong></asp:Label>
        </div>
        <div class="col-md-8">
            <asp:TextBox ID="usernameTextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="usernameValidator" CssClass="validationText" runat="server" controltovalidate="usernameTextBox" errormessage="Please enter a Username" />
        </div>
    </div>
</div>

<!-- Password -->
<div class="form-group">
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server"><strong>Password</strong></asp:Label>
        </div>
        <div class="col-md-8">
            <asp:TextBox ID="passwordTextBox" TextMode="Password" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="passwordValidator" CssClass="validationText" runat="server" controltovalidate="passwordTextBox" errormessage="Please enter a Password" />
        </div>
    </div>
</div>

<!-- Name -->
<div class="form-group">
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server"><strong>Name</strong></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="firstNameTextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="secondNameTextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
        </div>
    </div>
</div>

<!-- Address -->
<div class="form-group">
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server"><strong>Address</strong></asp:Label>
        </div>
        <div class="col-md-8">
            <asp:TextBox ID="address0TextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
            <asp:TextBox ID="address1TextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
            <asp:TextBox ID="address2TextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
            <asp:TextBox ID="address3TextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
            <asp:TextBox ID="address4TextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
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
            <asp:TextBox ID="emailAddressTextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
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
            <asp:TextBox ID="telTextBox" CssClass="form-control textBoxStyling" runat="server"></asp:TextBox>
        </div>
    </div>
</div>
