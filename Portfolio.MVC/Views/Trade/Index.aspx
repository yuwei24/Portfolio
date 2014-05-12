<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Portfolio.MVC.Models.Trade>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Trades
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table id = "trade" style="border:border-width:0">
        <tr>
            <th>
                TradeDate
            </th>
            <th>
                Fund
            </th>
            <th>
                Shares
            </th>
            <th>
                Amount
            </th>
            <th>
                Price
            </th>
            <th>+/-</th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%--<%: Html.DisplayFor(modelItem => item.TradeDate) %>--%>
                <%: String.Format("{0:d}", item.TradeDate) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Fund.FundName) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Shares) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Amount) %>
            </td>
            <td>
                <%: String.Format("{0:0.000}", item.Amount / item.Shares)%>
            </td>
            <td><a onclick="expandcollapse('<%=item.Fund.FundName%>')">+/-</a></td>
        </tr>
        <% } %>
    </table>

    <script type="text/javascript">
        var collapse = false;
        function expandcollapse(me) {
            var table = document.getElementById("trade");

            if (!collapse) {                
                for (var i = 1, row; row = table.rows[i]; i++) {
                    if ($.trim(row.cells[1].innerHTML) != me)
                        row.style.display = "none";
                }
                collapse = true;
            }
            else {
                for (var i = 1, row; row = table.rows[i]; i++) {                   
                    row.style.display = "";
                }
                collapse = false;
            }
        }
    </script>
</asp:Content>
