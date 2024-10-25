using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Color = System.Drawing.Color;

namespace chart_sample2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // ChartArea追加
            _ = this.Chart1.ChartAreas.Add("ChartArea1");

            // Seriesの作成と値の追加
            //var series = new Series
            //{
            //    ChartType = SeriesChartType.Candlestick,
            //    MarkerStyle = MarkerStyle.Circle,
            //    Color = Color.Yellow,
            //    XValueType = ChartValueType.Auto,
            //    YValueType = ChartValueType.Auto,
            //};
            // グラフ領域の設定
            ChartArea area = new ChartArea();

            area.AxisX.Title = "装備品名";
            //area.AxisX.IntervalType = DateTimeIntervalType.Days;
            //area.AxisX.Minimum = new DateTime(2010, 1, 1).ToOADate();
            //area.AxisX.Maximum = new DateTime(2010, 1, 10).ToOADate();
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 6.0;
            area.AxisX.MajorGrid.Enabled = false;

            // 縦軸（株価軸）の設定
            area.AxisY.Title = "タイムライン";
            area.AxisY.IntervalType = DateTimeIntervalType.Days;
            area.AxisY.Minimum = new DateTime(2010, 1, 3).ToOADate();
            area.AxisY.Maximum = new DateTime(2010, 1, 10).ToOADate();
            //area.AxisY.Minimum = 950;
            //area.AxisY.Maximum = 1050;

            // 既定のグラフ領域の設定をクリアした後、設定する
            Chart1.ChartAreas.Clear();
            Chart1.ChartAreas.Add(area);

            // データ系列を作成する
            double[] values =
            [
                new DateTime(2010, 1, 4).ToOADate(),
                new DateTime(2010, 1, 7).ToOADate()
            ];

            double[] values2 =
            [
                new DateTime(2010, 1, 6).ToOADate(),
                new DateTime(2010, 1, 8).ToOADate()
            ];

            Series series = CreateSeries("hogehoge", 2, values);
            Series series3 = CreateSeries("fugafuga", 3, values2);
            //Series series2 = NewMethod();

            Chart1.Series.Clear();
            Chart1.Series.Add(series);
            //Chart1.Series.Add(series2);
            Chart1.Series.Add(series3);
        }

        private static Series NewMethod()
        {
            Series series2 = new Series();
            series2.ChartType = SeriesChartType.RangeBar;
            series2.Color = Color.Blue;

            for (int i = 0; i < 5; i++)
            {
                // 日付(2010/1/4から5本)
                DateTime date = new DateTime(2010, 1, 4).AddDays(i);

                // High Low Open Closeの順番で配列を作成
                double[] values =
                [
                    new DateTime(2010, 1, 4+i).ToOADate(),
                    new DateTime(2010, 1, 5+i).ToOADate(),
                    new DateTime(2010, 1, 6+i).ToOADate(),
                    new DateTime(2010, 1, 7+i).ToOADate()
                ];

                // 日付、四本値の配列からDataPointのインスタンスを作成
                //DataPoint dp = new DataPoint(date.ToOADate(), values);
                DataPoint dp = new DataPoint(Convert.ToDouble(i), values);
                series2.Points.Add(dp);
            }
            series2.AxisLabel = "piyopiyo";

            return series2;
        }

        private static Series CreateSeries(string label, int y, double[] values)
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.RangeBar;
            series.Color = Color.Yellow;
            //DateTime date = new DateTime(2010, 1, 4);
            DataPoint dp = new DataPoint(Convert.ToDouble(y), values);
            series.Points.Add(dp);
            //for (int i = 0; i < 5; i++)
            //{
            //    // 日付(2010/1/4から5本)
            //    DateTime date = new DateTime(2010, 1, 4).AddDays(i);

            //    // High Low Open Closeの順番で配列を作成
            //    double[] values =
            //    [
            //        new DateTime(2010, 1, 4+i).ToOADate(),
            //        new DateTime(2010, 1, 7+i).ToOADate()
            //    ];

            //    // 日付、四本値の配列からDataPointのインスタンスを作成
            //    DataPoint dp = new DataPoint(date.ToOADate(), values);
            //    series.Points.Add(dp);
            //}
            series.AxisLabel = label;
            return series;
        }
    }


}