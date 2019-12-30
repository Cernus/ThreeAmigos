<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="ThreeAmigos.CustomerApp.OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function divexpandcollapse(divname) {
            var img = "img" + divname;
            if ($("#" + img).attr("src") == "images/plus.png") {
                $("#" + img)
                    .closest("tr")
                    .after("<tr><td></td><td colspan = '100%' > " + $("#" + divname)
                        .html() + "</td></tr>")
                $("#" + img).attr("src", "images/minus.png");
            } else {
                $("#" + img).closest("tr").next().remove();
                $("#" + img).attr("src", "images/plus.png");
            }
        }
    </script>

    <div class="container">
        <h1>Order History</h1>

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView
                    ID="InvoiceGridView"
                    runat="server"
                    AutoGenerateColumns="false"
                    DataKeyNames="OrderId"
                    OnRowDataBound="InvoiceGridView_RowDataBound"
                    CssClass="Grid">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="20px">
                            <ItemTemplate>
                                <a href="JavaScript:divexpandcollapse
				                    ('div<%# Eval("OrderId") %>');">
                                    <img alt="Details" id="imgdiv<%# Eval("OrderId") %>" class="invoiceIcon" src="images/plus.png" />
                                </a>

                                <div id="div<%# Eval("OrderId") %>" style="display: none;">
                                    <asp:GridView
                                        ID="ProductOrderGridView"
                                        runat="server"
                                        AutoGenerateColumns="false"
                                        DataKeyNames="OrderId"
                                        CssClass="ChildGrid">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="Category" HeaderText="Category" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="Brand" HeaderText="Brand" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="Description" HeaderText="Description" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TotalPrice" HeaderText="Total Price" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="Quantity" HeaderText="Quantity" />
                                            <asp:TemplateField HeaderText="Write Review">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="NameLink" runat="server" DataNavigateUrlFields="Name" Text="Write Review"
                                                        NavigateUrl='<%# string.Format("~/CreateReview.aspx?Id={0}", HttpUtility.UrlEncode(Eval("ProductId").ToString())) %>'></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-Width="150px" DataField="reference" HeaderText="Reference" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="invoiceCost" HeaderText="Invoice Cost" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="status" HeaderText="Status" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
