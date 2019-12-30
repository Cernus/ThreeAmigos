<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="ThreeAmigos.CustomerApp.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        <%--Loose Search--%>
        function LooseSearch() {
            var input, filter, table, tr, td, i, txtValue, filterColumn;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("MainContent_StoreGridView");
            tr = table.getElementsByTagName("tr");
            filterColumn = $("#MainContent_SearchFilterDDL").get(0).selectedIndex;
            for (i = 0; i < tr.length; i++) {
                ;
                td = tr[i].getElementsByTagName("td")[filterColumn];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    </script>

    <div class="container">
        <h1>Store</h1>
        <div class="row">
            <div class="col-sm-12">
                <p>Type something in the input field to search the Store</p>
            </div>
            <div class="col-sm-12">
                <div style="display: inline-block">
                    <asp:DropDownList ID="SearchFilterDDL" runat="server" OnChange="LooseSearch()"></asp:DropDownList>
                </div>
                <div style="display: inline-block">
                    <input class="form-control" id="myInput" type="text" placeholder="Search.." onkeyup="LooseSearch()">
                </div>
            </div>
            <div class="col-sm-12">
                <%--TODO: Format so Price displays number in £'s--%>
                <asp:GridView
                    ID="StoreGridView"
                    CssClass="table table-condensed table-hover"
                    RowStyle-CssClass="filterRow"
                    runat="server"
                    UseAccessibleHeader="true"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:HyperLink ID="NameLink" runat="server" DataNavigateUrlFields="Name" Text='<%# Eval("Name") %>'
                                    NavigateUrl='<%# string.Format("~/ProductDetail.aspx?Id={0}", HttpUtility.UrlEncode(Eval("ProductId").ToString())) %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" ItemStyle-CssClass="categoryColumn" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" ItemStyle-CssClass="brandColumn" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" ItemStyle-CssClass="descriptionColumn" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ItemStyle-CssClass="priceColumn" />
                        <asp:BoundField DataField="StockLevel" HeaderText="In Stock" SortExpression="StockLevel" ItemStyle-CssClass="stockLevelColumn" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
