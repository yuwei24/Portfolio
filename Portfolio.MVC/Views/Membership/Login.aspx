<%@ Page Title="Login" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<Portfolio.MVC.Models.MembershipModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Login</h2>
<% using (Html.BeginForm())
{ %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.UserName) %>
    </div>
    <div class="editor-field">
        <%: Html.EditorFor(model => model.UserName) %>
        <%: Html.ValidationMessageFor(model => model.UserName) %>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.PassWord) %>
    </div>
    <div class="editor-field">
        <%: Html.PasswordFor(model => model.PassWord) %>
        <%: Html.ValidationMessageFor(model => model.PassWord)%>
    </div>
    <p>
        <input type="submit" value="Login" />
    </p>
    </fieldset>
<% } %>
</asp:Content>
