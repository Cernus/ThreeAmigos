<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateReview.aspx.cs" Inherits="ThreeAmigos.CustomerApp.CreateReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Write Review</h1>

        <!-- ProductName -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="productNameLabel" runat="server">Write review for the product.</asp:Label>
                </div>
            </div>
        </div>

        <!-- Rating -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Rating</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <input id="ratingSpinner" runat="server" value="1" data-decimals="0" min="1" max="5" step="1" type="number" />
                    <asp:RangeValidator ID="RatingValidator" runat="server" CssClass="validationText" ControlToValidate="ratingSpinner" ErrorMessage="Enter value between 1 and 5" MaximumValue="5" MinimumValue="1" SetFocusOnError="True" Type="Integer" />
                </div>
            </div>
        </div>

        <!-- Description -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server"><strong>Review</strong></asp:Label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="bodyTextBox" CssClass="form-control textBoxStyling" runat="server" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="descriptionValidator" CssClass="validationText" runat="server" ControlToValidate="bodyTextBox" ErrorMessage="Please enter a Review Description" />
                </div>
            </div>
        </div>

        <!-- Buttons -->
        <div class="row">
            <div class="col-sm-6">
                <asp:Button ID="submitButton" class="btn btn-success" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
            </div>
            <div class="col-sm-6">
                <asp:Button ID="backButton" class="btn btn-secondary" runat="server" Text="Back" OnClick="BackButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
