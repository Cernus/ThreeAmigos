<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="ThreeAmigos.CustomerApp.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>
            <asp:Label ID="nameLabel" runat="server">Product Name</asp:Label>
        </h1>

        <!-- Validation -->
        <div class="form-group">
            <div class="row">
                <asp:CustomValidator ID="OrderFailedValidation" CssClass="validationText" runat="server" OnServerValidate="OrderFailedValidation_ServerValidate" ErrorMessage="Error: Order Unsuccessful as Order Api is not yet implemented" />
                <asp:CustomValidator ID="StockValidation" CssClass="validationText" runat="server" OnServerValidate="StockValidation_ServerValidate" ErrorMessage="Error: There in not enough of this Product in Stock to Complete the order" />
                <asp:CustomValidator ID="DeliveryValidation" CssClass="validationText" runat="server" OnServerValidate="DeliveryValidation_ServerValidate" ErrorMessage="Error: You must have a Name, Address and Telephone Number before the Order can be completed" />
            </div>
        </div>

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
        <h2>
            <asp:Label runat="server">Reviews</asp:Label>
        </h2>

        <asp:GridView
            ID="ReviewGridView"
            CssClass="table table-condensed table-hover"
            RowStyle-CssClass="filterRow"
            runat="server"
            UseAccessibleHeader="true"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" />
            </Columns>
        </asp:GridView>


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
