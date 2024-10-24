using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            var series = new Series
            {
                ChartType = SeriesChartType.RangeBar,
                MarkerStyle = MarkerStyle.Circle,
                Color = System.Drawing.Color.Yellow,
            };
            series.AxisLabel = "hogehoge";

            var series2 = new Series
            {
                ChartType = SeriesChartType.RangeBar,
                MarkerStyle = MarkerStyle.Circle,
                Color = System.Drawing.Color.Blue,
            };
            series.AxisLabel = "Fugafuga";

            // グラフに表示する値の配列
            Double[] values = [1.0, 2.0, 3.5];
            Double[] values2 = [2.0, 4.5, 2.5];

            foreach (var v in values)
            {
                _ = series.Points.Add(v);
            }

            foreach (var v in values2)
            {
                _ = series2.Points.Add(v);
            }
            this.Chart1.Series.Add(series);
            this.Chart1.Series.Add(series2);

        }
    }
}