<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trade.aspx.cs" Inherits="Portfolio.Web.Trade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <table width="600px">
            <tr>
                <td width="30%">
                    Trade Date
                </td>
                <td>
                    <asp:TextBox ID="txtTradeDate" runat="server" CssClass="leftAlign" Width="100px">
                    </asp:TextBox>
                    <act:calendarextender id="txtTradeDate_CalendarExtender" runat="server" format="dd-MMM-yyyy"
                        targetcontrolid="txtTradeDate">
                    </act:calendarextender>
                </td>
            </tr>
            <tr>
                <td>
                    Fund
                </td>
                <td>
                    <asp:DropDownList ID="ddlFund" runat="server">
                        <asp:ListItem Text = "Select..." Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Shares
                </td>
                <td>
                    <asp:TextBox ID="txtShares" runat="server" CssClass="leftAlign" Width="100px">
                    </asp:TextBox>
                </td>
            </tr>          
            <tr>
                <td>
                    Amount
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="leftAlign" Width="100px" ReadOnly="true">
                    </asp:TextBox>
                </td>
            </tr>
        </table>        
    </div>    
    <asp:Button id="btnSubmit" runat="server" Text="Confirm" 
        onclick="btnSubmit_Click" />
    </form>
</body>
</html>
