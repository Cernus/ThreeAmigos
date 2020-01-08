<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerReviews.aspx.cs" Inherits="ThreeAmigos.CustomerApp.CustomerReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>
            <asp:Label ID="ProductReviewLabel" runat="server">[Customer]'s Reviews</asp:Label>
        </h1>

        <asp:GridView
            ID="ReviewGridView"
            CssClass="table table-condensed table-hover"
            RowStyle-CssClass="filterRow"
            runat="server"
            UseAccessibleHeader="true"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Rating" SortExpression="Product" />
                <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
