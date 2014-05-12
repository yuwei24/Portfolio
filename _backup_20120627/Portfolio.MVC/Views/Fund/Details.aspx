<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Fund>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

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
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
