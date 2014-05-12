﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Trade>" %>

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
        <legend>Trade</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FundId, "Fund") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("FundId", String.Empty)%>
            <%: Html.ValidationMessageFor(model => model.FundId) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.TradeDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.TradeDate) %>
            <%: Html.ValidationMessageFor(model => model.TradeDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Shares) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Shares) %>
            <%: Html.ValidationMessageFor(model => model.Shares) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Amount) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Amount) %>
            <%: Html.ValidationMessageFor(model => model.Amount) %>
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
