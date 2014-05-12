<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Fund>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fund</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FundCode) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.FundCode) %>
            <%: Html.ValidationMessageFor(model => model.FundCode) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FundName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.FundName) %>
            <%: Html.ValidationMessageFor(model => model.FundName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FundType) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.FundType) %>
            <%: Html.ValidationMessageFor(model => model.FundType) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FundCodePrefix) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.FundCodePrefix) %>
            <%: Html.ValidationMessageFor(model => model.FundCodePrefix) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Currency) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Currency) %>
            <%: Html.ValidationMessageFor(model => model.Currency) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
