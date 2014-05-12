<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Asset>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Asset</legend>

    <div class="display-label">Fund</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Fund.FundCode) %>
    </div>

    <div class="display-label">AssetDate</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.AssetDate) %>
    </div>

    <div class="display-label">Shares</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Shares) %>
    </div>

    <div class="display-label">Assets</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Assets) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
