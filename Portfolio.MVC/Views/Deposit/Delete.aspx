<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Deposit>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to mature this?</h3>
<fieldset>
    <legend>Deposit</legend>

    <div class="display-label">Fund</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Fund.FundName) %>
    </div>

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
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Mature" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
