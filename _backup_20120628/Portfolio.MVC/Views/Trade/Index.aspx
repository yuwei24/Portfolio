<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Portfolio.MVC.Models.Trade>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table style="border:border-width:0">
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
            <%--<th></th>--%>
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
            <%--<td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
        </td>--%>
        </tr>
        <% } %>
    </table>
</asp:Content>
