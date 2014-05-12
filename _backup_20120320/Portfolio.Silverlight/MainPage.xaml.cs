using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;

using Portfolio.Business;

namespace Portfolio.Silverlight
{
    public partial class MainPage : UserControl
    {
        RadChart toolTipChart;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SilverlightControl_Loaded);

            DateTime now = DateTime.Now.Date;
            DateTime asOfDate = DateTime.Now.Date;

            if (now.DayOfWeek == DayOfWeek.Monday)
                asOfDate = now.AddDays(-4);
            else if (now.DayOfWeek == DayOfWeek.Sunday)
                asOfDate = now.AddDays(-3);
            else
                asOfDate = now.AddDays(-2);

            AssetList.GetAssetList(new DateTime(2000, 1, 1), asOfDate, AssetList_DataLoaded);
        }

        void SilverlightControl_Loaded(object sender, RoutedEventArgs e)
        {
            Style NoDataControlStyle = App.Current.Resources["NoDataControlStyle"] as Style;
            string NoDataSeriesDefaultMessage = " Loading chart...";

            AssetLineChart.DefaultView.ChartArea.NoDataControlStyle = NoDataControlStyle;
            AssetLineChart.DefaultView.ChartArea.NoDataString = NoDataSeriesDefaultMessage;

            AssetLineChart.DefaultView.ChartLegend.Visibility = System.Windows.Visibility.Collapsed;

            AssetLineChart.DefaultView.ChartArea.AxisX.IsDateTime = true;
            AssetLineChart.DefaultView.ChartArea.AxisX.AutoRange = true;
            AssetLineChart.DefaultView.ChartArea.AxisX.DefaultLabelFormat = "dd-MMM-yyyy";
            AssetLineChart.DefaultView.ChartArea.AxisX.LayoutMode = AxisLayoutMode.Inside;
            AssetLineChart.DefaultView.ChartArea.AxisX.LabelStep = 2;

            AssetLineChart.DefaultView.ChartArea.AxisY.IsZeroBased = false;

            AssetLineChart.DefaultView.ChartArea.ItemToolTipOpening += new ItemToolTipEventHandler(ChartArea_ItemToolTipOpening);

            toolTipChart = new RadChart();            
            toolTipChart.Height = 400;
            toolTipChart.Width = 700;            
            
            toolTipChart.DefaultView.ChartArea.AnimationSettings = new AnimationSettings();
            toolTipChart.DefaultView.ChartArea.AnimationSettings.ItemDelay = new TimeSpan(0, 0, 0, 0, 100);
            toolTipChart.DefaultView.ChartArea.AnimationSettings.ItemAnimationDuration = new TimeSpan(0, 0, 0, 0, 100);            
            toolTipChart.DefaultView.ChartArea.NoDataString = "Loading...";
            toolTipChart.DefaultView.ChartArea.SmartLabelsEnabled = true;

            toolTipChart.DefaultView.ChartTitle.Content = string.Empty;
            toolTipChart.DefaultView.ChartLegend.Visibility = System.Windows.Visibility.Collapsed;               
        }

        void AssetList_DataLoaded(object sender, Csla.DataPortalResult<AssetList> e)
        {
            AssetList assetList = e.Object as AssetList;

            LineSeriesDefinition assetSD = new LineSeriesDefinition();
            
            assetSD.Appearance.Stroke = new SolidColorBrush(Colors.Red);
            assetSD.Appearance.StrokeThickness = 1;
            assetSD.Appearance.Fill = new SolidColorBrush(Colors.Red);

            SeriesMapping seriesAssets = new SeriesMapping();
            seriesAssets.SeriesDefinition = assetSD;
            seriesAssets.SeriesDefinition.ShowItemLabels = true;
            seriesAssets.SeriesDefinition.ShowItemToolTips = true;

            seriesAssets.SeriesDefinition.Appearance.PointMark.Stroke = new SolidColorBrush(Colors.Red);
            seriesAssets.SeriesDefinition.Appearance.PointMark.StrokeThickness = 1;

            seriesAssets.SeriesDefinition.LegendDisplayMode = LegendDisplayMode.None;
            //seriesAssets.GroupingSettings.GroupDescriptors.Add(new ChartGroupDescriptor("AssetDate"));

            ItemMapping dateMapping = new ItemMapping("AssetDate", DataPointMember.XValue);
            ItemMapping assetMapping = new ItemMapping("Assets", DataPointMember.YValue);
            
            seriesAssets.ItemMappings.Add(dateMapping);
            seriesAssets.ItemMappings.Add(assetMapping);

            AssetLineChart.SeriesMappings.Add(seriesAssets);
              
            AssetLineChart.ItemsSource = assetList;                        
        }

        void ChartArea_ItemToolTipOpening(ItemToolTip2D tooltip, ItemToolTipEventArgs e)
        {
            try
            {
                if (e.MouseData == null || e.MouseData.OriginalSource == null)
                {
                    //MessageBox.Show("Null value of ItemToolTipEventArgs");
                    tooltip.Visibility = System.Windows.Visibility.Collapsed;
                    return;
                }
                if (e.MouseData.OriginalSource is System.Windows.Shapes.Line)
                {
                    tooltip.Visibility = System.Windows.Visibility.Collapsed;
                    return;
                }
                else
                {
                    tooltip.Visibility = System.Windows.Visibility.Visible;
                }
             
                DateTime dateTime = DateTime.FromOADate(Convert.ToDouble(e.DataPoint.XValue));                                

                toolTipChart.ItemsSource = null;
                if (tooltip.Content != toolTipChart)
                    tooltip.Content = toolTipChart;

                AssetList.GetAssetList(dateTime, DailyAssetList_DataLoaded);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void DailyAssetList_DataLoaded(object sender, Csla.DataPortalResult<AssetList> e)
        {
            AssetList assetList = e.Object as AssetList;

            PieSeriesDefinition tooltipSD = new PieSeriesDefinition();
            tooltipSD.LabelSettings.SpiderModeEnabled = true;
            tooltipSD.LabelSettings.ShowConnectors = true;
            //tooltipSD.RadiusFactor = 1.5;

            SeriesMapping seriesAssets = new SeriesMapping();
            seriesAssets.SeriesDefinition = tooltipSD;
            seriesAssets.SeriesDefinition.ShowItemLabels = true;
            seriesAssets.SeriesDefinition.ShowItemToolTips = true;

            seriesAssets.SeriesDefinition.LegendDisplayMode = LegendDisplayMode.None;
            //seriesAssets.GroupingSettings.GroupDescriptors.Add(new ChartGroupDescriptor("AssetDate"));

            ItemMapping dateMapping = new ItemMapping("FundName", DataPointMember.Label);
            ItemMapping assetMapping = new ItemMapping("Assets", DataPointMember.YValue);

            seriesAssets.ItemMappings.Add(dateMapping);
            seriesAssets.ItemMappings.Add(assetMapping);

            if(toolTipChart.SeriesMappings.Count > 0)
                toolTipChart.SeriesMappings.Remove(toolTipChart.SeriesMappings[0]);
            
            toolTipChart.SeriesMappings.Add(seriesAssets);

            toolTipChart.ItemsSource = assetList;
        }
    }
}
