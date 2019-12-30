<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCustomer.aspx.cs" Inherits="ThreeAmigos.CustomerApp.CreateCustomer" %>
<%@ Register Src="~/User_Controls/CustomerInputs.ascx" TagName="CustomerInputs" TagPrefix="uc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Register</h1>
        <uc:CustomerInputs ID="customerInputs" runat="server" />
        <%--Submit Button--%>
        <div class="form-group">
            <div class="row">
                <asp:Button ID="SubmitButton" class="btn btn-success" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
