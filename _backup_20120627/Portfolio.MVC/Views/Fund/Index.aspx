<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Portfolio.MVC.Models.Fund>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            Fund Code
        </th>
        <th>
            Fund Name
        </th>
        <th>
            Fund Type
        </th>
        <th>
            Prefix
        </th>
        <th>
            Currency
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.FundCode) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.FundName) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.FundType) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.FundCodePrefix) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Currency) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %>  <%--|
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
           <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>--%>
        </td>
    </tr>
<% } %>
  
</table>

</asp:Content>
