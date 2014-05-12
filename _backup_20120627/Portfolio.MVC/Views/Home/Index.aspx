<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Portfolio.MVC.Models.Fund>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <th>
                            Fund Name
                        </th>
                        <th>
                            Currency
                        </th>
                        <th>
                            Current Assets (RMB)
                        </th>
                        <th>
                            Asset Date
                        </th>
                        <th>
                        </th>
                    </tr>
                    <%decimal total = 0; %>
                    <% foreach (var item in Model)
                       { %>
                    <tr>
                        <td>
                            <%: Html.DisplayFor(modelItem => item.FundName) %>
                        </td>
                        <td>
                            <%: Html.DisplayFor(modelItem => item.Currency) %>
                        </td>
                        <td align="right">
                            <%: Html.DisplayFor(modelItem => item.Assets.OrderBy(t=>t.AssetDate).Last().Assets) %>
                            <% total += item.Assets.OrderBy(t => t.AssetDate).Last().Assets; %>
                        </td>
                        <td>
                            <%: string.Format("{0:d}", item.Assets.Max(t=>t.AssetDate)) %>
                        </td>
                        <td>
                            <img src="images/arrow.gif" width="20" height="20" alt="go" onclick="showAssetChart(<% = item.Id %>)" />
                        </td>
                    </tr>
                    <% } %>
                    <tfoot>
                        <tr>
                            <td colspan="3" align="right">
                                Total
                            </td>
                            <td align="right">
                                <% =total%>
                            </td>
                            <td>
                                <img src="images/arrow.gif" width="20" height="20" alt="go" onclick="showAssetChart(0)" />
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </td>
            <td>
                <div>
                    <img id="chart" src="Asset/GetAssetChart/0" alt="chart" />
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function showAssetChart(id) {
            document.getElementById("chart").src = "Asset/GetAssetChart/" + id;
        }
    </script>
</asp:Content>
