<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Fund>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Fund</legend>

    <div class="display-label">FundCode</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.FundCode) %>
    </div>

    <div class="display-label">FundName</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.FundName) %>
    </div>

    <div class="display-label">FundType</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.FundType) %>
    </div>

    <div class="display-label">FundCodePrefix</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.FundCodePrefix) %>
    </div>

    <div class="display-label">Currency</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Currency) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
