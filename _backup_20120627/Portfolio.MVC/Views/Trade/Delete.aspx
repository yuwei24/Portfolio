﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.Trade>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Trade</legend>

    <div class="display-label">Fund</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Fund.FundCode) %>
    </div>

    <div class="display-label">TradeDate</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TradeDate) %>
    </div>

    <div class="display-label">Shares</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Shares) %>
    </div>

    <div class="display-label">Amount</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Amount) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>