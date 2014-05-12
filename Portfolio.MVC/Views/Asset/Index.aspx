<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Portfolio.MVC.Models.Asset>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Assets
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            Fund
        </th>
        <th>
            AssetDate
        </th>
        <th>
            Shares
        </th>
        <th>
            Assets
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Fund.FundCode) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.AssetDate) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Shares) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Assets) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
