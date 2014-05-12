<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">
            www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
        <asp:CheckBox ID="CheckBox1" runat="server" EnableViewState="false" />
        <asp:TextBox ID="TextBox1" runat="server" EnableViewState="false" Text="original"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server" EnableViewState="false">
        </asp:DropDownList>
    </p>
    <p>
        <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Click here to postback"
            OnClick="ImageButton1_Click" />
    </p>
    <%= 1+2 %>
</asp:Content>
