<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Asset>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Asset</legend>

        <%: Html.HiddenFor(model => model.Id) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FundId, "Fund") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("FundId", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.FundId) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.AssetDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.AssetDate) %>
            <%: Html.ValidationMessageFor(model => model.AssetDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Shares) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Shares) %>
            <%: Html.ValidationMessageFor(model => model.Shares) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Assets) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Assets) %>
            <%: Html.ValidationMessageFor(model => model.Assets) %>
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
