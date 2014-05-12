<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Portfolio.MVC.Models.Deposit>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Deposits
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            Deposit Date
        </th>
         <th>
            Type
        </th>
        <th>
            Mature Date
        </th>
        <th>
            Duration (month)
        </th>
        <th>
            Amount
        </th>
        <th>
            Interest Rate
        </th>
        <th>
            Bank
        </th>
        <%--<th></th>--%>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: String.Format("{0:d}", item.DepositDate)%>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Fund.FundName)%>
        </td>
        <td>
            <%: String.Format("{0:d}", item.MatureDate)%>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Duration) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Amount) %>
        </td>
        <td>
             <%: String.Format("{0:p2}", item.InterestRate)%>
        </td>
         <td>
             <%: Html.DisplayFor(modelItem => item.Bank) %>
        </td>
        <td>
            <%: Html.ActionLink("Mature", "Delete", new { id=item.Id }) %> 
            <%--<%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>--%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
