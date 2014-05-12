<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Deposit>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Deposit</legend>

    <div class="display-label">DepositDate</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.DepositDate) %>
    </div>

    <div class="display-label">MatureDate</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.MatureDate) %>
    </div>

    <div class="display-label">Duration</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Duration) %>
    </div>

    <div class="display-label">Amount</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Amount) %>
    </div>

    <div class="display-label">InterestRate</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.InterestRate) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
