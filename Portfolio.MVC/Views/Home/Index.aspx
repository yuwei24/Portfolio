<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Portfolio.MVC.Models.Fund>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Will & Hui's Portfolio 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="right">Last updated on: <label id="lblLastUpdated">last</label></div>
    <br />
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <th>
                            名称
                        </th>
                        <th>
                            货币
                        </th>
                        <th>
                            资产 (RMB)
                        </th>
                        <th>
                            日期
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
                    <img id="chart" src="Asset/GetAssetChart/0" alt="Asset" />
                    <img id="chartInvestment" src="Asset/GetInvestmentChart" alt="Investment" />
                    <img id="chartPortfolio" src="Asset/GetPortfolioChart" alt="Portfolio" />
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function showAssetChart(id) {
            document.getElementById("chart").src = "Asset/GetAssetChart/" + id;
        }

        $(document).ready(
             function () {                 
                 $.ajax({
                     url: "Asset/GetLastUpdatedTimestamp",
                     success: function (data) {
                         $("#lblLastUpdated").html(data);
                     }
                 });
             }
        );
    </script>
</asp:Content>
