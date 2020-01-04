<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="ThreeAmigos.CustomerApp.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>
            <asp:Label ID="nameLabel" runat="server">Product Name</asp:Label>
        </h1>

        <!-- Quantity -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Select Quantity</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <input id="quantitySpinner" runat="server" value="1" data-decimals="0" min="1" max="1000" step="1" type="number" />
                </div>
            </div>
        </div>

        <%-- TODO: Restyle so border outlines are invisible (differentiate from Quantity above --%>
        <!-- Category -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Category</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="categoryLabel" CssClass="form-control textBoxStyling" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Brand -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Brand</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="brandLabel" CssClass="form-control textBoxStyling" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Description -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Description</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="descriptionLabel" CssClass="form-control textBoxStyling" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Price -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Price</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="priceLabel" CssClass="form-control textBoxStyling" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Stock Level -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Stock Level</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="stockLevelLabel" CssClass="form-control textBoxStyling" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Reviews -->
        <asp:Label ID="test" runat="server">[Reviews here]</asp:Label>

        <!-- TODO: Hyperlink full names of reviewers to navigate to CustomerReviews for that user -->

        <%--Buttons--%>
        <div class="row">
            <div class="col-sm-6">
                <asp:Button ID="OrderButton" class="btn btn-primary" runat="server" Text="Order" OnClick="OrderButton_Click" />
            </div>
            <div class="col-sm-6">
                <asp:Button ID="BackButton" class="btn btn-secondary" runat="server" Text="Back" OnClick="BackButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
