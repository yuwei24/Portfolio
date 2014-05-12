<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Deposit>" %>

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
        <legend>Deposit</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.DepositDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.DepositDate) %>
            <%: Html.ValidationMessageFor(model => model.DepositDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.MatureDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.MatureDate) %>
            <%: Html.ValidationMessageFor(model => model.MatureDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Duration) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Duration) %>
            <%: Html.ValidationMessageFor(model => model.Duration) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Amount) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Amount) %>
            <%: Html.ValidationMessageFor(model => model.Amount) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.InterestRate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.InterestRate) %>
            <%: Html.ValidationMessageFor(model => model.InterestRate) %>
        </div>

        <%: Html.HiddenFor(model => model.Id) %>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
